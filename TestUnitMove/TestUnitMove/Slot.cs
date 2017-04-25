using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
   public class Slot
    {
        public Func< object[] ,object> ChangeStatus;
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
        public void Recharge()
        {
            new Recharging(this);
            ChangeStatus(new object[] { this });
        }
        public void SummonCard()
        {
            new BeforeSummoning(this);

            Card summoningCard = TemplateCard.Clone();
            if (ChangeStatus != null) 
                 summoningCard = (Card)ChangeStatus(new object[] { this, summoningCard });

            new AfterSummoning(this);
            //изменение юнита после вызова.//Иницилизация начальных бафов и механик юнита.
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
    class AfterSummoning : IStatus
    {
        private Slot _slot;

        public AfterSummoning(Slot slot)
        {
            _slot = slot;
            slot.PreveriosStatus = slot.Status;
            slot.Status = this;
        }

    }
    class BeforeSummoning : IStatus
    {
        private Slot _slot;

        public BeforeSummoning(Slot slot)
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
