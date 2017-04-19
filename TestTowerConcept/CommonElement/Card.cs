using System.Collections.Generic;
using System.Reflection;

namespace CommonElement
{
    public  class Card
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Attack { get; set; }
        public virtual int AttackDistance { get; set; }
        public virtual int HP { get; set; }
        public virtual int RunSpeed { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual int RechargeTime { get; set; }
        public virtual string Effect { get; set; }
        // List<SpecialAttebute> BaseSpecial;
        public  Card()
        {     
        }
       public virtual void LevelUp()
        {

        }
       public virtual void LevelDown()
        {

        }
        
        public Card GetCurrentCardClone()
        {
            Card c =  this.GetType().GetConstructor(new System.Type[]{ }).Invoke(new object[] { }) as Card;
            c.Attack = Attack;
            c.AttackDistance = AttackDistance;
            c.HP = HP;
            c.RunSpeed = RunSpeed;
            c.Height = Height;
            c.Width = Width;
            return  c;
        }
    }
}