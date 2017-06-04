using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathCore;
using System.Text;
namespace TestCore
{
    [TestClass]
    public class CoreDataTest
    {
        #region RefreshCuplesData()
        /// <summary>
        /// Проверка рефреша пар
        /// </summary>
        [TestMethod]
        public void TestRefreshPairStandardField()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001002001" + "001002001" + "300500050");
            data.RefreshCuplesData();
            Assert.AreEqual(data.CurrentPairList.Count, 5);
            Assert.AreEqual(data.CurrentPairList[0].NumFirst.Value, '1');
            Assert.AreEqual(data.CurrentPairList[0].NumSecond.Value, '1');
            Assert.AreEqual(data.CurrentPairList[0].NumFirst.Position, 8);
            Assert.AreEqual(data.CurrentPairList[0].NumSecond.Position, 11);
            Assert.AreEqual(data.CurrentPairList[1].NumFirst.Value, '1');
            Assert.AreEqual(data.CurrentPairList[1].NumSecond.Value, '1');
            Assert.AreEqual(data.CurrentPairList[1].NumFirst.Position, 2);
            Assert.AreEqual(data.CurrentPairList[1].NumSecond.Position, 11);
            Assert.AreEqual(data.CurrentPairList[2].NumFirst.Value, '2');
            Assert.AreEqual(data.CurrentPairList[2].NumSecond.Value, '2');
            Assert.AreEqual(data.CurrentPairList[2].NumFirst.Position, 5);
            Assert.AreEqual(data.CurrentPairList[2].NumSecond.Position, 14);
            Assert.AreEqual(data.CurrentPairList[3].NumFirst.Value, '1');
            Assert.AreEqual(data.CurrentPairList[3].NumSecond.Value, '1');
            Assert.AreEqual(data.CurrentPairList[3].NumFirst.Position, 8);
            Assert.AreEqual(data.CurrentPairList[3].NumSecond.Position, 17);
            Assert.AreEqual(data.CurrentPairList[4].NumFirst.Value, '5');
            Assert.AreEqual(data.CurrentPairList[4].NumSecond.Value, '5');
            Assert.AreEqual(data.CurrentPairList[4].NumFirst.Position, 21);
            Assert.AreEqual(data.CurrentPairList[4].NumSecond.Position, 25);
        }

        /// <summary>
        /// Проверка на уророченом с конца поле
        /// </summary>
        [TestMethod]
        public void TestRefreshPairCuteField()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001002001" + "001002001" + "344");
            data.RefreshCuplesData();
            Assert.AreEqual(data.CurrentPairList.Count, 5);
            Assert.AreEqual(data.CurrentPairList[0].NumFirst.Value, '1');
            Assert.AreEqual(data.CurrentPairList[0].NumSecond.Value, '1');
            Assert.AreEqual(data.CurrentPairList[0].NumFirst.Position, 8);
            Assert.AreEqual(data.CurrentPairList[0].NumSecond.Position, 11);
            Assert.AreEqual(data.CurrentPairList[1].NumFirst.Value, '1');
            Assert.AreEqual(data.CurrentPairList[1].NumSecond.Value, '1');
            Assert.AreEqual(data.CurrentPairList[1].NumFirst.Position, 2);
            Assert.AreEqual(data.CurrentPairList[1].NumSecond.Position, 11);
            Assert.AreEqual(data.CurrentPairList[2].NumFirst.Value, '2');
            Assert.AreEqual(data.CurrentPairList[2].NumSecond.Value, '2');
            Assert.AreEqual(data.CurrentPairList[2].NumFirst.Position, 5);
            Assert.AreEqual(data.CurrentPairList[2].NumSecond.Position, 14);
            Assert.AreEqual(data.CurrentPairList[3].NumFirst.Value, '1');
            Assert.AreEqual(data.CurrentPairList[3].NumSecond.Value, '1');
            Assert.AreEqual(data.CurrentPairList[3].NumFirst.Position, 8);
            Assert.AreEqual(data.CurrentPairList[3].NumSecond.Position, 17);
            Assert.AreEqual(data.CurrentPairList[4].NumFirst.Value, '4');
            Assert.AreEqual(data.CurrentPairList[4].NumSecond.Value, '4');
            Assert.AreEqual(data.CurrentPairList[4].NumFirst.Position, 19);
            Assert.AreEqual(data.CurrentPairList[4].NumSecond.Position, 20);
        }

        /// <summary>
        /// Проверка на поле в одну строку
        /// </summary>
        [TestMethod]
        public void TestRefreshPairOneStringField()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001001");
            data.RefreshCuplesData();
            Assert.AreEqual(data.CurrentPairList.Count, 1);
            Assert.AreEqual(data.CurrentPairList[0].NumFirst.Value, '1');
            Assert.AreEqual(data.CurrentPairList[0].NumSecond.Value, '1');
            Assert.AreEqual(data.CurrentPairList[0].NumFirst.Position, 2);
            Assert.AreEqual(data.CurrentPairList[0].NumSecond.Position, 5);
        }

        /// <summary>
        /// Проверка на поле в одну строку
        /// </summary>
        [TestMethod]
        public void TestRefreshPairVerticalPlusHorizontal()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("000000010"+ "000000010" + "000000000" );
            data.RefreshCuplesData();
            Assert.AreEqual(data.CurrentPairList.Count, 1);
        }

        #endregion
        #region GetPairAtPosition(int FirstPosition, int SecondPosition)
        /// <summary>
        /// Возращает пару
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPosition()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001001");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(2, 5);
            Assert.IsNotNull(p);
            Assert.AreEqual(p.NumFirst.Position, 2);
            Assert.AreEqual(p.NumSecond.Position, 5);
        }
        /// <summary>
        /// Взятие пары .. неверный ввод
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPositionFail()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001001");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(2, 4);
            Assert.IsNull(p);
        }
        /// <summary>
        /// Взятие  пары вертикальный позиция пары
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPositionVertical()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001002001" + "001002001" + "344");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(5, 14);
            Assert.IsNotNull(p);
            Assert.AreEqual(p.NumFirst.Position, 5);
            Assert.AreEqual(p.NumSecond.Position, 14);
        }
        /// <summary>
        /// Взятие  пары вертикальный позиция пары .. неверный ввод
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPositionVerticalFail()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001002001" + "001002002" + "344");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(5, 17);
            Assert.IsNull(p);
        }
        #endregion
        #region GetPairAtPosition(int x1, int y1, int x2, int y2)
        /// <summary>
        /// Взятие  пары вертикальный позиция пары
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPositionXYVertical()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001002001" + "001002001" + "344");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(5, 0, 5, 1);
            Assert.IsNotNull(p);
            Assert.AreEqual(p.NumFirst.Position, 5);
            Assert.AreEqual(p.NumSecond.Position, 14);
        }
        /// <summary>
        /// Взятие  пары вертикальный позиция пары .. неверный ввод
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPositionXYVerticalFail()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001002001" + "001002002" + "344");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(5, 0, 8, 1);
            Assert.IsNull(p);
        }

        /// <summary>
        /// Возращает пару
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPositionXYinOneLine()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001001");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(2, 0, 5, 0);
            Assert.IsNotNull(p);
            Assert.AreEqual(p.NumFirst.Position, 2);
            Assert.AreEqual(p.NumSecond.Position, 5);
        }
        /// <summary>
        /// Взятие пары .. неверный ввод
        /// </summary>
        [TestMethod]
        public void TestGetPairAtPositionInOneLineFail()
        {
            CoreData data = new CoreData();
            data.GameField = new StringBuilder("001001");
            data.RefreshCuplesData();
            Pair p = data.GetPairAtPosition(2, 0, 4, 0);
            Assert.IsNull(p);
        }
        #endregion


    }
}
