using System;

namespace DeckOfCards
{
    class Program

    {
  
        static void Main(string[] args)
        {
            var myDeck = new DeckOfCards();
            Console.WriteLine(myDeck.Cards.Count);
 

            myDeck.Shuffle();
            myDeck.PrintShoe();
            myDeck.Deal();
            myDeck.Deal();
            myDeck.Reset();
            myDeck.PrintShoe();
            

        }
    }
}
