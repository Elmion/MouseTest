using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   public class Ogr : Card
    {
        public Ogr() : base() 
        {
            Attack = 1;
            AttackDistance = 1;
            HP = 5;
            RunSpeed = 1;
            Height = 20;
            Width = 10;
            RechargeTime = 5;
        }
    }
}
