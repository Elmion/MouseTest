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
        public string ExecuteCommand(string  command)
        {
            string[]  splitedCommand = command.Split(' ');
            switch(splitedCommand[0])
            {
                //PutCard Mage 1 - первый вызывает мага
                case "PutCard":
                    {
                        Card c =  Type.GetType(splitedCommand[1]).GetConstructor(new System.Type[] { }).Invoke(new object[] { }) as Card;
                        Battle.CreateCard(sbyte.Parse(splitedCommand[2]), c);
                        return "true";
                    }
            }
            return "null";
        }
    }
}
