using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class DeckOfCards
    {
        
        private readonly string[]_faceTypes = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        private readonly string[] _suitTypes = {"Clubs", "Hearts", "Diamonds", "Spades"};
        public List<Card> Cards { get; set; }

        public DeckOfCards()
        {
            Cards = new List<Card>();
            Reset();

        }

        public Card Deal()
        {   
            Card deal = Cards[0];
            Cards.Remove(deal);
            Console.WriteLine(deal);
            Console.WriteLine("Cards Remaining: " + Cards.Count);
            return deal;
        }

        public void Reset()
        {
            Cards.Clear();
            foreach (var suitType in _suitTypes)
            {
                foreach (var faceType in _faceTypes)
                {
                    Cards.Add(new Card(faceType, suitType));
                }
            }
        }

        public void Shuffle()
        {
            List<Card> ShuffledCards = new List<Card>();
            Random rand = new Random();
            while (Cards.Count > 0)
            {
                Card randCard = Cards[rand.Next(Cards.Count)];
                ShuffledCards.Add(randCard);
                Cards.Remove(randCard);
            }

            Cards = ShuffledCards;
            Console.WriteLine("Deck has been shuffled...");
        }

        public void PrintShoe()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("Total Count: " + Cards.Count);
        }

    }
}
