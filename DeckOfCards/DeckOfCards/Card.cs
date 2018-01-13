namespace DeckOfCards
{
    public class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public Card(string faceVal, string suitVal)
        {
            Face = faceVal;
            Suit = suitVal;
        }

        public override string ToString()
        {
            return Face + " of a " + Suit;
        }
    }

}