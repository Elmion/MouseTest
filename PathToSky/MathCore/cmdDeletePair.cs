using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
   public class cmdDeletePair : ICommand
    {
        private object[] HistoryMemo;

        private int PosNum1;
        private int PosNum2;

        public cmdDeletePair(int PositionNum1,int PositionNum2)
        {
            this.PosNum1 = PositionNum1;
            this.PosNum2 = PositionNum2;

        }
        public object Execute(CoreData data)
        {
             //Ищем пару
            Pair pair = data.CurrentPairList.Find(x => (x.NumFirst.Position == PosNum1 || x.NumFirst.Position == PosNum2) &&
                                                  (x.NumSecond.Position == PosNum1 || x.NumSecond.Position == PosNum2));
            if (pair.Equals(null)) return null;
            HistoryMemo = new object[] { pair.NumFirst, pair.NumSecond};
            data.History.Add(this);
            data.GameField[pair.NumFirst.Position] = '0';
            data.GameField[pair.NumSecond.Position] = '0';
            //Занести в историю изменения
            data.CurrentPairList.Remove(pair);
            //корректируем пары, путем пересоздания, ибо городить доп логику ошибок больше может стать и не факт что быстрее
            data.RefreshCuplesData();
            //ищем ближайшие цифры по горизонтали
            return true;
        }

        public object Redo(CoreData data)
        {
            throw new NotImplementedException();
        }

        public object Undo(CoreData data)
        {
            data.GameField[((FieldPosition)HistoryMemo[0]).Position] = ((FieldPosition)HistoryMemo[0]).OrginChar;
            data.GameField[((FieldPosition)HistoryMemo[1]).Position] = ((FieldPosition)HistoryMemo[1]).OrginChar;
            data.RefreshCuplesData();
            return true;
        }
    }
}
