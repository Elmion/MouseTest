﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathCore;
using System.Text;
using System.Collections.Generic;
namespace TestCore
{
    [TestClass]
    public class CoreTest
    {

        /// <summary>
        /// Простое создание ядра
        /// </summary>
        [TestMethod]
        public void TestCreateCore()
        {
            Core c = new Core();
            Assert.IsNotNull(c);
        }
        #region cmdGenerateField

        [TestMethod]
        public void TestCoreGenerateSetupField()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020000300" + "020000000"));
            Assert.AreEqual(c.Field, "020000300" + "020000300" + "020000000");
        }
        [TestMethod]
        public void TestCoreGenerateRandomField()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField());
            Assert.AreNotEqual(c.Field, "");
        }
        [TestMethod]
        public void TestCoreGenerateFieldUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020000300" + "020000000"));
            c.Run(new cmdGenerateField());
            c.Undo();
            Assert.AreEqual(c.Field, "020000300" + "020000300" + "020000000");
        }
        /// <summary>
        /// Откатываем пле сразу же после создания
        /// </summary>
        [TestMethod]
        public void TestCoreGenerateFieldInstanceUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020000300" + "020000000"));
            c.Undo();
            Assert.AreEqual(c.Field, "");
        }
        #endregion
        #region cmdDeletePair
        /// <summary>
        /// Удаление пары отмена
        /// </summary>
        [TestMethod]
        public void TestcmdDeletePair()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020000300" + "020000000"));
            c.Run(new cmdDeletePair(1, 10));
            Assert.AreEqual(c.Field, "000000300" + "000000300" + "020000000");
        }
        /// <summary>
        /// Удаление неверной пары
        /// </summary>
        [TestMethod]
        public void TestcmdDeletePairFalse()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020000300" + "020000000"));
            Assert.AreEqual(null, c.Run(new cmdDeletePair(1, 9)));
        }
        /// <summary>
        /// Удаление пары, отмена
        /// </summary>
        [TestMethod]
        public void TestcmdDeletePairUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020000300" + "020000000"));
            c.Run(new cmdDeletePair(1, 10));
            c.Undo();
            Assert.AreEqual(c.Field, "020000300" + "020000300" + "020000000");
        }
        /// <summary>
        /// Удаление пары c крайней позиции
        /// </summary>
        [TestMethod]
        public void TestcmdDeletePairConnerPosition()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020000301" + "020000001"));
            c.Run(new cmdDeletePair(17, 26));
            Assert.AreEqual(c.Field, "020000300" + "020000300" + "020000000");
        }
        /// <summary>
        /// Удаление пары c крайней позиции в неполном ряду
        /// </summary>
        [TestMethod]
        public void TestcmdDeletePairConnerPositionNotFullRow()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020010301" + "02001"));
            c.Run(new cmdDeletePair(13, 22));
            Assert.AreEqual(c.Field, "020000300" + "020000301" + "02000");
        }
        /// <summary>
        /// Удаление пары c крайней позиции в неполном ряду c отменой
        /// </summary>
        [TestMethod]
        public void TestcmdDeletePairConnerPositionNotFullRowWithCancel()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "020010301" + "02001"));
            c.Run(new cmdDeletePair(13, 22));
            c.Undo();
            Assert.AreEqual(c.Field, "020000300" + "020010301" + "02001");
        }
        #endregion
        #region cmdDeleteLine
        /// <summary>
        /// простое удаление линии
        /// </summary>
        [TestMethod]
        public void TestDeleteLineSimple()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000000000" + "020000000"));
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(c.Field, "020000300" + "020000000");
        }

        /// <summary>
        /// простое удаление линии c откатом
        /// </summary>
        [TestMethod]
        public void TestDeleteLineSimpleWithUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000000000" + "020000000"));
            c.Run(new cmdDeleteLine());
            c.Undo();
            Assert.AreEqual(c.Field, "020000300" + "000000000" + "020000000");
        }
        /// <summary>
        /// простое удаление последней урезаной линии
        /// </summary>
        [TestMethod]
        public void TestDeleteCutLine()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000001000" + "00000"));
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(c.Field, "020000300" + "000001000" + "00000");
        }
        /// <summary>
        /// простое удаление последней урезаной линии c откатом
        /// </summary>
        [TestMethod]
        public void TestDeleteCutLineWithUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000001000" + "00000"));
            Assert.AreEqual(null, c.Run(new cmdDeleteLine()));

        }
        /// <summary>
        /// простое удаление 2х линий
        /// </summary>
        [TestMethod]
        public void TestDeleteTwoLine()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000000000" + "000001000" + "000000000" + "000001000"));
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(c.Field, "020000300" + "000001000" + "000001000");
        }
        /// <summary>
        /// простое удаление 2х линий с откатом и возвращает ли данные
        /// </summary>
        [TestMethod]
        public void TestDeleteTwoLineWithUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000000000" + "000001000" + "000000000" + "000001000"));
            object s = c.Run(new cmdDeleteLine());
            Assert.IsInstanceOfType(s, typeof(List<int>));
            c.Undo();
            Assert.AreEqual("020000300" + "000000000" + "000001000" + "000000000" + "000001000", c.Field);
        }
        /// <summary>
        /// Простой выйгрыш
        /// </summary>
        [TestMethod]
        public void TestDeleteLineWinPosition()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("000000"));
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(c.GameState, GameStates.GameWin);
        }
        /// <summary>
        /// Простой выйгрыш при одной полной и одной не полной
        /// </summary>
        [TestMethod]
        public void TestDeleteLineWinPositionTwoLine()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("000000000" + "000000"));
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(c.GameState, GameStates.GameWin);
        }
        /// <summary>
        /// Откат простого выйгрыша при одной полной и одной не полной
        /// </summary>
        [TestMethod]
        public void TestDeleteLineWinPositionTwoLineUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("000000000" + "000000"));
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(c.GameState, GameStates.GameWin);
            c.Undo();
            Assert.AreEqual("000000000" + "000000", c.Field);
            Assert.AreEqual(c.GameState, GameStates.Processed);
        }
        /// <summary>
        /// Простой выйгрыш отмена
        /// </summary>
        [TestMethod]
        public void TestDeleteLineWinPositionUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("000000"));
            Assert.AreEqual(c.GameState, GameStates.Processed);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(c.GameState, GameStates.GameWin);
            c.Undo();
            Assert.AreEqual("000000", c.Field);
            Assert.AreEqual(c.GameState, GameStates.Processed);
            //Проверяем что всё работает дальше
            c.Run(new cmdDeleteLine());
            //Если нормально должно быть так
            Assert.AreEqual(c.GameState, GameStates.GameWin);//Выйгрыш вернуло верно
            Assert.AreEqual("", c.Field);//раз пусто значит что то сделал
        }
        /// <summary>
        /// Неудаление
        /// </summary>
        [TestMethod]
        public void TestDeleteLineNullReturn()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("0001000"));
            object s = c.Run(new cmdDeleteLine());
            Assert.IsNull(s);
            Assert.AreEqual("0001000", c.Field);
        }
        /// <summary>
        /// Провека сдвига пар при удалении линий
        /// </summary>
        [TestMethod]
        public void TestDeleteLinePairCorrect()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000000000" + "020303000" + "000000000" + "000001000"));
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(19, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(21, c.CurrentPairs[1].NumFirst.Position);

            c.Run(new cmdDeleteLine());
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(10, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(12, c.CurrentPairs[1].NumFirst.Position);

        }

        /// <summary>
        /// Тест нужности удаления линии - вариант где нужно 
        /// </summary>
        [TestMethod]
        public void CheckPossibilityRemovalTrue()
        {
            CoreData c = new CoreData();
            c.GameField = new StringBuilder("020000300" + "000000000" + "020303000" + "000000000" + "000001000");
            c.RefreshCuplesData();
            Assert.AreEqual(true, new cmdDeleteLine().CheckPossibilityRemoval(c));
        }
        /// <summary>
        /// Тест нужности удаления линии - вариант где не нужно 
        /// </summary>
        [TestMethod]
        public void CheckPossibilityRemovalFasle()
        {
            CoreData c = new CoreData();
            c.GameField = new StringBuilder("020000300" + "020303000" + "000001000");
            c.RefreshCuplesData();
            Assert.AreEqual(false, new cmdDeleteLine().CheckPossibilityRemoval(c));
        }
        /// <summary>
        /// Провека сдвига назад при отмене
        /// </summary>
        [TestMethod]
        public void TestDeleteLinePairCorrectUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("020000300" + "000000000" + "020303000" + "000000000" + "000001000"));
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(19, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(21, c.CurrentPairs[1].NumFirst.Position);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(10, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(12, c.CurrentPairs[1].NumFirst.Position);
            c.Undo();
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(19, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(21, c.CurrentPairs[1].NumFirst.Position);
        }
        /// <summary>
        /// Провека сдвига назад при отмене при через строчном удалении
        /// </summary>
        [TestMethod]
        public void TestDeleteLinePairCorrectUndo2()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("200000300" + "000000000" + "200003000" + "000000000" + "300001000"));
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(0, c.CurrentPairs[0].NumFirst.Position);
            Assert.AreEqual(23, c.CurrentPairs[1].NumFirst.Position);
            Assert.AreEqual(18, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(36, c.CurrentPairs[1].NumSecond.Position);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(0, c.CurrentPairs[0].NumFirst.Position);
            Assert.AreEqual(14, c.CurrentPairs[1].NumFirst.Position);
            Assert.AreEqual(9, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(18, c.CurrentPairs[1].NumSecond.Position);
            c.Undo();
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(0, c.CurrentPairs[0].NumFirst.Position);
            Assert.AreEqual(23, c.CurrentPairs[1].NumFirst.Position);
            Assert.AreEqual(18, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(36, c.CurrentPairs[1].NumSecond.Position);
        }
        /// <summary>
        /// Провека сдвига назад при отмене при через строчном удалении
        /// </summary>
        [TestMethod]
        public void TestDeleteLinePairCorrectUndo3()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("000000000" + "020000300" + "020000003" + "000000000" + "300001000"));
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(10, c.CurrentPairs[0].NumFirst.Position);
            Assert.AreEqual(26, c.CurrentPairs[1].NumFirst.Position);
            Assert.AreEqual(19, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(36, c.CurrentPairs[1].NumSecond.Position);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(1, c.CurrentPairs[0].NumFirst.Position);
            Assert.AreEqual(17, c.CurrentPairs[1].NumFirst.Position);
            Assert.AreEqual(10, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(18, c.CurrentPairs[1].NumSecond.Position);
            c.Undo();
            Assert.AreEqual(2, c.CurrentPairs.Count);
            Assert.AreEqual('2', c.CurrentPairs[0].NumFirst.OrginChar);
            Assert.AreEqual('3', c.CurrentPairs[1].NumFirst.OrginChar);
            Assert.AreEqual(10, c.CurrentPairs[0].NumFirst.Position);
            Assert.AreEqual(26, c.CurrentPairs[1].NumFirst.Position);
            Assert.AreEqual(19, c.CurrentPairs[0].NumSecond.Position);
            Assert.AreEqual(36, c.CurrentPairs[1].NumSecond.Position);
        }
        #endregion
        #region Rewrite
        /// <summary>
        /// Простое перписывание
        /// </summary>
        [TestMethod]
        public void TestRewrite()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("000300000" + "020000300" + "02000"));
            c.Run(new cmdRewrite());
            Assert.AreEqual("000300000" + "020000300" + "020003232", c.Field);
            Assert.AreEqual(GameStates.Processed, c.GameState);
        }
        /// <summary>
        /// Переписывание откат
        /// </summary>
        [TestMethod]
        public void TestRewriteUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("000300000" + "020000300" + "02000"));
            c.Run(new cmdRewrite());
            Assert.AreEqual("000300000" + "020000300" + "020003232", c.Field);
            Assert.AreEqual(GameStates.Processed, c.GameState);
            c.Undo();
            Assert.AreEqual("000300000" + "020000300" + "02000", c.Field);
            Assert.AreEqual(GameStates.Processed, c.GameState);
        }
        /// <summary>
        /// Конец игры
        /// </summary>
        [TestMethod]
        public void TestRewriteOverRewrite()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333"));
            object r = c.Run(new cmdRewrite());
            Assert.AreEqual(GameStates.GameOver, c.GameState);
            Assert.AreEqual("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333", c.Field);
            Assert.AreEqual(GameStates.GameOver, (GameStates)r);
        }
        /// <summary>
        /// Конец игры фэйл .. отмена
        /// </summary>
        [TestMethod]
        public void TestRewriteOverRewriteUndo()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333"));
            c.Run(new cmdRewrite());
            Assert.AreEqual(GameStates.GameOver, c.GameState);
            Assert.AreEqual("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333", c.Field);
            c.Undo();
            Assert.AreEqual(GameStates.Processed, c.GameState);
            Assert.AreEqual("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333", c.Field);
        }
        #endregion
        #region Reset
        [TestMethod]
        public void TestReset()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333"));
            c.Run(new cmdRewrite());
            c.Run(new cmdRestartGame());
            Assert.AreEqual("", c.Field);
            Assert.AreEqual(GameStates.Processed, c.GameState);

        }
        [TestMethod]
        public void TestReset2()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333"));
            c.Run(new cmdRewrite());
            c.Run(new cmdGenerateField("000100000" + "000000000" + "000100000"));
            Assert.AreEqual("333333333" + "020000300" + "020000300" + "333333333" + "333333333" + "333333333" + "333333333", c.Field);
            Assert.AreEqual(GameStates.GameOver, c.GameState);
            c.Run(new cmdRestartGame());
            Assert.AreEqual("", c.Field);
            Assert.AreEqual(GameStates.Processed, c.GameState);
            c.Run(new cmdGenerateField("000100000" + "000000000" + "000100000"));
            Assert.AreEqual("000100000" + "000000000" + "000100000", c.Field);
        }
        #endregion

        [TestMethod]
        public void TestGameEmulation()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("101202303" + "303202303"));
            c.Run(new cmdDeletePair(0, 2));
            Assert.AreEqual("000202303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(3, 12));
            Assert.AreEqual("000002303" + "303002303", c.Field);
            c.Run(new cmdDeletePair(8, 9));
            Assert.AreEqual("000002300" + "003002303", c.Field);
            c.Undo();
            Assert.AreEqual("000002303" + "303002303", c.Field);
            c.Undo();
            Assert.AreEqual("000202303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(3, 5));
            Assert.AreEqual("000000303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(6, 8));
            Assert.AreEqual("000000000" + "303202303", c.Field);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual("303202303", c.Field);
            c.Undo();
            Assert.AreEqual("000000000" + "303202303", c.Field);
            c.Undo();
            Assert.AreEqual("000000303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(8, 9));
            Assert.AreEqual("000000300" + "003202303", c.Field);
            c.Run(new cmdDeletePair(6, 15));
            Assert.AreEqual("000000000" + "003202003", c.Field);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual("003202003", c.Field);
            c.Run(new cmdRewrite());
            Assert.AreEqual("003202003" + "3223", c.Field);
            c.Undo();
            Assert.AreEqual("003202003", c.Field);
            c.Run(new cmdRewrite());
            Assert.AreEqual("003202003" + "3223", c.Field);
            c.Run(new cmdDeletePair(3, 5));
            Assert.AreEqual("003000003" + "3223", c.Field);
            c.Run(new cmdDeletePair(2, 8));
            Assert.AreEqual("000000000" + "3223", c.Field);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual("3223", c.Field);
            c.Run(new cmdDeletePair(1, 2));
            Assert.AreEqual("3003", c.Field);
            c.Run(new cmdDeletePair(0, 3));
            Assert.AreEqual("0000", c.Field);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual(GameStates.GameWin, c.GameState);
            object s = c.Run(new cmdDeleteLine());
            Assert.AreEqual(GameStates.GameWin, (GameStates)s);
            c.Run(new cmdRestartGame());
            Assert.AreEqual(GameStates.Processed, c.GameState);
            c.Run(new cmdGenerateField("101202303" + "303202303"));
            Assert.AreEqual("101202303" + "303202303", c.Field);
        }
        [TestMethod]
        public void TestGameEmulation2()
        {
            Core c = new Core();
            c.Run(new cmdGenerateField("101202303" + "303202303"));
            c.Run(new cmdDeletePair(0, 2));
            Assert.AreEqual("000202303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(3, 12));
            Assert.AreEqual("000002303" + "303002303", c.Field);
            c.Run(new cmdDeletePair(8, 9));
            Assert.AreEqual("000002300" + "003002303", c.Field);
            c.Undo();
            Assert.AreEqual("000002303" + "303002303", c.Field);
            c.Undo();
            Assert.AreEqual("000202303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(3, 5));
            Assert.AreEqual("000000303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(6, 8));
            Assert.AreEqual("000000000" + "303202303", c.Field);
            c.Run(new cmdDeleteLine());
            Assert.AreEqual("303202303", c.Field);
            c.Undo();
            Assert.AreEqual("000000000" + "303202303", c.Field);
            c.Undo();
            Assert.AreEqual("000000303" + "303202303", c.Field);
            c.Run(new cmdDeletePair(8, 9));
            Assert.AreEqual("000000300" + "003202303", c.Field);
            c.Run(new cmdRewrite());
            Assert.AreEqual("000000300" + "003202303" + "332233", c.Field);
            c.Run(new cmdRewrite());
            Assert.AreEqual("000000300" + "003202303" + "332233332" + "233332233", c.Field);
            c.Run(new cmdRewrite());
            Assert.AreEqual("000000300" + "003202303" + "332233332" + "233332233" + "332233332" + "233332233" + "332233", c.Field);
            c.Run(new cmdRewrite());
            Assert.AreEqual("000000300"
                          + "003202303"
                          + "332233332"
                          + "233332233"
                          + "332233332"
                          + "233332233"
                          + "332233332"
                          + "233332233"
                          + "332233332"
                          + "233332233"
                          + "332233332"
                          + "233332233", c.Field);
            c.Run(new cmdRewrite());
            Assert.AreEqual(GameStates.GameOver, c.GameState);
            object s = c.Run(new cmdDeleteLine());
            Assert.AreEqual(GameStates.GameOver, (GameStates)s);
            c.Run(new cmdRestartGame());
            Assert.AreEqual(GameStates.Processed, c.GameState);
            c.Run(new cmdGenerateField("101202303" + "303202303"));
            Assert.AreEqual("101202303" + "303202303", c.Field);

        }
        [TestMethod]
        public void TestGameNullField()
        {
            Core c = new Core();
            c.Run(new cmdRestartGame());
            c.Run(new cmdGenerateField("000000303" + "303202303"));
            c.Undo();
        }
    }



}
