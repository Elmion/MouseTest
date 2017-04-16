using CommonElement;
using System;
namespace Core
{
    internal class Slot
    {

        internal int CurrentRechargeTime;
        internal int CurrentReloadTime;
        internal bool ReloadRequest;
        internal int Cristall { get; set; }
        public Type card { get; set; }


        private Player parent;
        public Slot(Player p)
        {
            Cristall = 0;
        }
        public bool CristallRemove()
        {
            if (Cristall == 0) return false;
            Cristall--;
            return true;
        }
        public bool SummonCard()
        {
            if(CurrentRechargeTime == 0 && CurrentReloadTime == 0)
            {
                Card c = card.GetConstructor(new System.Type[] { }).Invoke(new object[] { }) as Card;
                Battle.CreateCard(sbyte.Parse(splitedCommand[2]), c);
                Player1.RechargeCard(Player1.CardInSlot.FindIndex(x => x.card != null && x.card.GetType() == typeSummonCard));
            }
            return "true";
        }
        public void RechargeCard(int numSlot)
        {
            CardInSlot[numSlot].CurrentRechargeTime = CardInSlot[numSlot].card.RechargeTime;
        }
    }
}