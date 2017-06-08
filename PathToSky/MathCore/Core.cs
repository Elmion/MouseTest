using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class Core
    {
        public static Random rnd = new Random();
        public string Field
        { 
            get
            {
                return  data.GameField.ToString();
            }
            private set { }
         }
        public List<Pair> CurrentPairs
        {
            get
            {
                return data.CurrentPairList;
            }
            private set { }
        }
        public GameStates GameState
        {
            get
            {
                if (data.GameEnd)
                {
                    if (data.GameWin) return GameStates.GameWin; else return GameStates.GameOver;
                    
                }
                return GameStates.Processed;
            }
        }
        public bool haveLineToDelete
        {
            get
            {
                return new cmdDeleteLine().CheckPossibilityRemoval(data);
            }
        }
        private CoreData data;
        public Core()
        {
            data = new CoreData();
            data.HistoryIndex = 0;
        }
        public object Run(ICommand command)
        {
            if (data.GameEnd == true && command.GetType() != typeof(cmdRestartGame)) return data.GameWin? GameStates.GameWin:GameStates.GameOver;
            object OUT = command.Execute(data);
            if (OUT != null ) data.HistoryIndex++; //все команды возвращают что то, иначе они не чего не пишут в историю;
            return OUT;
        }
        public object Undo()
        {
           if (data.HistoryIndex == 0) return null;
           object OUT  = data.History[--data.HistoryIndex].Undo(data);
           data.History.RemoveAt(data.History.Count - 1);
           return OUT;
        }
        public bool hasPair(int x1, int y1, int x2, int y2)
        {
            return data.GetPairAtPosition(x1, y1, x2, y2) == null ? false : true;
        }
        public bool hasPair(int FirstPosition, int SecondPosition)
        {
            return data.GetPairAtPosition(FirstPosition,SecondPosition) == null ? false : true;
        }
        
        public List<string> GetConsoleReport()
        {
            List<string> OUT = new List<string>();

            OUT.Add("***********");

            //рисуем поле
            string stringfield = data.GameField.ToString();
            int lineCount = (int)Math.Ceiling((double)(stringfield.Length)/data.WidthGameField);             
            for (int i = 0; i < lineCount; i++)
              {
                    int lenghtTail = data.WidthGameField;
                    if (stringfield.Length < i * data.WidthGameField + data.WidthGameField) lenghtTail = stringfield.Length - i * data.WidthGameField;
                    OUT.Add("|" + stringfield.Substring(i * data.WidthGameField, lenghtTail) + "|");    
              }
            OUT.Add("|---------|");
            foreach (var item in data.CurrentPairList)
            {
                OUT.Add("|" + item.ToString().PadRight(9) + "|");
            }
            OUT.Add("|---------|");
            return OUT;
        }
    }
    public class CoreData
    {
       public StringBuilder GameField;
       public int WidthGameField = 9;
       public int MaxLengthField = 12;
       public List<Pair> CurrentPairList;
       public bool GameEnd { get; private set; }
       public bool GameWin { get; private set; }
       public List<ICommand> History;
       public int  HistoryIndex = 0;

       public CoreData()
        {
            GameField = new StringBuilder();
            CurrentPairList = new List<Pair>();
            History = new List<ICommand>();
            HistoryIndex = 0;
            GameEnd = false;
        }
        //Полностью обновляет пары
        public void RefreshCuplesData()
        {
            CurrentPairList.Clear();
            if (GameField.Length == 0) return;//Защита от пустого поля, список всё равно обнуляем потому что фактически пар нет.
            //Буффер для вертикального анализа 
            FieldPosition[] VerticalBuff = new FieldPosition[WidthGameField];

            //Берем первыю позицию 
            FieldPosition prevPosition = new FieldPosition(0, GameField[0]);
            VerticalBuff[0] = prevPosition;

            // Определяем длину первой строчки .. если строчка больше чем ширина поля то перая строка равна ширене поля.
            int CountFirstCicle = GameField.Length;
            if (CountFirstCicle > WidthGameField)
                CountFirstCicle = WidthGameField;

            // Анализ Первого ряда
            for (int i = 1; i < CountFirstCicle; i++)
            {

                //Инициализируем Вертикальный буффер. Собственно из за него первый ряд и расчитывается отельно
                VerticalBuff[i] = new FieldPosition(i, GameField[i]);

                //Пропускаем нули
                if (GameField[i] == '0') continue;
                //Если не нуль, то начинаем анализ
                //
                FieldPosition current = new FieldPosition(i, GameField[i]);

                //Горизонтальное сравнение
                if (prevPosition.CanConnectWith(current))
                {
                    //Формируем пару
                    Pair p = new Pair();
                    p.NumFirst = prevPosition.Clone();
                    p.NumSecond = current.Clone();
                    CurrentPairList.Add(p);
                }
                prevPosition = current;
            }
            //Слудующие ряды выполянем только если длина поля больше его ширины...
            if (CountFirstCicle == WidthGameField)
            {
                // Ряды после первого
                for (int i = 9; i < GameField.Length; i++)
                {
                    //Пропускаем нули
                    if (GameField[i] == '0') continue;
                    //Если не нуль, то начинаем анализ

                    FieldPosition current = new FieldPosition(i, GameField[i]);

                    //Горизонтальное сравнение
                    if (prevPosition.CanConnectWith(current))
                    {
                        //Формируем пару
                        Pair p = new Pair();
                        p.NumFirst = prevPosition.Clone();
                        p.NumSecond = current.Clone();
                        CurrentPairList.Add(p);
                    }
                    //Вертикальное сравнение
                    if (VerticalBuff[i % WidthGameField].Value.Contains(GameField[i]))
                    {
                        Pair p = new Pair();
                        p.NumFirst = VerticalBuff[i % WidthGameField].Clone();
                        p.NumSecond = current.Clone();
                        CurrentPairList.Add(p);
                    }
                    //Заменяем местов  вертикальном буфере 
                    VerticalBuff[i % WidthGameField]  = new  FieldPosition(i,GameField[i]);

                    prevPosition = current;
                }
            }
            //Удалем дублирующиеся пары
            for (int i = 0; i < CurrentPairList.Count; i++)
            {
                CurrentPairList.Remove(CurrentPairList.Find(x => x == CurrentPairList[i] && !CurrentPairList[i].Equals(x)));
            }
        }
        //Ищем пару по позиции в строке
        public Pair GetPairAtPosition(int FirstPosition, int SecondPosition)
        {
            return CurrentPairList.Find(x => (x.NumFirst.Position == FirstPosition || x.NumFirst.Position == SecondPosition) &&
                                      (x.NumSecond.Position == FirstPosition || x.NumSecond.Position == SecondPosition));
        }
        //Ищем пару по прямым координатам
        public Pair GetPairAtPosition(int x1, int y1, int x2, int y2)
        {
            int position1 = y1 * WidthGameField + x1;
            int position2 = y2 * WidthGameField + x2;
            return GetPairAtPosition(position1, position2);
        }
        public void GameFinish(bool win)
        {
            //Стираем всё подготавливаем данные к новой генерации
            GameEnd = true;
            GameWin = win;
        }
        public void UndoGameFinish()
        {
            //Откатываем только флаги, откатить поле и пары в кометенции комады которая стирала его
            GameEnd = false;
            GameWin = false;
        }
    }
    public class Pair
    {
        public FieldPosition NumFirst { get; set; }
        public FieldPosition NumSecond { get; set; }
        public override string ToString()
        {
                return NumFirst.Value + ":" + NumSecond.Value + "-" + NumFirst.Position.ToString().PadLeft(2) + ":" + NumSecond.Position.ToString().PadLeft(2);
        }
        public static bool operator == (Pair A,Pair B)
        {
            
            return (A.NumFirst.Position == B.NumFirst.Position || A.NumFirst.Position == B.NumSecond.Position) &&
                   (A.NumSecond.Position == B.NumFirst.Position || A.NumSecond.Position == B.NumSecond.Position) && (A.NumFirst.Position != A.NumSecond.Position); 
        }
        public static bool operator != (Pair A, Pair B)
        {
            return (A.NumFirst.Position != B.NumFirst.Position || A.NumFirst.Position != B.NumSecond.Position) && 
                   (A.NumSecond.Position != B.NumFirst.Position || A.NumSecond.Position != B.NumSecond.Position) && (A.NumFirst.Position != A.NumSecond.Position );
        }

    }
    public class FieldPosition
    {
        public static Dictionary<char, List<char>> FieldsLinks = new Dictionary<char, List<char>>()
        {
            { '0',  new List<char>() {'0'} },
            { '1',  new List<char>() {'1','9'} },
            { '2',  new List<char>() {'2','8'} },
            { '3',  new List<char>() {'3','7'} },
            { '4',  new List<char>() {'4','6'} },
            { '5',  new List<char>() {'5'} },
            { '6',  new List<char>() {'6','4'} },
            { '7',  new List<char>() {'7','3'} },
            { '8',  new List<char>() {'8','2'} },
            { '9',  new List<char>() {'9','1'} },
        };

        public List<char> Value;
        public int Position;
        public char OrginChar { get; private set; }
        public FieldPosition(int position, char value)
        {
            Position = position;
            Value = FieldsLinks[value];
            OrginChar = value;
        }
        public override string ToString()
        {
            return  "Value= "+ Value + "; Position= " + Position;
        }
        public FieldPosition Clone()
        {
            return new FieldPosition(Position, OrginChar);
        }
        public bool CanConnectWith(FieldPosition ValueB)
        {
            return Value.Intersect(ValueB.Value).Count() > 0 ? true : false;
        }
    }
    public enum GameStates
    {
        Processed,
        GameOver,
        GameWin
    }
}
