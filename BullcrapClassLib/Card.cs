using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullcrapClassLib
{
    public class Card
    {
        //public enum Suits { Clubs, Diamonds, Hearts, Spades }
        //public enum Ranks { Ace = 1, Jack = 11, Queen = 12, King = 13 }

        public int Value { get; private set; }
        public int Suit { get; private set; }

        public Card(int value, int suit)
        {
            Value = value;
            Suit = suit;
        }

        public string GetImage()
        {
            string filename = "imgs/cards/";
            switch (Suit)
            {
                case 1:
                    filename += "CLUB-";
                    break;
                case 2:
                    filename += "DIAMOND-";
                    break;
                case 3:
                    filename += "HEART-";
                    break;
                case 4:
                    filename += "SPADE-";
                    break;
            }

            filename += Value;
            
            switch (Value)
            {
                case 11:
                    filename += "-JACK";
                    break;
                case 12:
                    filename += "-QUEEN";
                    break;
                case 13:
                    filename += "-KING";
                    break;
            }

            return filename + ".svg";
        }

        public override string ToString()
        {
            string cardString = "";
            switch (Suit)
            {
                case 1:
                    cardString += "♣";
                    break;
                case 2:
                    cardString += "♦";
                    break;
                case 3:
                    cardString += "♥";
                    break;
                case 4:
                    cardString += "♠";
                    break;
            }

            switch (Value)
            {
                case 1:
                    cardString += "A";
                    break;
                case 11:
                    cardString += "J";
                    break;
                case 12:
                    cardString += "Q";
                    break;
                case 13:
                    cardString += "K";
                    break;
                default:
                    cardString += Value;
                    break;
            }

            return cardString;
        }
    }
}
