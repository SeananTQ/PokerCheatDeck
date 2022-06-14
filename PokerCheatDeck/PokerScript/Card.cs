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
        


        public string GetCardCode()
        {
            string result = string.Empty;

            switch (this.Suit)
            {
                case CardSuit.Club:
                    result = "C";
                    break;
                case CardSuit.Diamond:
                    result = "D";
                    break;
                case CardSuit.Heart:
                    result = "H";
                    break;
                case CardSuit.Spade:
                    result = "S";
                    break;

            }

            switch (this.Number)
            {
                case CardNumber.Ace:
                    result += "A";
                    break;
                case CardNumber.Two:
                    result += "2";
                    break;
                case CardNumber.Three:
                    result += "3";
                    break;
                case CardNumber.Four:
                    result += "4";
                    break;
                case CardNumber.Five:
                    result += "5";
                    break;
                case CardNumber.Six:
                    result += "6";
                    break;
                case CardNumber.Seven:
                    result += "7";
                    break;
                case CardNumber.Eight:
                    result += "8";
                    break;
                case CardNumber.Nine:
                    result += "9";
                    break;
                case CardNumber.Ten:
                    result += "T";
                    break;
                case CardNumber.Jack:
                    result += "J";
                    break;
                case CardNumber.Queen:
                    result += "Q";
                    break;
                case CardNumber.King:
                    result += "K";
                    break;
            }
            return result;
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
