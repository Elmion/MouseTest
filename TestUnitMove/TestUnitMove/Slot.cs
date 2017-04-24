using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
   public class Slot
    {
       public Action<Slot> ChangeStatus;
       public Func<Card,Card> BuffCard;
       public  Card TemplateCard;

        public IStatus Status { get; set; }
        public IStatus PreveriosStatus { get; set; }

        private Game _parentGame;
        public Game Game { get { return _parentGame; } }

        public Slot(Game game)
        {
            _parentGame = game;
        }
        public void SetCard(Card card)
        {
            TemplateCard = card;
            TemplateCard.ActivateEvents(this);
        }
        public void SetStatus(IStatus status)
        {
            if(ChangeStatus != null)
                           ChangeStatus(this);
        }
        public void Recharge()
        {
            SetStatus(new Recharging(this));
        }
        public void SummonCard()
        {
            SetStatus(new Summoning(this));

            Card summoningCard = TemplateCard.Clone();
            if (BuffCard != null) 
                 summoningCard = BuffCard(summoningCard);

            Recharge();
        }
        public void Update()
        {

        }

    }
    public interface IStatus
    {

    }
    class Recharging : IStatus
    {
        private Slot _slot;

        public Recharging(Slot slot)
        {
            _slot = slot;
            slot.PreveriosStatus = slot.Status;
            slot.Status = this;
        }

    }
    class Stay : IStatus
    {
        private Slot _slot;

        public Stay(Slot slot)
        {
            _slot = slot;
            slot.PreveriosStatus = slot.Status;
            slot.Status = this;
        }

    }
    class Summoning : IStatus
    {
        private Slot _slot;

        public Summoning(Slot slot)
        {
            _slot = slot;
            slot.PreveriosStatus = slot.Status;
            slot.Status = this;
        }

    }
    class Reloading : IStatus
    {
        private Slot _slot;

        public Reloading(Slot slot)
        {
            _slot = slot;
            slot.PreveriosStatus = slot.Status;
            slot.Status = this;
        }

    }


}
