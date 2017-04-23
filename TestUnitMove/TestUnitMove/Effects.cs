using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
   public  interface IEffect
    {
        object[] GetTargets(Slot slot);
        Card BuffCard(Card card);
        void Update(Slot slot);
        void Update();
    }
    public interface ITarget
    {
        object[] GetTargets(Slot slot);
    }
    class EffectsManager
    {
        List<IEffect> ListEffect;

        internal void AddBuff(Slot slot)
        {
            foreach (var effect in slot.TemplateCard.effects)
            {
                object[] Targets = effect.GetTargets(slot);
                for (int i = 0; i < Targets.Length; i++)
                {
                    if(Targets[i] is Unit)
                    {

                    }
                    if(Targets[i] is Slot)
                    {
                        slot.ChangeStatus += effect.Update;
                        slot.BuffCard += effect.BuffCard;
                    }
                }
            } 
        }
        internal void Update()
        {
            foreach (var item in ListEffect)
            {
                item.Update();
            }
        }
    }
    public abstract class Effect
    {
      internal virtual ITarget _targetsHandler { get; set; }
    }

    class SpellUpIntellect : Effect, IEffect
    {
        //Подумать как сделать стадии
        public Card BuffCard(Card card)
        {
            card.Intellect++;
            return card;
        }
        public object[] GetTargets(Slot slot)
        {
            return _targetsHandler.GetTargets(slot);
        }
        public void Update()
        {

        }
        public void Update(Slot slot)
        {
            string status = slot.Status.GetType().ToString().Split('.').Last();
            switch (status)
            {
                case "Recharging":
                    {
                        
                        break;
                    }
                case "Stay":
                    {

                        break;
                    }
                case "Summoning":
                    {

                        break;
                    }
                case "Reloading":
                    {

                        break;
                    }


            }
        }
    }
}
