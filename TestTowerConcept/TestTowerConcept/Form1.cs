﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using CommonElement;

namespace TestTowerConcept
{
    public partial class Form1 : Form
    {
        List<Monster> monsters;
        List<ucCard> PlayerCardsInSlot;
        Timer t;
        GameCore core;
        public int User = 0; // ставим польтеля 0 если первый и 1 если второй
        public Action<ucCard> PutCard;
        public Action<ucCard> ReloadCard;
        public Action<ucCard> AddCristall;
        public Action<ucCard> RemoveCristall;
        public Action<ucCard,ucCard> ReplaceCristall;

        public Form1()
        {
            InitializeComponent();
            core = new GameCore();
            ucFieldView1.Init(core);
            t = new Timer();
            t.Interval = 30;
            t.Tick += T_Tick;t.Start();
            List<PlayerInfo> pInfo = core.GetPlayerInfo();
            PlayerCardsInSlot = new List<ucCard>();
            //грузим первого игрока
            for (int i = 0; i < pInfo[User].CardInSlots.Count; i++)
            {
                PlayerCardsInSlot.Add(new ucCard());
                PlayerCardsInSlot[i].Parent = this;
                PlayerCardsInSlot[i].Location = new Point(20+i * 95, 160);
                PlayerCardsInSlot[i].card = pInfo[User].CardInSlots[i];
                PlayerCardsInSlot[i].Recharge = pInfo[User].CardStatus[i];
            }
            PutCard += CommandPutCard;
            ReloadCard += CommandRelodCard;
            AddCristall += CommandAddCristall;
            RemoveCristall += CommandRemoveCristall;
            ReplaceCristall += CommandReplaceCristall;
    }

        private void CommandAddCristall(ucCard obj)
        {
            int index = PlayerCardsInSlot.FindIndex(x => x == obj);
            string result = core.ExecuteCommand("AddCristall " + index + " 1");
            if (result == "false")//откатываем
            {
                ucCristalCollector1.CristalCount++;
                obj.Cristall--;
            }
        }
        private void CommandRemoveCristall(ucCard obj)
        {
            int index = PlayerCardsInSlot.FindIndex(x => x == obj);
            string result = core.ExecuteCommand("RemoveCristall " + index + " 1");
            if (result == "false")//откатываем
            {

                obj.Cristall++;
            }
        }
        private void CommandReplaceCristall(ucCard source,ucCard reciver)
        {
            int index1 = PlayerCardsInSlot.FindIndex(x => x == source);
            int index2 = PlayerCardsInSlot.FindIndex(x => x == reciver);
            string result = core.ExecuteCommand("ReplaceCristall " + index1 +" " + index2 + " 1");
            if (result == "false")//откатываем
            {
                source.Cristall++;
                reciver.Cristall--;
            }

        }
        private void CommandRelodCard(ucCard obj)
        {
          int index =  PlayerCardsInSlot.FindIndex( x => x == obj);
            core.ExecuteCommand("ReloadCard " + index + " 1");
        }
        private void CommandPutCard(ucCard obj)
        {
            int SlotIndex = PlayerCardsInSlot.IndexOf(obj);
            core.ExecuteCommand("PutCard " + SlotIndex + " " + User);
        }
        private void T_Tick(object sender, EventArgs e)
        {
            core.Update();
            List<PlayerInfo> pInfo = core.GetPlayerInfo();
            ucCristalCollector1.CristalCount = pInfo[User].Cristall;
            for (int i = 0; i < pInfo[User].CardInSlots.Count; i++)
            {
                PlayerCardsInSlot[i].card =  pInfo[User].CardInSlots[i];
                PlayerCardsInSlot[i].Recharge = pInfo[User].CardStatus[i];
                PlayerCardsInSlot[i].Effects = pInfo[User].EffectInfo[i];
            }
            foreach (ucCard cardView in PlayerCardsInSlot) cardView.Update();
            ucFieldView1.Invalidate();
            ucCristalCollector1.Update();
        }
    }
}
