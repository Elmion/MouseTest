using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonElement;

namespace Core.Tests
{
    [TestClass()]
    public class BattleFieldTests
    {
        [TestMethod()]
        public void BattleFieldTest()
        {
            CardsBase.Instance.LoadCards();
           Assert.IsNotNull(new BattleField());
        }

        [TestMethod()]
        public void BattleFieldAllMoveTest()
        {
            CardsBase.Instance.LoadCards();
            BattleField b = new BattleField();
            b.AllMove();
            
        }
        [TestMethod()]
        public void BattleFieldCreateCardTest()
        {
            CardsBase.Instance.LoadCards();
            BattleField b = new BattleField();
            b.CreateCard(1,CommonElement.CardsBase.Instance.GetClone("Mage"));
        }
    }
}