using System.Drawing;
using System;


namespace Core
{
    internal class cUnit
    {
        public RectangleF Rect;
        public PointF PrePosition;
        public PointF PointPosition;
        public Card FreezedCard;
        public float BaseRunSpeed = 2;

        public sbyte Team
        {
            get; set;
        }
        public cUnit(Card origin, sbyte Team)
        {
            this.Team = Team;
            FreezedCard = origin.GetCurrentCardClone();
            if (Team == 0)
            {
                PointPosition = new PointF(0, 0);
            }
            else
            {
                PointPosition = new PointF((int)FieldLength.Standart, 0);
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
            g.DrawRectangle(new Pen(Brushes.Red),new Rectangle((int)(PointPosition.X - Rect.Width / 2),(int)(PointPosition.Y - Rect.Height / 2+ lineHeight), (int)Rect.Width, (int)Rect.Height));
        }
    }
}