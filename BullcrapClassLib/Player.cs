using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class Player
    {
        string _name;
        public List<Card> Hand;

        public Player(string name)
        {
            _name = name;
            Hand = new List<Card>();
        }
    }
}
