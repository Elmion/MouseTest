using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class Player
    {
        int Team { get; set; }
        List<Card> Cardbook;
        public Player(int Team)
        {
            this.Team = Team;
        }
    }
}
