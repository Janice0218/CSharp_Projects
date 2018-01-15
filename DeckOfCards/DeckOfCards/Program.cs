using System;
using System.Linq;

namespace DeckOfCards
{
    class Program

    {
  
        static void Main(string[] args)
        {
            var myDeck = new Deck();
            //myDeck.Deal();
            //myDeck.Deal();
            myDeck.Shuffle();
            //myDeck.PrintShoe();
            var player1 = new Player("Beth");
            player1.Draw(myDeck);
            player1.Draw(myDeck);
            player1.Draw(myDeck);
            player1.Draw(myDeck);
            //player1.SeeHand();
            //myDeck.PrintShoe();
            var order = player1.Hand.OrderByDescending(c => c.Face);
            foreach (var heart in order)
            {
                Console.WriteLine(heart);
            }



        }
    }
}
