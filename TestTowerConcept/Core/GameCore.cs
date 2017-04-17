using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CommonElement;

namespace Core
{
    public class GameCore
    {
        public static readonly Random rnd = new Random();
        internal BattleField Battle;
        internal Player Player1;
        internal Player Player2;
        internal cSlotManager slotManager; 
        public GameCore()
        {
            CardsBase.Instance.LoadCards();
            Player1 = new Player(0,this);
            Player2 = new Player(1,this);
            slotManager = new cSlotManager(Player1,Player2);
            Battle = new BattleField();
        }
       public void Update()
        {
            Battle.AllMove();
            Player1.Update();
            Player2.Update();
        }
        
       public List<SceneItemInfo> GetDrawInfo()
        {
            List<SceneItemInfo> outList = new List<SceneItemInfo>();
            foreach (cUnit item in Battle.Units)
            {
                SceneItemInfo s = new SceneItemInfo();
                s.NameCommonObject = item.FreezedCard.Name;
                s.Team = item.Team;
                s.PositionX = item.PointPosition.X;
                s.PositionY = item.PointPosition.Y;
                s.Bounds = item.Rect;
                outList.Add(s);
            }
            return outList;
        }
        public List<PlayerInfo> GetPlayerInfo()
        {
            List<PlayerInfo> ListOut = new List<PlayerInfo>();
            PlayerInfo p1 = new PlayerInfo();
            PlayerInfo p2 = new PlayerInfo();
            p1.Cristall = Player1.Cristal.Count;
            p2.Cristall = Player2.Cristal.Count;
            for (int i = 0; i < Player1.Slots.Count; i++)
            {
                p1.CardInSlots.Add(Player1.Slots[i].CardName);
                p2.CardInSlots.Add(Player2.Slots[i].CardName);

                if (Player1.Slots[i].ReloadRequest) p1.CardStatus.Add(-1);
                else
                {
                    p1.CardStatus.Add(Player1.Slots[i].CurrentRechargeTime);
                }
                if (Player2.Slots[i].ReloadRequest) p2.CardStatus.Add(-1);
                else
                {
                    p2.CardStatus.Add(Player2.Slots[i].CurrentRechargeTime);
                }

            }
            ListOut.Add(p1);
            ListOut.Add(p2);
            return ListOut;
        }
        public string ExecuteCommand(string  command)
        {
            string[] splitedCommand = command.Split(' ');
            switch(splitedCommand[0])
            {
                //PutCard 2 1 - первый вызывает карту из 2го слота
                case "PutCard":
                    {
                        int numSlot;
                        if (int.TryParse(splitedCommand[1], out numSlot))
                        {
                            string v = Player1.PutCard(numSlot).ToString().ToLower();
                            return v;
                        }
                        return "false";
                    }
                //Перегружаем карту 1 1
                case "ReloadCard":
                    {
                        Player1.ChangeCardsInSlot(int.Parse(splitedCommand[1]));
                        return "true";
                    }
                //PutCard 1 1- добавить кристал на  1Й слот player 1 
                case "AddCristall":
                    {

                        Player1.Slots[int.Parse(splitedCommand[1])].Cristall++;
                        return Player1.Cristal.RemoveCristall().ToString().ToLower();
                    }
                //RemoveCristall 1 1 - с удалить кристал в кучу с 1го слота player 1 
                case "RemoveCristall":
                    {
                        if (Player1.Slots[int.Parse(splitedCommand[1])].CristallRemove())
                        {
                            Player1.Cristal.AddCristal();
                            return "true";
                        }
                        return "false";
                    }
                //ReplaceCristall 1 2 1 - переместить кристал со слота 1 на слот 2 Player 1
                case "ReplaceCristall":
                    {

                        if (Player1.Slots[int.Parse(splitedCommand[1])].CristallRemove())
                        {
                            Player1.Slots[int.Parse(splitedCommand[2])].Cristall++;
                            return "true"; 
                        }
                        return "false";
                    }
            }
            return "null";
        }
    }
}
