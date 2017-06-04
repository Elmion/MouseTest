using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class cmdRewrite : ICommand
    {
        private string HistoryMemo = "";
        public cmdRewrite()
        {
        }
        public object Execute(CoreData data)
        {
            data.History.Add(this);
            string AddationTail =  data.GameField.ToString().Replace("0", string.Empty);
            if (AddationTail.Length + data.GameField.Length  > data.WidthGameField*data.MaxLengthField )//если при дописке мы выходим за границы поля то пройгрыш
            {
                data.GameFinish(false);
                return GameStates.GameOver;
            }
            data.GameField.Append(AddationTail);// если всё впорядке то дописываем хвост
            data.RefreshCuplesData();
            HistoryMemo = AddationTail;
            return AddationTail;
        }

        public object Redo(CoreData data)
        {
            throw new NotImplementedException();
        }

        public object Undo(CoreData data)
        {
            if(HistoryMemo == "" && data.GameWin == false && data.GameEnd == true)
            {
                data.UndoGameFinish();
            }
            data.GameField.Remove(data.GameField.Length - HistoryMemo.Length, HistoryMemo.Length);
            data.RefreshCuplesData();
            return HistoryMemo;

        }
    }
}
