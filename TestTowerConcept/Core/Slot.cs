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
        public string CardName
        {
            get { return _cardName; }
            set
            {
                if (value == string.Empty) cacheCardInSlot = null;
                _cardName = value;
            }
        }

        private string _cardName = "";
        private Card cacheCardInSlot;

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
        public Card SummonCard()
        {
            if(CurrentRechargeTime == 0 && CurrentReloadTime == 0)
            {
                cacheCardInSlot = CardsBase.Instance.GetClone(_cardName);
                return cacheCardInSlot;
            }
            return null;
        }
        public void RechargeCard()
        {
            CurrentRechargeTime = cacheCardInSlot.RechargeTime;
        }
    }
}