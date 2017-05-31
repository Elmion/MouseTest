using System.Drawing;
using System;
using CommonElement;

namespace Core
{
    internal class cUnit
    {
        public cUnit LockedTarget;
        public RectangleF Rect;
        public PointF PrePosition;
        public PointF PointPosition;
        public Card FreezedCard;
        public bool toRemove;
        public float BaseRunSpeed = 2;

        public sbyte Team
        {
            get; set;
        }
        public cUnit(Card card, sbyte Team)
        {
            toRemove = false;
            this.Team = Team;
            FreezedCard = card;
            if (Team == 0)
            {
                PointPosition = new PointF(0, -FreezedCard.Height / 2);
            }
            else
            {
                PointPosition = new PointF((int)FieldLength.Standart, -FreezedCard.Height/2);
            }
            Rect = new RectangleF(0, 0, FreezedCard.Width, FreezedCard.Height);
        }
        public virtual void Move()
        {
            
            PrePosition = new PointF(PointPosition.X, PointPosition.Y);
            if (this.Team == 0)
                PointPosition = new PointF(PointPosition.X + FreezedCard.RunSpeed, PointPosition.Y);
            else
                PointPosition = new PointF(PointPosition.X - FreezedCard.RunSpeed, PointPosition.Y);
        }
        public virtual void AttackTarget()
        {
            if(LockedTarget != null)
            {
                LockedTarget.FreezedCard.HP -= FreezedCard.Attack;
                if (LockedTarget.FreezedCard.HP <= 0) { LockedTarget.toRemove = true; LockedTarget = null; }
            }
        }
        public void SetPosition(PointF p)
        {
            PointPosition = p;
        }
        public RectangleF GetMoveRect()
        {
            if (Team == 0)
            {
                return new RectangleF(PrePosition.X - Rect.Width / 2, PrePosition.Y - Rect.Height / 2, Math.Abs(PointPosition.X - PrePosition.X) + Rect.Width, Math.Abs(PointPosition.Y- PrePosition.Y) + Rect.Height);
            }
            else
            {
                return new RectangleF(PointPosition.X - Rect.Width/2, PointPosition.Y - Rect.Height/2, Math.Abs(PointPosition.X - PrePosition.X) + Rect.Width, Math.Abs(PointPosition.Y - PrePosition.Y) + Rect.Height);
            }
        }
        public virtual void Draw(Graphics g,int lineHeight)
        {
 
        }
    }
}