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
           if (Slots[slot].Effects.Find(x => x.RefParent.Name == EffectName) == null) return;

                    for (int i = 0; i < sb.Stages.Count; i++)
                    {
                        var array = SelectTargets(sb.Stages[i].SlotTargets, numSlot, team);
                        for (int j = 0; j < array.Length; j++)
                        {
                            Slots[array[j]].Effects.Add(sb.Stages[i]);
                        }
                    }

        }

        public bool PutCard(int numSlot, int team)
        {

            Slot summonedSlot = FindSlotIndex(numSlot, team);
            Card c = summonedSlot.SummonCard();
            if (c != null)
            {
                c = BuffCard(c, Slots[summonedSlot].Effects);//бафает карту.

                core.Battle.CreateCard(team, c);

                summonedSlot.RechargeCard();
                RemoveBuff(summonedSlot, "SummonCard");
                AddEffectToSlot(c.Effect, numSlot, team);
                //Добавить новые ээфект от вызова карты после удаления старых
                ///Где то тут 
                return true;
            }


            return false;
        }
        private Card BuffCard(Card c, List<SlotSpellStage> effects)
        {
            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i].Event == "SummonCard")
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
        public void RemoveBuff(Slot slot,string Trigger)
        {
            switch(Trigger)
            {
                case "ReloadCard":
                    {
                        List<SlotSpellStage> stages = Slots[slot].Effects.FindAll(x => x.RemoveEvent == "ReloadCard");
                        foreach (StoreEffects item in Slots.Values)
                        {
                            for (int i = 0; i < stages.Count; i++)
                            {
                                item.Effects.RemoveAll(x => x.RefParent.Name == stages[i].RefParent.Name);
                            }
                        }
                        break;
                    }
                case "SummonCard":
                    {
                       List<SlotSpellStage> stages = Slots[slot].Effects.FindAll(x => x.RemoveEvent.Contains("SummonCard"));
                        foreach (StoreEffects item in Slots.Values)
                        {
                            for (int i = 0; i < stages.Count; i++)
                            {
                                item.Effects.RemoveAll(x => x.RefParent.Name == stages[i].RefParent.Name);
                            }
                        }
                        break;
                    }
                case "RechargeCard":
                    {
                        break;
                    }
            }
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
        private Slot[] SelectTargets(string Map, int NumSlot, int team)
        {
            if (NumSlot > 4 || NumSlot < 0) return null; //заглушка
            string[] splitedMap = Map.Split(' ');
            List<Slot> buffer = new List<Slot>();

            for (int i = 4 - NumSlot, j = 0; j < 5; i++, j++)
            {
                if (splitedMap[i] == "1")
                {
                    buffer.Add(FindSlotIndex(j, team));
                }
            }
            return buffer.ToArray();
        }

    }
    internal class StoreEffects
    {
       public  List<string> Tags { get; set; }
       public  List<SlotSpellStage> Effects { get; set; }
        public StoreEffects()
        {
            Tags = new List<string>();
            Effects = new List<SlotSpellStage>();
        }
    }
}
