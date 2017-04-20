using CommonElement;
using System;
using System.Collections.Generic;
namespace Core
{
    internal class Slot
    {
        #region События
        public Action<Slot,Card> SlotGoToRecharge;
        public Action<Slot,Card> SlotNowRecharged;
        public Action<Slot,Card> SlotGoToReload;
        public Action<Slot,Card> SlotNowReload;
        public Action<Slot> SlotGoToUpgarade;
        public Action<Slot> SlotNowUpgraded;
        public Action<Slot> SlotGoDegrade;
        public Action<Slot> SlotNowDegraded;

        #endregion
        internal int  CurrentRechargeTime;
        internal int  CurrentReloadTime;
        internal bool ReloadRequest;
        internal int  Cristall { get; set; }

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
        public void PutEffect(SlotBuff buff)
        {

        }
        public void RemoveEffect(SlotBuff buff)
        {

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
            SlotGoToRecharge(this, cacheCardInSlot);
            CurrentRechargeTime = cacheCardInSlot.RechargeTime;
        }
    }
}