using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTowerConcept
{
    class Monster : IDraw
    {

        public sbyte Group { get; set; } 
        public int Attack { get; set; }
        public int HP { get; set; }
        public bool DeathFlag { get; set; }
        #region Draw
        public int PositionX { get; set; }

        public Monster mr;
        public Monster(int startPosition,sbyte Team)
        {
            Group = Team;
            Bounds = new Rectangle(0, 0, 20, 20);
            PositionX = startPosition;
            DeathFlag = false;
            HP = 1;
            Attack = 1;

        }
        public Rectangle Bounds { get; set; }
        public void Draw(Graphics g, int x, int y)
        {
            Pen p;
            if (Group == 1) { p = new Pen(Brushes.Salmon); }
            else
            {
                p = new Pen(Brushes.BlueViolet);
            }
            g.DrawEllipse(p, x - Bounds.Width / 2, y - Bounds.Height / 2, Bounds.Width, Bounds.Height);
            g.DrawRectangle(p, new Rectangle(PositionX, 0, Bounds.Width, Bounds.Height));
            //g.DrawRectangle(p, new Rectangle(mr.PositionX, 0, Bounds.Width, Bounds.Height));
        }
        #endregion
        public bool Collide(Monster mcheck)
        {
            if (mcheck.Group != Group)
                return new Rectangle(PositionX,0,Bounds.Width,Bounds.Height).IntersectsWith(new Rectangle(mcheck.PositionX, 0, mcheck.Bounds.Width, mcheck.Bounds.Height)); 
            return false;
        }
        public void Move(int speed)
        {
            if(Group == 1)
            {
                PositionX -= speed;
            }
            else
            {
                PositionX += speed;
            }
        }
        public void AttackTo(Monster target)
        {
            target.HP -= Attack;
            if (target.HP <= 0) target.DeathFlag = true; 
        }
    }
}
