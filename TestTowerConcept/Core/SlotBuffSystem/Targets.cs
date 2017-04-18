using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SlotBuffSystem
{
    class Targets
    {
        public static Slot SelectSelfSlot(cSlotManager sm,int numSlot,int team)
        {
            return sm.FindSlotIndex(numSlot, team);
        }
        public static Slot SelectRightSlot(cSlotManager sm, int numSlot, int team,int OrdinalNum)
        {
            var index = numSlot + OrdinalNum;
            if (index > 5) return null;
            return sm.FindSlotIndex(index, team);
        }
        public static Slot SelectLeftSlot(cSlotManager sm, int numSlot, int team,int OrdinalNum)
        {
            var index = numSlot - OrdinalNum;
            if (index < 0) return null;
            return sm.FindSlotIndex(index, team);
        }
    }
}
