namespace TexasHoldem
{
    using System.Collections.Generic;
    using System.Linq;


    //牌库
    public class Deck : IDeck
    {
        public static readonly IReadOnlyList<Card> AllCards;

        private static readonly IEnumerable<CardNumber> AllCardTypes = new List<CardNumber>
                                                                         {
                                                                             CardNumber.Two,
                                                                             CardNumber.Three,
                                                                             CardNumber.Four,
                                                                             CardNumber.Five,
                                                                             CardNumber.Six,
                                                                             CardNumber.Seven,
                                                                             CardNumber.Eight,
                                                                             CardNumber.Nine,
                                                                             CardNumber.Ten,
                                                                             CardNumber.Jack,
                                                                             CardNumber.Queen,
                                                                             CardNumber.King,
                                                                             CardNumber.Ace,
                                                                         };

        private static readonly IEnumerable<CardSuit> AllCardSuits = new List<CardSuit>
                                                                         {
                                                                             CardSuit.Club,//梅花
                                                                             CardSuit.Diamond,//方块
                                                                             CardSuit.Heart,//红心
                                                                             CardSuit.Spade,//黑桃
                                                                         };

        private readonly IList<Card> listOfCards;

        private int cardIndex;

        static Deck()
        {
            var cards = new List<Card>();
            //双循环生成全部花色的扑克牌,共52张
            foreach (var cardSuit in AllCardSuits)
            {
                foreach (var cardType in AllCardTypes)
                {
                    cards.Add(new Card(cardSuit, cardType));
                }
            }

            AllCards = cards.AsReadOnly();
        }

        public Deck()
        {
            //洗牌
            this.listOfCards = AllCards.Shuffle().ToList();
            this.cardIndex = AllCards.Count;
        }

        //抓牌
        public Card GetNextCard()
        {
            if (this.cardIndex == 0)
            {
                //牌库空了
            }

            this.cardIndex--;
            var card = this.listOfCards[this.cardIndex];
            return card;
        }
    }
}
