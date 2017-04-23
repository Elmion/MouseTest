using System;
using System.Collections.Generic;

namespace TestUnitMove
{
    public class Card
    {

        public int Intellect;

        public List<IEffect> effects = new List<IEffect>();

        internal void ActivateEvents(Slot slot)
        {
            slot.Game.effectManager.AddBuff(slot);
        }

        internal Card Clone()
        {
            return new Mage();
        }
    }
    public class Mage : Card
    {

        public Mage() : base()
        {
            // это нафиг убратьь и сдеать Карты основными путём сборки
            Intellect = 0;
            SpellUpIntellect s = new SpellUpIntellect();
            s._targetsHandler = new SelectThisSlot();
            effects.Add(s);

        }
    }
    public class SelectThisSlot : ITarget
    {
        public object[] GetTargets(Slot slot)
        {
            return new object[] { slot }; 
        }
    }
}
