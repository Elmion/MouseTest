using System.Drawing;

namespace Core
{
    internal class cUnit
    {
        public RectangleF Rect;
        private PointF PrePosition;
        public PointF PointPosition;

        Races race;

        int BaseAttack;
        int BaseAttackDistance;
        int HP;
        int BaseRunSpeed;

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
                startPosition = new PointF(0, 0);
            }
            else
            {
                startPosition = new PointF((int)FieldLength.Small, 0);
            }
            Rect = new RectangleF(startPosition.X - origin.Width / 2, startPosition.Y - origin.Height / 2, origin.Height, origin.Width);
        }
        public virtual void Move()
        {
            PrePosition = new PointF(PointPosition.X, PointPosition.Y);
            PointPosition = new PointF(PointPosition.X + BaseRunSpeed, PointPosition.Y);
        }
        public void SetPosition(PointF p)
        {
            PointPosition = p;
        }
        public RectangleF GetMoveRect()
        {
            if (Team == 0)
            {
                return new RectangleF(PrePosition.X - Rect.Width / 2, PrePosition.Y - Rect.Height / 2, PointPosition.X + Rect.Width, PointPosition.Y + Rect.Height);
            }
            else
            {
                return new RectangleF(PointPosition.X - Rect.Width, PointPosition.Y - Rect.Height, PrePosition.X + Rect.Width / 2, PrePosition.Y + Rect.Height / 2);
            }
        }

    }
}