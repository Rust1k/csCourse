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
            static Suit trump;

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

            /// <summary>
            /// Check if you can beat current card by cardThatBeats
            /// </summary>
            /// <param name="cardThatBeats"></param>
            /// <returns></returns>
            public bool BeatOpportunityCheck(Card cardThatBeats)
            {
                // если масти разные и если у cardThatBeats масть козырная - то true
                // если масти разные и если у cardThatBeats масть некозырная - false
                // если масти одинаковые, то сравниваем Rank
                if (this.suit != cardThatBeats.suit)
                {
                    return (cardThatBeats.suit == trump);
                }
                return (this.rank < cardThatBeats.rank);
            }
        }

        class Table
        {
            List<Card> cards = new List<Card>();
            List<Tuple<Card, Card>> beatedCards = new List<Tuple<Card, Card>>();

            /// <summary>
            /// Add card to Table
            /// </summary>
            /// <param name="c"></param>
            public void Add(Card c)
            {
                cards.Add(c);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cardToBeat"></param>
            /// <param name="cardThatBeats"></param>
            public bool Beat(Card cardToBeat, Card cardThatBeats)
            {
                if (!cards.Contains(cardToBeat))
                    throw new Exception("There is no such card on the table");
                if (cardToBeat.BeatOpportunityCheck(cardThatBeats))
                {
                    cards.Remove(cardToBeat);
                    beatedCards.Add(new Tuple<Card, Card>(cardToBeat, cardThatBeats));
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Flushs the table
            /// </summary>
            public void Flush()
            {
                cards = new List<Card>();
                beatedCards = new List<Tuple<Card, Card>>();
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
            List<Card> deck = new List<Card>();
            List<Card> beatedCards = new List<Card>();
            List<Player> players = new List<Player>();
            Player currentPlayer;
            Table table;

            /// <summary>
            /// 
            /// </summary>
            public void Initialize(List<Player> players)
            {
                if (players.Count > 4) 
                    throw new Exception("Number of players should be less than 5.");
                this.table = new Table();
                this.players = players;
                this.beatedCards = new List<Card>();
                List<Card> cards = new List<Card>();
                Random r = new Random();
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        int k = r.Next(i*9+j);
                        cards.Insert(k,new Card((Suit)i, (Rank)j));
                    }
                trump = cards.ElementAt(0);
                cards.RemoveAt(0);
                foreach(Player p in this.players)
                {
                    p.cardsOnHand.AddRange(cards.GetRange(0, 6));
                    cards.RemoveRange(0, 6);
                }
                currentPlayer = players.ElementAt(r.Next(players.Count - 1));

                deck = cards;
            }

            /// <summary>
            /// 
            /// </summary>
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
                int q = 0;
                foreach (Player p in this.players)
                {
                    if (p.cardsOnHand.Count > 0) q++;
                }
                return (deck.Count == 0) & (q <= 1);
            }
        }
        
        static void Main(string[] args)
        {

        }
    }
}
