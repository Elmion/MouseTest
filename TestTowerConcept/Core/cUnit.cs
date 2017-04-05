using System.Drawing;
using System;


namespace Core
{
    internal class cUnit
    {
        public RectangleF Rect;
        public PointF PrePosition;
        public PointF PointPosition;

        Races race;

        int BaseAttack;
        int BaseAttackDistance;
        int HP;
        public float BaseRunSpeed = 2;

        public sbyte Team
        {
            get; set;
        }
        public cUnit(Card origin, sbyte Team)
        {
            this.Team = Team;
            PointF startPosition;
            if (Team == 0)
            {
                PointPosition = new PointF(0, 0);
            }
            else
            {
                PointPosition = new PointF((int)FieldLength.Small, 0);
            }
            Rect = new RectangleF(0, 0, origin.Height, origin.Width);
        }
        public virtual void Move()
        {
            
            PrePosition = new PointF(PointPosition.X, PointPosition.Y);
            if (this.Team == 0)
                PointPosition = new PointF(PointPosition.X + BaseRunSpeed, PointPosition.Y);
            else
                PointPosition = new PointF(PointPosition.X - BaseRunSpeed, PointPosition.Y);
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
        public virtual void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Brushes.Red),new Rectangle((int)(PointPosition.X - Rect.Width / 2),(int)(PointPosition.Y - Rect.Height / 2), (int)Rect.Width, (int)Rect.Height));
        }
    }
}