using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{

    public interface IEffect
    {
        //Общее обновление эффекта
        void TikTak();
        object Update(object[] Objects);
    }

   public  interface IEffectSlot :IEffect
    {
        //Цели эффекта
        object[] GetTargets(Slot slot);
    }
    public interface IEffectUnit : IEffect
    {
        //Цели эффекта
        object[] GetTargets(Unit unit);
        //Реализует эффект для предоставленой карты
        Unit BuffUnit(Unit unit);
       
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
                object[] Targets = ((IEffectSlot)effect).GetTargets(slot);
                for (int i = 0; i < Targets.Length; i++)
                {
                    if(Targets[i] is Unit)
                    {
                        ((Unit)Targets[i]).ChangeStatus -= ((IEffectUnit)ListEffect[i]).Update;
                        ((Unit)Targets[i]).BuffUnit -= ((IEffectUnit)ListEffect[i]).BuffUnit;

                    }
                    if(Targets[i] is Slot)
                    {
                       ((Slot)Targets[i]).ChangeStatus += ((IEffectSlot)effect).Update;
                    }
                }
                ListEffect.Add(effect);
            }
        }
        internal void AddBuff(Unit unit)
        {
            //foreach (var effect in unit.TemplateCard.effects)
            //{
            //    object[] Targets = ((IEffectSlot)effect).GetTargets(slot);
            //    for (int i = 0; i < Targets.Length; i++)
            //    {
            //        if (Targets[i] is Unit)
            //        {
            //            ((Unit)Targets[i]).ChangeStatus -= ((IEffectUnit)ListEffect[i]).Update;
            //            ((Unit)Targets[i]).BuffUnit -= ((IEffectUnit)ListEffect[i]).BuffUnit;

            //        }
            //        if (Targets[i] is Slot)
            //        {
            //            ((Slot)Targets[i]).ChangeStatus += ((IEffectSlot)effect).Update;
            //            ((Slot)Targets[i]).BuffCard += ((IEffectSlot)effect).BuffCard;
            //        }
            //    }
            //    ListEffect.Add(effect);
            //}
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
                        var tempSlot = objectToDisconectEvents[i] as Unit;
                        tempSlot.ChangeStatus -= ((IEffectUnit)ListEffect[i]).Update;
                        tempSlot.BuffUnit -= ((IEffectUnit)ListEffect[i]).BuffUnit;
                    }
                    if (objectToDisconectEvents[i] is Slot)
                    {
                        var tempSlot = objectToDisconectEvents[i] as Slot;
                        tempSlot.ChangeStatus -= ((IEffectSlot)ListEffect[i]).Update;
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

    class SpellUpIntellect : Effect, IEffectSlot
    {
        public object[] GetTargets(Slot slot)
        {
            _CurrentTargets = _targetsHandler.GetTargets(slot);
            return _CurrentTargets;
        }
        public void TikTak()
        {

        }
        public object Update(object[] Objects)
        {
            if (!(Objects[0] is Slot)) return null;
            Slot slot = (Slot)Objects[0];
           
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
                case "BeforeSummoning":
                    {
                        Card card = Objects[1] as Card;
                        card.Intellect++;
                        return card;
                    }
                case "AfterSummoning":
                {
                        Unit unit = Objects[1] as Unit;
                        return unit;
                }
                case "Reloading":
                    {

                        break;
                    }
            }
            return null;
        }
        public void Remove()
        {
            _RemoveFlag = true;
        }
    }
}
