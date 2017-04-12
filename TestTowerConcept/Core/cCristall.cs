using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class cCristall
    {
        private const int CRISTAL_RESPAWN = 100;
        private int RechargeTime = CRISTAL_RESPAWN;
        private int _count;
        public int Count { get { return _count; } }

        public cCristall()
        {
            _count = 1;
        }
        public void Update()
        {
            RechargeTime--;
            if (RechargeTime == 0)
            {
                RechargeTime = CRISTAL_RESPAWN;
                _count++;
            }
        }
        public void AddCristal()
        {
            _count++;
        }
        public bool RemoveCristall()
        {
            if (_count == 0) return false;
            _count--;
            return true;
        }
    }
}
