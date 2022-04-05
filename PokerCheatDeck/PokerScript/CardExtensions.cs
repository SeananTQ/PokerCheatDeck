namespace TexasHoldem
{
    using System;

    public static class CardExtensions
    {
        public static string ToFriendlyString(this CardSuit cardSuit)
        {
            switch (cardSuit)
            {
                case CardSuit.Club:
                    return "\u2663"; // ♣
                case CardSuit.Diamond:
                    return "\u2666"; // ♦
                case CardSuit.Heart:
                    return "\u2665"; // ♥
                case CardSuit.Spade:
                    return "\u2660"; // ♠
                default:
                    throw new ArgumentException("cardSuit");
            }
        }

        public static string ToFriendlyString(this CardNumber cardType)
        {
            switch (cardType)
            {
                case CardNumber.Two:
                    return "2";
                case CardNumber.Three:
                    return "3";
                case CardNumber.Four:
                    return "4";
                case CardNumber.Five:
                    return "5";
                case CardNumber.Six:
                    return "6";
                case CardNumber.Seven:
                    return "7";
                case CardNumber.Eight:
                    return "8";
                case CardNumber.Nine:
                    return "9";
                case CardNumber.Ten:
                    return "10";
                case CardNumber.Jack:
                    return "J";
                case CardNumber.Queen:
                    return "Q";
                case CardNumber.King:
                    return "K";
                case CardNumber.Ace:
                    return "A";
                default:
                    throw new ArgumentException("cardType");
            }
        }

        public static string ToFriendlyString(this IList<Card> cardList)
        {
            string result = "";

            foreach (Card i in cardList)
            { 
                result += i.Suit.ToFriendlyString()+ i.Number.ToFriendlyString()+" ";
            }
            return result;
        }

        public static Card GetRandomElement(this IList<Card> cardList)
        {
            return cardList[RandomProvider.Next(0, cardList.Count)];        }

        public static CardSuit GetRandomElement(this IList<CardSuit> objectList)
        {
            return objectList[RandomProvider.Next(0, objectList.Count)];
        }

        public static CardNumber GetRandomElement(this IList<CardNumber> objectList)
        {
            return objectList[RandomProvider.Next(0, objectList.Count)];
        }
    }
}
