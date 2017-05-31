using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CommonElement;
namespace Core
{
   public class BattleField
    {
        internal List<cUnit> Units;
        int GroundLevel;
        public BattleField()
        {
            Units = new List<cUnit>();
            //Порталы игроков всегда на поле.
            Units.Add(new cUnit(CardsBase.Instance.GetClone("Portal"), 0));
            Units.Add(new cUnit(CardsBase.Instance.GetClone("Portal"), 1));
        }
        public void AllMove()
        {
            foreach (var unit in Units)
            {
                unit.Move();
            }
            foreach (var unit in Units)
            {
                List<cUnit> unitsCanAttak = new List<cUnit>();
                bool notFoundCurrentTarget = true;
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
                                // 0.01 Обеспечивает минимальное пересeчение
                                unit.SetPosition(new PointF(unit.PrePosition.X + (S - deltaS) * v1 / (v1 + v2)+0.01f, unit.PrePosition.Y));
                                unit2.SetPosition(new PointF(unit2.PrePosition.X - (S - deltaS) * v2 / (v1 + v2)- 0.01f, unit2.PrePosition.Y));
                            }
                            else
                            {
                                unit.SetPosition(new PointF(unit.PrePosition.X - (S - deltaS) * v1 / (v1 + v2)- 0.01f, unit.PrePosition.Y));
                                unit2.SetPosition(new PointF(unit2.PrePosition.X + (S - deltaS) * v2 / (v1 + v2)+ 0.01f, unit2.PrePosition.Y));
                            }
                            // Добавляем до конца списка либо пока не найдём свою цель
                            if(unit2 == unit.LockedTarget)
                            {
                                unit.AttackTarget();
                                notFoundCurrentTarget = false;
                            }
                            else
                            {
                                if(notFoundCurrentTarget) unitsCanAttak.Add(unit2);
                            }                            
                         }
                    }

                }
                //Выбираем случайную цель.
                if(notFoundCurrentTarget && unitsCanAttak.Count>0)
                {
                    unit.LockedTarget = unitsCanAttak[GameCore.rnd.Next(unitsCanAttak.Count)];
                    unit.AttackTarget();
                }
            }
            Units.RemoveAll(x => x.toRemove == true);
        }   
        internal void Draw(Graphics g)
        {
            foreach (var unit in Units)
            {
                unit.Draw(g,50);
            }
        }
        public bool CreateCard(int side, Card c)
        {
            Units.Add(new cUnit(c, (sbyte)side));
            return true;//удачно добавили
        }
    }
}
public enum FieldLength :int
{
    Small = 100,
    Standart = 200,
    Huge = 300
}

