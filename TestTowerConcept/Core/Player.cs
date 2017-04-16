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
        List<Type> Cardbook;
        public List<Slot> CardInSlot;
        public cCristall Cristal { get; }
        public Player(int Team, GameCore core)
        {
            this.Team = Team;
            Cardbook = new List<Type>();
            Cardbook.Add(typeof(Mage));
            Cardbook.Add(typeof(Ogr));
            Cardbook.Add(typeof(OloloSolder));
            Cardbook.Add(typeof(Knight));
            Cardbook.Add(typeof(Bee));
            Cardbook.Add(typeof(RedCat));
            Cardbook.Add(typeof(WildDimon));
            Cardbook.Add(typeof(Orc));
            Cardbook.Add(typeof(Kamicadze));
            Cardbook.Add(typeof(Academic));

            CardInSlot = new List<Slot>();
            this.core = core;
            for (int i = 0; i < 5; i++)
            {
                CardInSlot.Add(new Slot(this));
                GetCardToSlot(i);
            }
            Cristal = new cCristall(); ; // Выдаём один кристалл

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
                if(slot.ReloadRequest && slot.CurrentReloadTime ==0)
                {
                    int rndCard = GameCore.rnd.Next(Cardbook.Count);
                    slot.card = Cardbook[rndCard];
                    Cardbook.RemoveAt(rndCard);
                    slot.ReloadRequest = false;
                }
            }
            Cristal.Update();
        }
        public void AddCardIntoBook(Type c)
        {
            Cardbook.Add(c);
        }
        public void ChangeCardsInSlot(params int[] numSlots)
        {
            for (int i = 0; i < numSlots.Length; i++)
            {
                if (CardInSlot[numSlots[i]].CurrentRechargeTime > 0) continue;
                Cardbook.Add(CardInSlot[numSlots[i]].card);
                CardInSlot[numSlots[i]].card = null;
                CardInSlot[numSlots[i]].CurrentReloadTime = 100;//10 секунд
                CardInSlot[numSlots[i]].ReloadRequest= true;
            }
        }


    }
}
