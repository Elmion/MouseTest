using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Core
{
    public class GameCore
    {
        public Action DoStep;
        BattleField Battle;
        Player Player1;
        Player Player2;
        public GameCore()
        {
            Player1 = new Player(0);
            Player2 = new Player(1);
            Battle = new BattleField();
            Battle.Units.Add(new cUnit(new Mage() , 0));
            Battle.Units.Add(new cUnit(new Ogr(), 0));
            Battle.Units.Add(new cUnit(new Ogr() , 1));
            Battle.Units.Add(new cUnit(new Mage(), 1));
            DoStep += Update;
        }
       public void Update()
        {
            Battle.AllMove();
        }
       public void Draw(Graphics g)
        {
            Battle.Draw(g);
        }
    }
}
