using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonElement;

namespace Core
{
    class Player
    {
        private const int COUNT_SLOTS = 5;
        int Team { get; set; }
        GameCore core;
        List<Card> Cardbook;
        public List<Slot> CardInSlot;
        public Player(int Team,GameCore core)
        {
            this.Team = Team;
            Cardbook = new List<Card>();
            Cardbook.Add(new Mage());
            Cardbook.Add(new Ogr());
            Cardbook.Add(new Mage());
            Cardbook.Add(new Mage());
            Cardbook.Add(new Ogr());
            Cardbook.Add(new Mage());
            Cardbook.Add(new Mage());
            Cardbook.Add(new Ogr());
            Cardbook.Add(new Ogr());
            Cardbook.Add(new Ogr());

            CardInSlot = new List<Slot>();
            this.core = core;
            for (int i = 0; i < 5; i++)
            {
                CardInSlot.Add(new Slot());
                GetCardToSlot(i);
            }
            
        }
        public void GetCardToSlot(int slot)
        {
            int rndCard = GameCore.rnd.Next(Cardbook.Count);
            CardInSlot[slot].card = Cardbook[rndCard];
            Cardbook.Remove(Cardbook[rndCard]);
        }
        public void Update()
        {
            foreach (Slot slot in CardInSlot)
            {
                if (slot.CurrentRechargeTime > 0) slot.CurrentRechargeTime--;
                if (slot.ReloadRequest) slot.CurrentReloadTime--;
                if(slot.CurrentReloadTime <=0)
                {
                    int rndCard = GameCore.rnd.Next(Cardbook.Count);
                    slot.card = Cardbook[rndCard];
                    Cardbook.RemoveAt(rndCard);
                    slot.CurrentReloadTime = 10;//10 секунд
                    slot.ReloadRequest = false;
                }
            }
        }
        public void RechargeCard(int numSlot)
        {
            CardInSlot[numSlot].CurrentRechargeTime = CardInSlot[numSlot].card.RechargeTime;
        }
        public void AddCardIntoBook(Card c)
        {
            Cardbook.Add(c);
        }
        public void ChangeCardsInSlot(params int[] numSlots)
        {
            for (int i = 0; i < numSlots.Length; i++)
            {
                if (CardInSlot[i].CurrentRechargeTime > 0) continue;
                Cardbook.Add(CardInSlot[numSlots[i]].card);
                CardInSlot[numSlots[i]].card = null;
                CardInSlot[numSlots[i]].ReloadRequest= true;
            }
        }
    }
}
