using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
    public interface IMove
    {
        void Move(Unit u);
    }
    public class Move1:IMove 
    {
        public void Move(Unit u)
        {
        }
    }
    public class Move2 : IMove
    {

        public void Move(Unit u)
        {
        }
    }

}
