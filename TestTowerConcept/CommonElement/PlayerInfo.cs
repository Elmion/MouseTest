using System.Collections.Generic;

namespace CommonElement
{
    public class PlayerInfo
    {
        public List<string> CardInSlots;
        public List<int> CardStatus; //если карта -1 то на редрафте, если 0 то заряжаена прочее таймер до зарядки
        public int Cristall = 0; 
        public PlayerInfo()
        {
            CardInSlots = new List<string>();
            CardStatus = new List<int>();
        }
    }
}