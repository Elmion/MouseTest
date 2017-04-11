﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonElement
{
    public class OloloSolder:Card
    {
        public OloloSolder():base()
        {
            Attack = 2;
            AttackDistance = 4;
            HP = 2;
            RunSpeed = 2;
            Height = 10;
            Width = 10;
            RechargeTime = 200;
        }
    }
}
