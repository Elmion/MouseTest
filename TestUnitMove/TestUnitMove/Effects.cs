using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
   public  interface IEffect
    {
        //Цели эффекта
        object[] GetTargets(Slot slot);
        //Реализует эффект для предоставленой карты
        Card BuffCard(Card card);
        //Вызов при любом изменении статуса слота
        void Update(Slot slot);
        //Общее обновление эффекта
        void TikTak();
    }
    public interface ITarget
    {
        object[] GetTargets(Slot slot);
    }
    class EffectsManager
    {
        List<IEffect> ListEffect = new List<IEffect>();

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
                ListEffect.Add(effect);
            }
        }
        internal void Update()
        {
            foreach (var item in ListEffect)
            {
                item.TikTak();
            }
            //отлючаем эффекты которые помечены к удалению
            for (int i = 0; i <  ListEffect.Count; i++)
            {
                 var tempEffect = (Effect)ListEffect[i];
                 if (tempEffect._RemoveFlag == false) continue;

                var objectToDisconectEvents = tempEffect._CurrentTargets;
                for (int j = 0; j < objectToDisconectEvents.Length; j++)
                {
                    if (objectToDisconectEvents[i] is Unit)
                    {

                    }
                    if (objectToDisconectEvents[i] is Slot)
                    {
                        var tempSlot = objectToDisconectEvents[i] as Slot;
                        tempSlot.ChangeStatus -= ListEffect[i].Update;
                        tempSlot.BuffCard -= ListEffect[i].BuffCard;
                    }
                } 
            }
            //сносим эффекты
            ListEffect.RemoveAll(x => ((Effect)x)._RemoveFlag == true);
        }
        internal object[] GetSlotEffects(Slot slot)
        {
            Delegate[] list = slot.ChangeStatus.GetInvocationList();
            object[] outArr = new object[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                outArr[i] = list[i].Target; 
            }
            return outArr;
        }

    }
    public abstract class Effect
    {
        internal virtual bool _RemoveFlag { get; set; }
        internal virtual ITarget _targetsHandler { get; set; }
        internal virtual object[] _CurrentTargets { get; set; }
        public Effect()
        {
            _RemoveFlag = false;
        }
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
            _CurrentTargets = _targetsHandler.GetTargets(slot);
            return _CurrentTargets;
        }
        public void TikTak()
        {

        }
        public void Update(Slot slot)
        {
            string status = slot.Status.GetType().ToString().Split('.').Last();
            switch (status)
            {
                case "Recharging":
                    {
                        Remove();
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
        public void Remove()
        {
            _RemoveFlag = true;
        }
    }
}
