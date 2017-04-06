using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonElement
{
   public class Portal : Card
    {
        public Portal() : base() 
        {
            Attack = 0;
            AttackDistance = 0;
            HP = 300;
            RunSpeed = 0;
            Height = 40;
            Width = 5;
            RechargeTime = 5;
        }
    }
}
