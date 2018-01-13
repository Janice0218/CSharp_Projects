using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Deck
    {
        
        private readonly string[]_faceTypes = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        private readonly string[] _suitTypes = {"Clubs", "Hearts", "Diamonds", "Spades"};
        public List<Card> Cards { get; set; }

        public Deck(bool jokers=false)
        {
            Cards = new List<Card>();
            Reset(jokers);

        }

        public Card Deal()
        {   
            Card deal = Cards[0];
            Cards.Remove(deal);
            Console.WriteLine(deal);
            Console.WriteLine("Cards Remaining: " + Cards.Count);
            return deal;
        }

        public void Reset(bool jokers=false)
        {
            Cards.Clear();
            foreach (var suitType in _suitTypes)
            {
                foreach (var faceType in _faceTypes)
                {
                    Cards.Add(new Card(faceType, suitType));
                }

            }
            if (jokers == true)
            {
                Cards.Add(new Card("Joker", "Joker"));
                Cards.Add(new Card("Joker", "Joker"));
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
