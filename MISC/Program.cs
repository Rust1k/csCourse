using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durak
{
    class Program
    {
        enum Suit { Hearts, Clubs, Diamonds, Spades     };
        enum Rank { Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

        class Card
        {
            private Suit suit;
            private Rank rank;

            public Card (Suit suit, Rank rank)
            {
                this.suit = suit;
                this.rank = rank;
            }

            public Suit GetSuit()
            {
                return this.suit;
            }

            public Rank GetRank()
            {
                return this.rank;
            }

        }

        class Table
        {
            List<Card> cards = new List<Card>();
            List<Tuple<Card, Card>> beated = new List<Tuple<Card, Card>>();

            /// <summary>
            /// Flushs the table
            /// </summary>
            public void Flush()
            {

            }
        }

        class Player
        {
            public List<Card> cardsOnHand = new List<Card>();
            public string name;
        }

        class Game
        {
            Card trump;
            Queue<Card> deck = new Queue<Card>();
            List<Card> beatedCards = new List<Card>();
            List<Player> players = new List<Player>();
            Player currentPlayer;

            /// <summary>
            /// 
            /// </summary>
            public void Initialize()
            {

            }

            public void MakeMove()
            {

            }

            /// <summary>
            /// 
            /// </summary>
            public void EndMove()
            {

            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public bool IsGameIsEnding()
            {
                return false;
            }
        }
        
        static void Main(string[] args)
        {

        }
    }
}
