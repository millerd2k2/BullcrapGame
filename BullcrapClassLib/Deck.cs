using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class Deck
    {
        public Deck()
        {
            MakeDeck();
        }

        private List<Card> Cards { get; set; }

        public void MakeDeck()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card(c, s)))
                .ToList();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public void Deal(List<Player> playerList)
        {
            int extraCards = Cards.Count % playerList.Count;

            for (int i = 0; i < playerList.Count; i++)
            {
                int handCount = Cards.Count / playerList.Count + (i < extraCards ? 1 : 0);

                foreach (Card card in TakeCards(handCount))
                {
                    playerList[i].Hand.Add(card);
                }
            }
        }

        public Card TakeCard()
        {
            Card? card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        private IEnumerable<Card> TakeCards(int numCards)
        {
            var cards = Cards.Take(numCards);

            var takeCards = cards as Card[] ?? cards.ToArray();
            Cards.RemoveAll(takeCards.Contains);

            return takeCards;
        }
    }
}
