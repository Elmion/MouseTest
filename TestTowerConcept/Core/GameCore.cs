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
        BattleField Battle;
        Player Player1;
        Player Player2;
        public GameCore()
        {
            Player1 = new Player(0,this);
            Player2 = new Player(1,this);
            Battle = new BattleField();
            Battle.Units.Add(new cUnit(new Mage(), 0));
            Battle.Units.Add(new cUnit(new Ogr(),  0));
            Battle.Units.Add(new cUnit(new Ogr(),  1));
            Battle.Units.Add(new cUnit(new Mage(), 1));
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
                string[] separateType = item.FreezedCard.GetType().ToString().Split('.');
                s.NameCommonObject = separateType[separateType.Length-1];
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
            for (int i = 0; i < Player1.CardInSlot.Count; i++)
            {
                p1.CardInSlots.Add(Player1.CardInSlot[i].card);
                p2.CardInSlots.Add(Player2.CardInSlot[i].card);

                if (Player1.CardInSlot[i].ReloadRequest) p1.CardStatus.Add(-1);
                else
                {
                    p1.CardStatus.Add(Player1.CardInSlot[i].CurrentRechargeTime);
                }


                if (Player2.CardInSlot[i].ReloadRequest) p2.CardStatus.Add(-1);
                else
                {
                    p2.CardStatus.Add(Player2.CardInSlot[i].CurrentRechargeTime);
                }

            }
            ListOut.Add(p1);
            ListOut.Add(p2);
            return ListOut;
        }
        public string ExecuteCommand(string  command)
        {
            string[]  splitedCommand = command.Split(' ');
            switch(splitedCommand[0])
            {
                //PutCard Mage 1 - первый вызывает мага
                case "PutCard":
                    {
                        Card c =  Type.GetType("CommonElement."+splitedCommand[1]+ ",CommonElement").GetConstructor(new System.Type[] { }).Invoke(new object[] { }) as Card;
                        Battle.CreateCard(sbyte.Parse(splitedCommand[2]), c);
                        Player1.RechargeCard(Player1.CardInSlot.FindIndex(x => x.card.GetType() == c.GetType()));
                        return "true";
                    }
            }
            return "null";
        }
    }
}
