using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
   public class cmdDeletePair : ICommand
    {
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

             
            if (pair == null) return false;
            data.GameField[pair.NumFirst.Position] = '0';
            data.GameField[pair.NumSecond.Position] = '0';

            //Занести в историю изменения

            data.CurrentPairList.Remove(pair);
            return true;
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
