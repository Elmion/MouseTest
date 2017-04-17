using System.Collections.Generic;
using CommonElement;
using System.Reflection;
using System;
namespace Core
{
    internal class cSlotManager
    {
        private Player player1;
        private Player player2;
        Dictionary<Slot, StoreEffects> Slots;
        public cSlotManager(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            Slots = new Dictionary<Slot, StoreEffects>();
            for (int i = 0; i < player1.Slots.Count; i++)
            {
                Slots.Add(player1.Slots[i], new StoreEffects());
                Slots[player1.Slots[i]].Tags.Add("p1");
                Slots.Add(player2.Slots[i], new StoreEffects());
                Slots[player2.Slots[i]].Tags.Add("p2");
            }

        }
        public Card CalcEffect(Slot slot, Card card)
        {
            for (int i = 0; i < Slots[slot].Effects.Count; i++)
            {
                ParameterInfo[] pInfo = Slots[slot].Effects[i].GetParameters();
                Slots[slot].Effects[i].Invoke(null,new object[] { card, "Attack", 40});
            }

        }
        public void AddEffectToSlot(String methodNameEffect,Slot slot)
        {
           MethodInfo info = typeof(Effect).GetMethod(methodNameEffect);
        }
    }
    internal class StoreEffects
    {
       public  List<string> Tags { get; set; }
       public  List<MethodInfo> Effects { get; set; }
        public StoreEffects()
        {
            Tags = new List<string>();
            Effects = new List<MethodInfo>();
        }
    }
}