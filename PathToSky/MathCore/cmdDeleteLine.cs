using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
   public class cmdDeleteLine : ICommand
    {
        public cmdDeleteLine()
        {

        }
        public object Execute(CoreData data)
        {
            List<int> OUT = new List<int>();
            string toAnalyse = data.GameField.ToString();
            //количество строк
            int lineCount = (int)Math.Ceiling((double)(toAnalyse.Length) / data.WidthGameField);
            for (int i = 0; i < lineCount; i++)
            {
                int lenghtTail  = data.WidthGameField;
                if (toAnalyse.Length < i * data.WidthGameField + data.WidthGameField)  lenghtTail = toAnalyse.Length - i * data.WidthGameField; //длина остатка от поля
                if (toAnalyse.Substring(i * data.WidthGameField, lenghtTail).Split('0').Length-1 == lenghtTail)// Узнаем сколько нулей в строчке если равно длине то удаляем
                 {
                        toAnalyse = toAnalyse.Remove(i * data.WidthGameField, lenghtTail);
                       //Корректируем пары
                       int corrPosition = i * data.WidthGameField + data.WidthGameField;// Позиция после которой нужно корректировать пары
                       for (int j = 0; j < data.CurrentPairList.Count; j++)
                        {
                            if (data.CurrentPairList[j].NumFirst.Position > corrPosition) data.CurrentPairList[j].NumFirst.Position  -= data.WidthGameField;
                            if (data.CurrentPairList[j].NumSecond.Position > corrPosition) data.CurrentPairList[j].NumFirst.Position -= data.WidthGameField;
                        }
                        OUT.Add(i); //Номер удаленной строки для тех кому это надо
                        lineCount--; //количество линий уменьшилось
                        i--;//так как строку удалили интератор уменьшаем
                 }
            }

            //Обновялем поле
            data.GameField.Clear();
            data.GameField.Append(toAnalyse);

            if (data.GameField.Length == 0) data.GameFinish(true); //Если линий нет то конец игры. 

            return OUT;
        }
        public void Undo()
        {

        }
    }
}
