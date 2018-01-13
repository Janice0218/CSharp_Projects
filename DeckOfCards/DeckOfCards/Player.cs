using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public Card Draw(Deck currentDeck)
        {   
            
            var drawCard = currentDeck.Cards[0];
            Hand.Add(drawCard);
            currentDeck.Cards.Remove(drawCard);
            return drawCard;
        }

        public Card Discard(int index)
        {
            if (Hand[index] != null)
            {
                Card dcard = Hand[index];
                Hand.Remove(dcard);
                return dcard;
            }
            return null;
        }
        public void SeeHand()
        {
            foreach (var card in Hand)
            {
                Console.WriteLine(card);
            }
        }
    }
}