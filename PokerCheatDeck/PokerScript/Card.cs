namespace TexasHoldem
{
    /// <summary>
    /// Immutable object to represent game card with suit and type.
    /// </summary>
    public class Card : IDeepCloneable<Card>
    {
        public Card(CardSuit suit, CardNumber number)
        {
            this.Suit = suit;
            this.Number = number;
        }

        public CardSuit Suit { get; set; }

        public CardNumber Number { get; set; }

        public static Card FromHashCode(int hashCode)
        {
            var suitId = hashCode / 13;
            return new Card((CardSuit)suitId, (CardNumber)(hashCode - (suitId * 13) + 2));
        }

        public override bool Equals(object obj)
        {
            var anotherCard = obj as Card;
            return anotherCard != null && this.Equals(anotherCard);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)this.Suit * 13) + (int)this.Number - 2;
            }
        }

        public Card DeepClone()
        {
            return new Card(this.Suit, this.Number);
        }

        public override string ToString()
        {
            return $"{this.Number.ToFriendlyString()}{this.Suit.ToFriendlyString()}";
        }

        private bool Equals(Card other)
        {
            return this.Suit == other.Suit && this.Number == other.Number;
        }
    }
}
