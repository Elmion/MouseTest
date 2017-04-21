using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
    public class Unit
    {
        private Main _parentGame;
        public Main Game { get { return _parentGame; } }

        IMove moveType;
        public Unit(Main game, IMove move)
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
