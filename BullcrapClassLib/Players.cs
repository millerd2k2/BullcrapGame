using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class Players
    {
        public List<Player> PlayerList;

        public Players()
        {
            PlayerList = new List<Player>();
        }

        public Players(Players other)
        {
            PlayerList = new List<Player>(other.PlayerList);
        }

        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }

        public bool RemovePlayer(Player player)
        {
            bool removed = false;

            if (PlayerList.Contains(player))
            {
                PlayerList.Remove(player);
                removed = true;
            }

            return removed;    
        }

        public void ReplacePlayer (Player player, int playerSlot)
        {
            PlayerList[playerSlot] = player;
        }

        public int GetNextPlayer(int playerNumber)
        {
            if (++playerNumber == PlayerList.Count) playerNumber = 0;
            return playerNumber;
        }

        public int GetPreviousPlayer(int playerNumber)
        {
            if (--playerNumber < 0) playerNumber = PlayerList.Count - 1;
            return playerNumber;
        }
    }
}
