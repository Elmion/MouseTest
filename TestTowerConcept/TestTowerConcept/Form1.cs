using System;
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
                PlayerCardsInSlot[i].InReload = false;
                PlayerCardsInSlot[i].card = pInfo[User].CardInSlots[i];
                PlayerCardsInSlot[i].Recharge = pInfo[User].CardStatus[i];
            }
            PutCard += CommandPutCard;
        }

        private void CommandPutCard(ucCard obj)
        {
            string CardName = obj.card.GetType().ToString().Split('.').Last<string>();
            core.ExecuteCommand("PutCard " + CardName + " " + User);
        }

        private void T_Tick(object sender, EventArgs e)
        {
            core.Update();
            List<PlayerInfo> pInfo = core.GetPlayerInfo();
            for (int i = 0; i < pInfo[User].CardInSlots.Count; i++)
            {
                PlayerCardsInSlot[i].card = pInfo[User].CardInSlots[i];
                PlayerCardsInSlot[i].Recharge = pInfo[User].CardStatus[i];
            }
            foreach (ucCard cardView in PlayerCardsInSlot) cardView.Update();
            ucFieldView1.Invalidate();
        }
    }
}
