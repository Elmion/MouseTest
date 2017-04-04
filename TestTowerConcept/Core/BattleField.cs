using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class BattleField
    {
        List<cUnit> Units;

        public void AllMove()
        {
            foreach (var unit in Units)
            {
                unit.Move();
            }

        }        

    }
}
public enum FieldLength :int
{
    Small = 100,
    Standart = 200,
    Huge = 300
}

