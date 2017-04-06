using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Core
{
   public class BattleField
    {
        internal List<cUnit> Units;
        int GroundLevel;
        public BattleField()
        {
            Units = new List<cUnit>();
        }
        public void AllMove()
        {
            foreach (var unit in Units)
            {
                unit.Move();
            }
            foreach (var unit in Units)
            {
                foreach (var unit2 in Units)
                {
                    if (unit2.Team != unit.Team && unit != unit2)
                    {
                        if (unit.GetMoveRect().IntersectsWith(unit2.GetMoveRect()))
                        {
                            var deltaS = unit.Rect.Width / 2 + unit2.Rect.Width / 2;
                            var S = Math.Abs(unit.PrePosition.X - unit2.PrePosition.X);
                            var v1 = unit.BaseRunSpeed;
                            var v2 = unit2.BaseRunSpeed;
                            if (unit.Team == 0)
                            {
                                unit.SetPosition(new PointF(unit.PrePosition.X + (S - deltaS) * v1 / (v1 + v2), unit.PrePosition.Y));
                                unit2.SetPosition(new PointF(unit2.PrePosition.X - (S - deltaS) * v2 / (v1 + v2), unit2.PrePosition.Y));
                            }
                            else
                            {
                                unit.SetPosition(new PointF(unit.PrePosition.X - (S - deltaS) * v1 / (v1 + v2), unit.PrePosition.Y));
                                unit2.SetPosition(new PointF(unit2.PrePosition.X + (S - deltaS) * v2 / (v1 + v2), unit2.PrePosition.Y));
                            }
                        }
                    }

                }
            }
        }   
        internal void Draw(Graphics g)
        {
            foreach (var unit in Units)
            {
                unit.Draw(g,50);
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

