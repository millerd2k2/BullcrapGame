using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class LobbyService
    {
        private readonly List<Lobby> _lobbies = new List<Lobby>();

        public Lobby CreateLobby(string name, int maxPlayers)
        {
            var lobby = new Lobby
            {
                LobbyId = Guid.NewGuid().ToString(),
                Name = name,
                MaxPlayers = maxPlayers
            };
            _lobbies.Add(lobby);
            return lobby;
        }

        public void RemoveLobby(string lobbyId)
        {
            var lobby = _lobbies.FirstOrDefault(l => l.LobbyId == lobbyId);
            if (lobby != null)
            {
                _lobbies.Remove(lobby);
            }
        }

        public Lobby GetLobby(string lobbyId)
        {
            return _lobbies.FirstOrDefault(l => l.LobbyId == lobbyId);
        }

        public List<Lobby> GetAllLobbies()
        {
            return _lobbies;
        }
    }
}
