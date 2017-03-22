using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class MouseCap : IEquipment
    {
        public float bonus
        {
            get { return 0.5f; }

        }
        public Slot EquipSlot
        {
            get
            {
                return Slot.Head;
            }
        }
    }
}
