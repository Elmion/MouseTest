using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonElement;

namespace Core
{
    class Player
    {
        int Team { get; set; }
        GameCore core;
        List<Card> Cardbook;
        public Player(int Team,GameCore core)
        {
            this.Team = Team;
            Cardbook = new List<Card>();
            this.core = core;
        }
        public void AddCardIntoBook(Card c)
        {
            Cardbook.Add(c);
        }
        public void SpawnCard(Card c)
        {
            if(Cardbook.Contains(c))
            {
                core.CreateCard(Team, c);
            }
        }

    }
}
