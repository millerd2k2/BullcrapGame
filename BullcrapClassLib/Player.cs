using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class Player
    {
        public string Name;
        public List<Card> Hand;
        public bool IsHost {  get; private set; }

        public Player(string name, bool isHost = false)
        {
            Name = name;
            Hand = new List<Card>();
            IsHost = isHost;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
