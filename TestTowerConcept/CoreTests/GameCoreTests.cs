﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using CommonElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests
{
    [TestClass()]
    public class GameCoreTests
    {
        [TestMethod()]
        public void GameCoreTest()
        {
            Assert.IsNotNull(new GameCore());
        }

        [TestMethod()]
        public void UpdateTest()
        {
           GameCore core = new GameCore();
           core.Update();
        }

        [TestMethod()]
        public void GetDrawInfoTest()
        {
            GameCore core = new GameCore();
            core.Update();
            List<SceneItemInfo> l = core.GetDrawInfo();
            Assert.IsTrue(l.Count > 0);
        }

        [TestMethod()]
        public void GetPlayerInfoTest()
        {
            GameCore core = new GameCore();
            core.Update();
            List<PlayerInfo> l = core.GetPlayerInfo();
            Assert.IsTrue(l.Count > 0);
        }

        [TestMethod()]
        public void ExecuteCommandPutCardTest()
        {
            GameCore core = new GameCore();
            Assert.AreEqual(core.ExecuteCommand("PutCard "+ 1 + " 1"),"true");
            core.Update();
            Assert.AreEqual(core.ExecuteCommand("PutCard " + 1 + " 1"), "false");
        }
        [TestMethod()]
        public void ExecuteCommandFailTest()
        {
            GameCore core = new GameCore();
            Assert.AreEqual(core.ExecuteCommand("sadasdawdadsa"), "null");
        }
    }
}