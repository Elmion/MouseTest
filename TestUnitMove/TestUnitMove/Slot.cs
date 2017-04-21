using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
    class Slot
    {
   
        private Main _parentGame;
        public Main Game { get { return _parentGame; } }

        public Slot(Main game)
        {
            _parentGame = game;
        }

    }
}
