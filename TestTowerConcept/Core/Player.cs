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
        List<Slot> CardInSlot;
        public Player(int Team,GameCore core)
        {
            this.Team = Team;
            Cardbook = new List<Card>();
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
        public void Update(float deltaTime)
        {
            foreach (Slot slot in CardInSlot)
            {
                slot.CurrentRechargeTime -= slot.card.RechargeTime;
                if (slot.ReloadRequest) slot.CurrentReloadTime -= deltaTime;
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
        public void AddCardIntoBook(Card c)
        {
            Cardbook.Add(c);
        }
        public void ChangeCardsInSlot(params int[] numSlots)
        {
            for (int i = 0; i < numSlots.Length; i++)
            {
                Cardbook.Add(CardInSlot[numSlots[i]].card);
                CardInSlot[numSlots[i]].card = null;
                CardInSlot[numSlots[i]].ReloadRequest= true;
            }
        }
    }
}
