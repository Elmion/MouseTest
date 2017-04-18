using System.Collections.Generic;
using CommonElement;
using System.Reflection;
using System;
namespace Core
{
    internal class cSlotManager
    {
        Dictionary<Slot, StoreEffects> Slots;
        GameCore core;
        public cSlotManager(GameCore core)
        {
            this.core = core;
            Slots = new Dictionary<Slot, StoreEffects>();
            for (int i = 0; i < core.Player1.Slots.Count; i++)
            {
                Slots.Add(core.Player1.Slots[i], new StoreEffects());
                Slots[core.Player1.Slots[i]].Tags.AddRange(new string[] { "p0", i.ToString() });
                Slots.Add(core.Player2.Slots[i], new StoreEffects());
                Slots[core.Player2.Slots[i]].Tags.AddRange(new string[] { "p1", i.ToString() }); ;
            }
        }

        public void AddEffectToSlot(string EffectName, int numSlot, int team)
        {
            Slot slot = FindSlotIndex(numSlot, team);
            SlotBuff sb = SlotBuffSystem.SpellsBase.Instance.FindBuff(EffectName);
            Slots[slot].Effects.Add(sb);
        }
        public bool PutCard(int numSlot, int team)
        {
            Slot summonedSlot = FindSlotIndex(numSlot, team);

            Card c = summonedSlot.SummonCard();

            c = BuffCard(c,Slots[summonedSlot].Effects);//бафает карту.

            if (c != null && core.Battle.CreateCard(team, c))
            {
                summonedSlot.RechargeCard();
                return true;
            }
            return false;
        }
        private Card BuffCard(Card c, List<SlotBuff> effects)
        {
            for (int i = 0; i < effects.Count; i++)
            {
               if(effects[i].Event == "SummonCard")
                {
                    var index = effects[i].Obj.FindIndex(x => (string)x == "card");
                    if (effects[i].TypeObj[index] == typeof(Card))
                    {
                        effects[i].Obj[index] = c;
                        c = effects[i].Method.Invoke(null, effects[i].Obj.ToArray()) as Card;
                    }
                }
            }
            return c;
        }
        public Slot FindSlotIndex(int numSlot, int team)
        {
            Slot IndexSlot = null; //Ищем слот по номеру
            foreach (var slot in Slots.Keys)
            {
                if (Slots[slot].Tags[1] == numSlot.ToString() && Slots[slot].Tags[0] == ("p"+ team))
                {
                    IndexSlot = slot;
                }
            }
            return IndexSlot;
        }

    }
    internal class StoreEffects
    {
       public  List<string> Tags { get; set; }
       public  List<SlotBuff> Effects { get; set; }
        public StoreEffects()
        {
            Tags = new List<string>();
            Effects = new List<SlotBuff>();
        }
    }
}
