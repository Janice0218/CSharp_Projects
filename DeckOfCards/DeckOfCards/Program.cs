using System;

namespace DeckOfCards
{
    class Program

    {
  
        static void Main(string[] args)
        {
            var myDeck = new Deck();
            myDeck.Deal();
            myDeck.Deal();
            myDeck.Shuffle();
            myDeck.PrintShoe();
            var player1=new Player("Beth");
            player1.Draw(myDeck);
            player1.Draw(myDeck);
            player1.SeeHand();
            myDeck.PrintShoe();
            


        }
    }
}
