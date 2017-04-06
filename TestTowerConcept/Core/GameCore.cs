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
        public Action DoStep;
        BattleField Battle;
        Player Player1;
        Player Player2;
        public GameCore()
        {
            Player1 = new Player(0,this);
            Player2 = new Player(1,this);
            Battle = new BattleField();
            Battle.Units.Add(new cUnit(new Portal(), 0));
            Battle.Units.Add(new cUnit(new Portal(), 1));
            Battle.Units.Add(new cUnit(new Mage(), 0));
            Battle.Units.Add(new cUnit(new Ogr(),  0));
            Battle.Units.Add(new cUnit(new Ogr(),  1));
            Battle.Units.Add(new cUnit(new Mage(), 1));
            DoStep += Update;
           
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
        public void CreateCard(int side, Card c)
        {
            Battle.Units.Add(new cUnit(c, (sbyte)side));
        }


    }
}
