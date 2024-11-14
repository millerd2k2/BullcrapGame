using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class CenterPile
    {
        Stack<Card> cardPile = new Stack<Card>();
        public int Count { get {  return cardPile.Count; } }
        private int _numLastTurn;

        public void Add(Card card)
        {
            cardPile.Push(card);
        }

        public void Add(List<Card> cards)
        {
            _numLastTurn = 0;

            foreach (Card card in cards)
            {
                cardPile.Push(card);
                _numLastTurn++;
            }
        }

        public void DumpCards(Player player)
        {
            while (!IsEmpty())
            {
                Card card = cardPile.Pop();
                player.Hand.Add(card);
            }
        }

        public bool IsEmpty()
        {
            return cardPile.Count == 0;
        }

        public bool VerifyBullshit(int rank)
        {
            bool result = false;
            List<Card> cards = new List<Card>(_numLastTurn);

            for (int i = 0; i < _numLastTurn; i++)
            {
                cards.Add(cardPile.Pop());
                if (cards[i].Value != rank)
                {
                    result = true;
                    Console.WriteLine("Nonmatch detected");
                    break;
                }
            }

            foreach (Card card in cards)
            {
                cardPile.Push(card);
            }

            return result;
        }
    }
}
