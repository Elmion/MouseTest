using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
   public class Game
    {
       public List<Slot> Slots = new List<Slot>();
       public List<Unit> Units = new List<Unit>();
       internal readonly EffectsManager effectManager = new EffectsManager();
       public Game()
        {
            Card m = new Mage();
            Slots.Add(new Slot(this));
            Slots[0].SetCard(m);
            Slots[0].SetStatus(new Stay(Slots[0]));
            Slots[0].SummonCard();
            effectManager.Update();
            Slots[0].SummonCard();
        }
    }
}
