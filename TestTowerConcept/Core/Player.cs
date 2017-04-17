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
        List<string> Cardbook;
        public List<Slot> Slots;
        public cCristall Cristal { get; }
        public Player(int Team, GameCore core)
        {
            this.Team = Team;
            Cardbook = new List<string>();
            Cardbook.Add("Mage");
            Cardbook.Add("Ogr");
            Cardbook.Add("OloloSolder");
            Cardbook.Add("Knight");
            Cardbook.Add("Bee");
            Cardbook.Add("RedCat");
            Cardbook.Add("WildDimon");
            Cardbook.Add("Orc");
            Cardbook.Add("Kamicadze");
            Cardbook.Add("Academic");
            Slots = new List<Slot>();
            this.core = core;
            for (int i = 0; i < 5; i++)
            {
                Slots.Add(new Slot(this));
                GetCardToSlot(i);
            }
            Cristal = new cCristall(); ; // Выдаём один кристалл

        }
        public void GetCardToSlot(int slot)
        {
            int rndCard = GameCore.rnd.Next(Cardbook.Count);
            Slots[slot].CardName = Cardbook[rndCard];
            Cardbook.Remove(Cardbook[rndCard]);
        }
        public void Update()
        {
            foreach (Slot slot in Slots)
            {
                if (slot.CurrentRechargeTime > 0) slot.CurrentRechargeTime--;
                if (slot.ReloadRequest) slot.CurrentReloadTime--;
                if(slot.ReloadRequest && slot.CurrentReloadTime ==0)
                {
                    int rndCard = GameCore.rnd.Next(Cardbook.Count);
                    slot.CardName = Cardbook[rndCard];
                    Cardbook.RemoveAt(rndCard);
                    slot.ReloadRequest = false;
                }
            }
            Cristal.Update();
        }
        public void AddCardIntoBook(string c)
        {
            Cardbook.Add(c);
        }
        public bool PutCard(int numSlot)
        {
           Card c =  Slots[numSlot].SummonCard();
           if(c != null && core.Battle.CreateCard(Team, c))
            {
                Slots[numSlot].RechargeCard();
                return true;
            }
            return false;
        }
        public void ChangeCardsInSlot(params int[] numSlots)
        {
            for (int i = 0; i < numSlots.Length; i++)
            {
                if (Slots[numSlots[i]].CurrentRechargeTime > 0) continue;
                Cardbook.Add(Slots[numSlots[i]].CardName);
                Slots[numSlots[i]].CardName = "";
                Slots[numSlots[i]].CurrentReloadTime = 100;//10 секунд
                Slots[numSlots[i]].ReloadRequest= true;
            }
        }
    }
}
