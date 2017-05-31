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
        public StringBuilder GameField { get; private set; }
        public int WidthGameField = 9;
        private List<Pair> CurrentPairList;
        public Core()
        {
            GameField = new StringBuilder();
            CurrentPairList = new List<Pair>();
        }
        public void GenerateRandomField()
        {
            StringBuilder OUT = new StringBuilder();
            for (int i = 0; i < 27; i++)
            {
                OUT.Append(rnd.Next(0,10));
            }
            GameField = OUT;
        }
        public void GeneratePrepareField(string s)
        {
            GameField = new StringBuilder(s);
            CurrentPairList = GetCuples();
        }
        public List<Pair> GetCuples()
        {
            List<Pair> listOUT = new List<Pair>();

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
                    listOUT.Add(p);
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
                        listOUT.Add(p);
                    }
                    //Вертикальное сравнение
                    if (GameField[i] == VerticalBuff[i % WidthGameField].Value)
                    {
                        Pair p = new Pair();
                        p.NumFirst = VerticalBuff[i % WidthGameField].Clone();
                        p.NumSecond = current.Clone();
                        listOUT.Add(p);
                    }
                    //Заменяем местов  вертикальном буфере 
                    VerticalBuff[i % WidthGameField].Value = GameField[i];
                    VerticalBuff[i % WidthGameField].Position = i;
                    prevPosition = current;
                }
            }
            return listOUT;
        }
        public void DeletePair(Pair pair)
        {
            if (pair == null) return;
            GameField[pair.NumFirst.Position] = '0';
            GameField[pair.NumSecond.Position] = '0';

            //Занести в историю изменения

            CurrentPairList.Remove(pair);
        }
        public void DeleteLine(int NumLine)
        {
            
        }
        //Ищем пару по позиции в строке
        public Pair GetPairAtPosition(int FirstPosition, int SecondPosition)
        {
            return CurrentPairList.Find(x => (x.NumFirst.Position == FirstPosition || x.NumFirst.Position == SecondPosition) && (x.NumSecond.Position == FirstPosition || x.NumSecond.Position == SecondPosition));
        }
        //Ищем пару по прямым координатам
        public Pair GetPairAtPosition(int x1,int y1,int x2,int y2)
        {
            int position1 = x1 * WidthGameField + y1;
            int position2 = x2 * WidthGameField + y2;
            return GetPairAtPosition(position1, position2);
        }

    }
    
    public class Pair
    {
        public FieldPosition NumFirst { get; set; }
        public FieldPosition NumSecond { get; set; }
        public override string ToString()
        {
                return NumFirst.Value + ":" + NumSecond.Value + "-" + NumFirst.Position + ":" + NumSecond.Position;
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
