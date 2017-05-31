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
        public Core()
        {

        }
        public string GenerateRandomField()
        {
            string OUT = "";
            for (int i = 0; i < 27; i++)
            {
                OUT += Core.rnd.Next(10).ToString();
            }
            return OUT;
        }
        public List<Pair> GetCuples(string FieldString, int Width)
        {
            List<Pair> listOUT = new List<Pair>();

            //Буффер для вертикального анализа 
            FieldPosition[] VerticalBuff = new FieldPosition[Width];

            //Берем первыю позицию 
            FieldPosition prevPosition = new FieldPosition();
            prevPosition.Value = FieldString[0];
            prevPosition.Position = 0;
            VerticalBuff[0] = prevPosition;

            // Определяем длину первой строчки .. если строчка больше чем ширина поля то перая строка равна ширене поля.
            int CountFirstCicle = FieldString.Length;
            if (CountFirstCicle > Width)
                CountFirstCicle = Width;

            // Анализ Первого ряда
            for (int i = 1; i < CountFirstCicle; i++)
            {

                //Инициализируем Вертикальный буффер. Собственно из за него первый ряд и расчитывается отельно
                VerticalBuff[i] = new FieldPosition();
                VerticalBuff[i].Value = FieldString[i];
                VerticalBuff[i].Position = i;

                //Пропускаем нули
                if (FieldString[i] == '0') continue;
                //Если не нуль, то начинаем анализ
                //
                FieldPosition current = new FieldPosition();
                current.Value = FieldString[i];
                current.Position = i;

                //Горизонтальное сравнение
                if (prevPosition.Value == FieldString[i])
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
            if (CountFirstCicle == Width)
            {
                // Ряды после первого
                for (int i = 9; i < FieldString.Length; i++)
                {
                    //Пропускаем нули
                    if (FieldString[i] == '0') continue;
                    //Если не нуль, то начинаем анализ

                    FieldPosition current = new FieldPosition();
                    current.Value = FieldString[i];
                    current.Position = i;

                    //Горизонтальное сравнение
                    if (prevPosition.Value == FieldString[i])
                    {
                        //Формируем пару
                        Pair p = new Pair();
                        p.NumFirst = prevPosition.Clone();
                        p.NumSecond = current.Clone();
                        listOUT.Add(p);
                    }
                    //Вертикальное сравнение
                    if (FieldString[i] == VerticalBuff[i % Width].Value)
                    {
                        Pair p = new Pair();
                        p.NumFirst = VerticalBuff[i % Width].Clone();
                        p.NumSecond = current.Clone();
                        listOUT.Add(p);
                    }
                    //Заменяем местов  вертикальном буфере 
                    VerticalBuff[i % Width].Value = FieldString[i];
                    VerticalBuff[i % Width].Position = i;
                    prevPosition = current;
                }
            }
            return listOUT;
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
