using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class Lobby
    {
        public string LobbyId { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public int MaxPlayers { get; set; }
    }
}
