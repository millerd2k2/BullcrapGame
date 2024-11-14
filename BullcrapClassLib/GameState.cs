using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class GameState
    {
        public GameState(List<Player> playerList)
        {
            PlayerList = playerList;
            SetupNewGame();
        }

        public List<Player> PlayerList;
        public CenterPile CardPile = new();
        Deck deck;

        private int _previousPlayer;
        public int CurrentPlayer;

        private int _rankToCheck;
        public int CurrentRank;

        private int _playerToWin;
        public string Winner;
        public bool WinnerDeclared;

        public int NextPlayer()
        {
            return (CurrentPlayer + 1) % PlayerList.Count;
        }

        public int NextRank()
        {
            return (CurrentRank % 13) + 1;
        }

        public void SetupNewGame()
        {
            CurrentPlayer = 0;
            CurrentRank = 1;
            WinnerDeclared = false;

            deck = new Deck();
            deck.Shuffle();
            deck.Deal(PlayerList);
        }

        public void PlayTurn(List<Card> submittedCards)
        {
            foreach (var card in submittedCards)
            {
                PlayerList[CurrentPlayer].Hand.Remove(card);
            }

            CardPile.Add(submittedCards);
            _previousPlayer = CurrentPlayer;
            CurrentPlayer = NextPlayer();
            _rankToCheck = CurrentRank;
            CurrentRank = NextRank();

            UpdateWinState();
        }

        public void Bullshit(int playerCalling)
        {
            if (CardPile.VerifyBullshit(_rankToCheck))
            {
                CardPile.DumpCards(PlayerList[_previousPlayer]);
                Console.WriteLine("Bullshit");
            }
            else
            {
                CardPile.DumpCards(PlayerList[playerCalling]);
                Console.WriteLine("Not bullshit");
            }

            UpdateWinState();
        }

        public void UpdateWinState()
        {
            Player winningPlayer = CheckForWin();
            if (winningPlayer != null)
            {
                Winner = winningPlayer.Name;
                WinnerDeclared = true;
            }
            else
            {
                Winner = String.Empty;
                WinnerDeclared = false;
            }
        }

        public Player? CheckForWin()
        {
            bool noHandsEmpty = true;

            for (int i = 0; i < PlayerList.Count; i++)
            {
                if (PlayerList[i].Hand.Count == 0)
                {
                    if (_playerToWin == i)
                    {
                        return PlayerList[i];
                    }

                    _playerToWin = i;
                    noHandsEmpty = false;
                }
            }

            if (noHandsEmpty) _playerToWin = -1;

            return null;
        }

        public void Reset()
        {
            foreach (var player in PlayerList)
            {
                player.Hand.Clear();
            }

            SetupNewGame();
        }
    }
}
