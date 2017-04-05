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
            Battle.Units.Add(new cUnit(new Card() { RunSpeed = 2, Width = 10, Height = 10 }, 0));
            Battle.Units.Add(new cUnit(new Card() {RunSpeed = 5, Width = 15, Height = 15 }, 1));
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
