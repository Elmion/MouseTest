using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
    public class Unit
    {
        private Game _parentGame;
        public Game Game { get { return _parentGame; } }

        IMove moveType;
        public Unit(Game game, IMove move)
        {
            _parentGame = game;
            moveType = move;
        }

        public void Move()
        {
            moveType.Move(this);
        }
        public void Attack()
        {

        }
    }

}
