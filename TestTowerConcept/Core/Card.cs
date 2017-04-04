using System.Collections.Generic;

namespace Core
{
    internal class Card
    {
        public int Attack { get; set; }
        public int AttackDistance { get; set; }
        public int HP { get; set; }
        public int RunSpeed { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float RechargeTime { get; set; }

        int BaseAttack;
        int BaseAttackDistance;
        int BaseHP;
        int BaseRunSpeed;
        int BaseHeight;
        int BaseWidth;

        List<SpecialAttebute> BaseSpecial;
       public  Card()
        {
            
        }
       public void LevelUp()
        {

        }
       public void LevelDown()
        {

        }
        public Card GetCardClone()
        {
            Card = new Card()
        }
    }
}