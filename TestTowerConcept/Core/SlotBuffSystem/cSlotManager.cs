using System.Collections.Generic;
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
        
    }
    internal class StoreEffects
    {
       public  List<string> Tags { get; set; }
       public  List<Effect> Effects { get; set; }
        public StoreEffects()
        {
            Tags = new List<string>();
            Effects = new List<Effect>();
        }
    }
}