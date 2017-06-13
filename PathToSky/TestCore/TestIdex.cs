using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathCore;
using System.Text;
using System.Collections.Generic;
using ViewGame;

namespace TestCore
{
    [TestClass]
   public class TestIdex
    {

        /// <summary>
        /// Простое создание ядра
        /// </summary>
        [TestMethod]
        public void TestIndex()
        {
            FieldIndex x = new FieldIndex();
            Assert.AreEqual(false, x.Contain("01010101", 0, x.root, true));
            Assert.AreEqual(true, x.Contain("01010101", 0, x.root, true));
            Assert.AreEqual(false, x.Contain("00010101", 0, x.root, true));
            Assert.AreEqual(true, x.Contain("00010101", 0, x.root, true));
            Assert.AreEqual(false, x.Contain("00010001", 0, x.root, true));
            Assert.AreEqual(true, x.Contain("00010001", 0, x.root, true));
        }
    }
}
