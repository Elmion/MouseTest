using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class EnergyBlock : IProductBlock
    {
        public float NeedPower
        {
            get
            {
                return 50;
            }
        }
        public bool EnablePower
        {
            get;set;
        }

    }
}
