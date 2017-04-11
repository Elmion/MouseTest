using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests
{
    [TestClass()]
    public class BattleFieldTests
    {
        [TestMethod()]
        public void BattleFieldTest()
        {
           Assert.IsNotNull(new BattleField());
        }

        [TestMethod()]
        public void BattleFieldAllMoveTest()
        {
            BattleField b = new BattleField();
            b.AllMove();
            
        }
        [TestMethod()]
        public void BattleFieldCreateCardTest()
        {
            BattleField b = new BattleField();
            b.CreateCard(1,new CommonElement.Mage());
        }
    }
}