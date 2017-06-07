using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
   public class cmdDeleteLine : ICommand
    {
        private List<int[]> HistoryMemo; 
        public cmdDeleteLine()
        {
            HistoryMemo = new List<int[]>();
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
                if (toAnalyse.Length < (i+1)* data.WidthGameField )  lenghtTail = toAnalyse.Length - i * data.WidthGameField; //длина остатка от поля
                if (toAnalyse.Substring(i * data.WidthGameField, lenghtTail).Split('0').Length-1 == lenghtTail)// Узнаем сколько нулей в строчке если равно длине то удаляем
                 {
                    //Последнюю укорочененную строчку удаляем только если она последняя.
                     if (lenghtTail < data.WidthGameField && toAnalyse.Length > data.WidthGameField) break;

                       toAnalyse = toAnalyse.Remove(i * data.WidthGameField, lenghtTail);
                       //Корректируем пары
                       int corrPosition = (i+1)* data.WidthGameField  ;// Позиция после которой нужно корректировать пары это следующая строка за удаленной (+1) 
                       for (int j = 0; j < data.CurrentPairList.Count; j++)
                        {
                            if (data.CurrentPairList[j].NumFirst.Position >= corrPosition) data.CurrentPairList[j].NumFirst.Position  -= data.WidthGameField;
                            if (data.CurrentPairList[j].NumSecond.Position >= corrPosition) data.CurrentPairList[j].NumSecond.Position -= data.WidthGameField;
                        }
                        OUT.Add(i); //Номер удаленной строки для тех кому это надо
                        HistoryMemo.Add(new int[]{ i, lenghtTail });
                        lineCount--; //количество линий уменьшилось
                        i--;//так как строку удалили интератор уменьшаем
                 }
            }
            //Обновялем поле
            data.GameField.Clear();
            data.GameField.Append(toAnalyse);
            //Это конец игры?
            if (data.GameField.Length == 0) data.GameFinish(true); //Если линий нет то конец игры. 
            //Вернем номера линий которые удалили
            if( OUT.Count > 0) // если что то удалили то добавляемся в историю
            {
                data.History.Add(this);
                return OUT;
            }
            else return null; // если не чего не произошло то вернем нуль
        }

        /// <summary>
        /// Проверка возможности удаления линии, нужно для клиентов чтоб оценить нужно ли создавать новую команду
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CheckPossibilityRemoval(CoreData data)
        {
            string toAnalyse = data.GameField.ToString();
            //количество строк
            int lineCount = (int)Math.Ceiling((double)(toAnalyse.Length) / data.WidthGameField);
            for (int i = 0; i < lineCount; i++)
            {
                int lenghtTail = data.WidthGameField;
                if (toAnalyse.Length < (i + 1) * data.WidthGameField) lenghtTail = toAnalyse.Length - i * data.WidthGameField; //длина остатка от поля
                if (toAnalyse.Substring(i * data.WidthGameField, lenghtTail).Split('0').Length - 1 == lenghtTail)// Узнаем сколько нулей в строчке если равно длине то удаляем
                {
                    //Последнюю укорочененную строчку удаляем только если она последняя.
                    if (lenghtTail < data.WidthGameField && toAnalyse.Length > data.WidthGameField) break;
                    return true; //достоточно дин раз дойти до сюда чтоб сказать что есть что то на удаление
                }
            }
            //А если дошли до сюда то линий к удалению нет
            return false;
        }
        public object Undo(CoreData data)
        {
            if (data.GameField.Length == 0) data.UndoGameFinish();//если был конец игры то откатываем
            for (int i = HistoryMemo.Count-1 ; i >= 0; i--)
            {
                //Вставили зачернутые 
                data.GameField.Insert(HistoryMemo[i][0] *data.WidthGameField, new StringBuilder().Append('0',HistoryMemo[i][1]).ToString());

                //Скорректировали пары
                for ( int j = 0; j < data.CurrentPairList.Count; j++)
                {
                    if (data.CurrentPairList[j].NumFirst.Position >=  HistoryMemo[i][0] * data.WidthGameField) data.CurrentPairList[j].NumFirst.Position += data.WidthGameField;
                    if (data.CurrentPairList[j].NumSecond.Position >= HistoryMemo[i][0] * data.WidthGameField) data.CurrentPairList[j].NumSecond.Position += data.WidthGameField;
                }
            }
            return HistoryMemo;
        }
        public object Redo(CoreData data)
        {
            return null;
        }
    }
}
