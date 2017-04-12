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
            p1.Cristall = Player1.Cristal.Count;
            p2.Cristall = Player2.Cristal.Count;
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
            string[] splitedCommand = command.Split(' ');
            switch(splitedCommand[0])
            {
                //PutCard Mage 1 - первый вызывает мага
                case "PutCard":
                    {
                        Type typeSummonCard = Type.GetType("CommonElement." + splitedCommand[1] + ",CommonElement");
                        Slot slot = Player1.CardInSlot.Find(x => x.card != null&&x.card.GetType() == typeSummonCard);
                        if (slot.card != null && slot.CurrentRechargeTime == 0)//присылаем по сети так что на случай подлога, вообще такого не должно быть
                        {
                            Card c = typeSummonCard.GetConstructor(new System.Type[] { }).Invoke(new object[] { }) as Card;
                            Battle.CreateCard(sbyte.Parse(splitedCommand[2]), c);
                            Player1.RechargeCard(Player1.CardInSlot.FindIndex(x => x.card != null && x.card.GetType() == typeSummonCard));
                            return "true";
                        }
                        return "false";
                    }
                //Перегружаем карту 1 1
                case "ReloadCard":
                    {
                        Player1.ChangeCardsInSlot(int.Parse(splitedCommand[1]));
                        return "true";
                    }
                //PutCard 1 1- добавить кристал на с 1Й слот player 1 
                case "AddCristall":
                    {
                        return Player1.Cristal.RemoveCristall().ToString();
                    }
                //RemoveCristall 1 1 - с удалить кристал в кучу с 1го слота player 1 
                case "RemoveCristall":
                    {
                        Player1.ChangeCardsInSlot(int.Parse(splitedCommand[1]));
                        return "true";
                    }
                //ReplaceCristall 1 2 1 - переместить кристал со слота 1 на слот 2 Player 1
                case "ReplaceCristall":
                    {
                        Player1.ChangeCardsInSlot(int.Parse(splitedCommand[1]));
                        return "true";
                    }
            }
            return "null";
        }
    }
}
