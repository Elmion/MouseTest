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
        private CoreData data;

        ICommand currentCommand;
        History historyBook;

        public Core()
        {
            data = new CoreData();
        }
        public object Run(ICommand command)
        {
            if (data.GameEnd == true && command.GetType() != typeof(cmdRestartGame)) return data.GameWin?"Win":"Fail";
            return command.Execute(data);
        }
        public void Undo()
        {
            historyBook.Undo(data);
        }
        public bool hasPair(int x1, int y1, int x2, int y2)
        {
            return data.GetPairAtPosition(x1, y1, x2, y2) == null ? false : true;
        }
        public bool hasPair(int FirstPosition, int SecondPosition)
        {
            return data.GetPairAtPosition(FirstPosition,SecondPosition) == null ? false : true;
        }
        public List<string> GetReport()
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
       public List<Pair> CurrentPairList;
       public bool GameEnd { get; private set; }
       public bool GameWin { get; private set; }
       public CoreData()
        {
            GameField = new StringBuilder();
            CurrentPairList = new List<Pair>();
            GameEnd = false;
        }
        //Полностью обновляет пары
        public void RefreshCuplesData()
        {
            CurrentPairList.Clear();
            //Буффер для вертикального анализа 
            FieldPosition[] VerticalBuff = new FieldPosition[WidthGameField];

            //Берем первыю позицию 
            FieldPosition prevPosition = new FieldPosition();
            prevPosition.Value = GameField[0];
            prevPosition.Position = 0;
            VerticalBuff[0] = prevPosition;

            // Определяем длину первой строчки .. если строчка больше чем ширина поля то перая строка равна ширене поля.
            int CountFirstCicle = GameField.Length;
            if (CountFirstCicle > WidthGameField)
                CountFirstCicle = WidthGameField;

            // Анализ Первого ряда
            for (int i = 1; i < CountFirstCicle; i++)
            {

                //Инициализируем Вертикальный буффер. Собственно из за него первый ряд и расчитывается отельно
                VerticalBuff[i] = new FieldPosition();
                VerticalBuff[i].Value = GameField[i];
                VerticalBuff[i].Position = i;

                //Пропускаем нули
                if (GameField[i] == '0') continue;
                //Если не нуль, то начинаем анализ
                //
                FieldPosition current = new FieldPosition();
                current.Value = GameField[i];
                current.Position = i;

                //Горизонтальное сравнение
                if (prevPosition.Value == GameField[i])
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

                    FieldPosition current = new FieldPosition();
                    current.Value = GameField[i];
                    current.Position = i;

                    //Горизонтальное сравнение
                    if (prevPosition.Value == GameField[i])
                    {
                        //Формируем пару
                        Pair p = new Pair();
                        p.NumFirst = prevPosition.Clone();
                        p.NumSecond = current.Clone();
                        CurrentPairList.Add(p);
                    }
                    //Вертикальное сравнение
                    if (GameField[i] == VerticalBuff[i % WidthGameField].Value)
                    {
                        Pair p = new Pair();
                        p.NumFirst = VerticalBuff[i % WidthGameField].Clone();
                        p.NumSecond = current.Clone();
                        CurrentPairList.Add(p);
                    }
                    //Заменяем местов  вертикальном буфере 
                    VerticalBuff[i % WidthGameField].Value = GameField[i];
                    VerticalBuff[i % WidthGameField].Position = i;
                    prevPosition = current;
                }
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
            int position1 = x1 * WidthGameField + y1;
            int position2 = x2 * WidthGameField + y2;
            return GetPairAtPosition(position1, position2);
        }
        public void GameFinish(bool win)
        {
            GameEnd = true;
            CurrentPairList.Clear();
            GameField.Clear();
            GameWin = win;
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
    }
    public class FieldPosition
    {
        public char Value;
        public int Position;
        public override string ToString()
        {
            return  "Value= "+ Value + "; Position= " + Position;
        }
        public FieldPosition Clone()
        {
            return new FieldPosition() { Value = Value, Position = Position };
        }
    }
}
