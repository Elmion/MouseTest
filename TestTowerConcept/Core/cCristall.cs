using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class cCristall
    {
        private const int CRISTAL_RESPAWN = 96;
        private int RechargeTime = CRISTAL_RESPAWN;
        private int _count;
        public int Count { get { return _count; } }
        private int AllCristal = 1;

        public cCristall()
        {
            _count = 1;
        }
        public void Update()
        {
            if (AllCristal == 9) return;//больше не нужно адейтов
            RechargeTime--;
            if (RechargeTime == 0)
            {
                AllCristal++;
                _count++;
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " " + AllCristal.ToString());
                RechargeTime = (int)(CRISTAL_RESPAWN * Math.Pow(2, AllCristal - 1)); 
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
