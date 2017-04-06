using System.Collections.Generic;

namespace Core
{
    public  class Card
    {
        public virtual int Attack { get; set; }
        public virtual int AttackDistance { get; set; }
        public virtual int HP { get; set; }
        public virtual int RunSpeed { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual float RechargeTime { get; set; }

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
            return  new Card() {Attack = Attack,AttackDistance = AttackDistance, HP = HP, RunSpeed = RunSpeed,Height = Height,Width = Width};
        }
    }
}