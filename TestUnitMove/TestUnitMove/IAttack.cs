using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
    public interface IAttack
    {
        void Attack(Unit u);
    }
    public class Attack1 : IAttack
    {
        public void Attack(Unit u)
        {
        }
    }
    public class Attack2 : IAttack
    {

        public void Attack(Unit u)
        {

        }
    }
}
