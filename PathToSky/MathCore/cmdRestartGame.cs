using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class cmdRestartGame : ICommand
    {

        public cmdRestartGame()
        {

        }
        public object Execute(CoreData data)
        {
            data.UndoGameFinish();
            data.GameField.Clear();
            data.CurrentPairList.Clear();
            data.History.Clear();
            data.HistoryIndex = 0;
            return true;
        }

        public object Redo(CoreData data)
        {
            throw new NotImplementedException();
        }
        //Отмена тут не предусмотрена, поэтому исполняем но не чего не возвращаем
        public object Undo(CoreData data)
        {
            return null;
        }
    }
}
