using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TexasHoldem
{
    internal class CheatDeck
    {
        public static readonly IReadOnlyList<Card> AllCards;

        private static readonly IList<CardNumber> AllCardNumbers = new List<CardNumber>
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

        private static readonly IList<CardSuit> AllCardSuits = new List<CardSuit>
                                                                         {
                                                                              CardSuit.Spade,//黑桃
                                                                              CardSuit.Heart,//红心
                                                                              CardSuit.Club,//梅花
                                                                              CardSuit.Diamond,//方块
                                                                         };

        private IList<Card> listOfCards;

        private int cardIndex;


        private Card dogCard;


        static CheatDeck()
        {
            var cards = new List<Card>();
            //双循环生成全部花色的扑克牌,共52张
            foreach (var cardSuit in AllCardSuits)
            {
                foreach (var cardNumber in AllCardNumbers)
                {
                    cards.Add(new Card(cardSuit, cardNumber));
                }
            }

            AllCards = cards.AsReadOnly();
        }

        public CheatDeck()
        {
            InitCardList();
        }


        private void InitCardList()
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

        //在HandRankType中随机一项，然后调用对应方法，并返回该方法的返回值
        public IList<Card> GetRandomHandType(int cardCount)
        {
            var handType = (HandRankType)new Random().Next(0, 10);
            switch (handType)
            {
                case HandRankType.HIGH_CARD:
                    return this.GetHighCards(cardCount);
                case HandRankType.PAIR:
                    return this.Get2KindCards(cardCount);
                case HandRankType.TWO_PAIR:
                    return this.GetTwoPairsCards(cardCount);
                case HandRankType.THREE_OF_A_KIND:
                    return this.Get3KindCards(cardCount);
                case HandRankType.STRAIGHT:
                    return this.GetStraightCards(cardCount);
                case HandRankType.FLUSH:
                    return this.GetFlushCards(cardCount);
                case HandRankType.FULL_HOUSE:
                    return this.GetFullHouseCards(cardCount);
                case HandRankType.FOUR_OF_A_KIND:
                    return this.Get4KindCards(cardCount);
                case HandRankType.STRAIGHT_FLUSH:
                    return this.GetStraightFlushCards(cardCount);
                case HandRankType.ROYAL_FLUSH:
                    return this.GetRoyalFlushCards(cardCount);
                default:
                    return this.GetHighCards(cardCount);
            }
        }


        //随机生成一个狗狗牌，黑名单中的不会被随机到
        public Card GetDogCard(IList<Card>? blackList = null)
        {
            if (blackList != null)
            {
                foreach (var i in blackList)
                {
                    this.listOfCards.Remove(i);
                }
            }
            var card = this.listOfCards[RandomProvider.Next(0, listOfCards.Count)];
            return card;

        }


        //随机得到一个高分牌型
        public IList<Card> GetHighCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
            {
                //通过白名限定高分牌
                IList<Card> whiteList = new List<Card>();
                foreach (var i in AllCardSuits)
                {
                    whiteList.Add(new Card(i, CardNumber.Ace));
                    whiteList.Add(new Card(i, CardNumber.King));
                    whiteList.Add(new Card(i, CardNumber.Queen));
                    whiteList.Add(new Card(i, CardNumber.Jack));
                    whiteList.Add(new Card(i, CardNumber.Ten));
                }
                this.dogCard = whiteList[RandomProvider.Next(0, whiteList.Count)];
            }
            IList<Card> result = new List<Card>();
            result.Add(this.dogCard);
            result = FillCardList(result, cardCount);
            return result;
        }


        //随机得到一个四条牌型
        public IList<Card> Get4KindCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
                this.dogCard = GetDogCard();
            var result = GetNKindCards(this.dogCard, 4);
            result = FillCardList(result, cardCount);
            return result;
        }

        //随机得到一个三条牌
        public IList<Card> Get3KindCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
                this.dogCard = GetDogCard();
            var result = GetNKindCards(this.dogCard, 3);
            result = FillCardList(result, cardCount);
            return result;
        }

        //随机得到一个对子牌
        public IList<Card> Get2KindCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
                this.dogCard = GetDogCard();
            var result = GetNKindCards(this.dogCard, 2);
            result = FillCardList(result, cardCount);
            return result;
        }

        //随机得到一个两对条牌
        public IList<Card> GetTwoPairsCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
                this.dogCard = GetDogCard();
            var result = GetNXNYCards(this.dogCard, 2, 2);
            result = FillCardList(result, cardCount);
            return result;
        }

        //随机得到一个葫芦牌
        public IList<Card> GetFullHouseCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
                this.dogCard = GetDogCard();
            var result = GetNXNYCards(this.dogCard, 3, 2);
            result = FillCardList(result, cardCount);
            return result;
        }

        //得到一个同花牌
        public IList<Card> GetFlushCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
                this.dogCard = GetDogCard();
            IList<Card> result = new List<Card>();
            result.Add(this.dogCard);
            result = FillCardList(result, 5);
            foreach (var v in result)
            {
                v.Suit = this.dogCard.Suit;
            }
            result = FillCardList(result, cardCount);
            return result;
        }





        //随机得到一个顺子牌
        public IList<Card> GetStraightCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
                this.dogCard = GetDogCard();
            var result = GetStraightCards(this.dogCard);
            result = FillCardList(result, cardCount);
            return result;
        }

        //随机得到一个同花顺
        public IList<Card> GetStraightFlushCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
            {
                //通过黑名单排除掉皇家同花顺
                IList<Card> blackList = new List<Card>();
                foreach (var i in AllCardSuits)
                {
                    blackList.Add(new Card(i, CardNumber.Ace));
                    blackList.Add(new Card(i, CardNumber.King));
                    blackList.Add(new Card(i, CardNumber.Queen));
                }
                this.dogCard = GetDogCard(blackList);
            }
            var tempResult = GetStraightCards(this.dogCard);

            IList<Card> result = new List<Card>();
            foreach (var i in tempResult)
            {
                result.Add(new Card(this.dogCard.Suit, i.Number));
            }
            result = FillCardList(result, cardCount);
            return result;
        }

        //随机得到一个皇家同花顺
        public IList<Card> GetRoyalFlushCards(int cardCount, Card? keyCard = null)
        {
            InitCardList();
            if (keyCard == null)
            {
                //通过白名限定皇家同花顺
                IList<Card> whiteList = new List<Card>();
                foreach (var i in AllCardSuits)
                {
                    whiteList.Add(new Card(i, CardNumber.Ace));
                    whiteList.Add(new Card(i, CardNumber.King));
                    whiteList.Add(new Card(i, CardNumber.Queen));
                }
                this.dogCard = whiteList[RandomProvider.Next(0, whiteList.Count)];
            }
            var tempResult = GetStraightCards(this.dogCard);


            IList<Card> result = new List<Card>();
            foreach (var i in tempResult)
            {
                result.Add(new Card(this.dogCard.Suit, i.Number));
            }
            result = FillCardList(result, cardCount);
            return result;
        }






        //为cards补充一些“无用的牌”到maxCount数量
        private IList<Card> FillCardList(IList<Card> cards, int maxCount)
        {
            List<Card> result = new();
            InitCardList();
            List<CardSuit> blackList_suit = new();
            List<CardNumber> blackList_number = new();

            foreach (var v in cards)
            {
                blackList_number.Add(v.Number);
            }
            cards = cards.OrderBy(x => x.Number).ToList();
            int tempIndex1 = AllCardNumbers.IndexOf(cards.First().Number);
            int tempIndex2 = AllCardNumbers.IndexOf(cards.Last().Number);
            tempIndex1 = Math.Max(0, tempIndex1 - 1);
            tempIndex2 = Math.Min(AllCardNumbers.Count - 1, tempIndex2 + 1);

            blackList_number.Add(AllCardNumbers[tempIndex1]);
            blackList_number.Add(AllCardNumbers[tempIndex2]);
            blackList_suit.Add(cards[0].Suit);

            blackList_number = AllCardNumbers.Except(blackList_number).ToList();
            blackList_suit = AllCardSuits.Except(blackList_suit).ToList();


            for (int i = 0; i < maxCount - cards.Count; i++)
            {
                var tempCard = new Card(blackList_suit.GetRandomElement(), blackList_number.GetRandomElement());
                result.Add(tempCard);
                blackList_number.Remove(tempCard.Number);
            }
            result.AddRange(cards);
            return result;
        }




        //以KeyCard为首，生成一组NX+NY牌
        private IList<Card> GetNXNYCards(Card keyCard, int x, int y)
        {
            IList<Card> result = new List<Card>();
            result.Add(keyCard);
            var tempList = AllCardSuits.ToList().Shuffle();
            tempList = tempList.Where(w => w != keyCard.Suit).Take(x - 1).ToList();
            foreach (var i in tempList)
                result.Add(new Card(i, keyCard.Number));
            var tempNumber = AllCardNumbers.First(x => x != keyCard.Number);
            tempList = AllCardSuits.ToList().Shuffle().Take(y);
            foreach (var i in tempList)
                result.Add(new Card(i, tempNumber));
            return result;
        }


        //以KeyCard为中心随机生成一个顺子牌
        private IList<Card> GetStraightCards(Card keyCard)
        {
            int upCount = 2;
            int downCount = 2;

            int tempIndex = AllCardNumbers.IndexOf(keyCard.Number);
            //首先判断keyCard是否为边缘牌
            //如果为边缘牌则调整上下需要延伸的牌的数量
            if (tempIndex <= 1)
            {
                upCount = tempIndex;
                downCount += 2 - tempIndex;
            }
            else if (tempIndex >= AllCardNumbers.Count - 2)
            {
                upCount += 2 - (AllCardNumbers.Count - 1 - tempIndex);
                downCount = AllCardNumbers.Count - 1 - tempIndex;
            }

            List<Card> result = new();
            result.Add(keyCard);
            //上下各延伸两张卡牌，花色随机
            for (int i = 0; i < upCount; i++)
            {
                var tempCard = new Card(AllCardSuits[RandomProvider.Next(0, AllCardSuits.Count)], AllCardNumbers[tempIndex - i - 1]);
                result.Add(tempCard);
            }
            for (int i = 0; i < downCount; i++)
            {
                var tempCard = new Card(AllCardSuits[RandomProvider.Next(0, AllCardSuits.Count)], AllCardNumbers[tempIndex + i + 1]);
                result.Add(tempCard);
            }


            result = result.OrderBy(x => x.Number).ToList();
            return result;
        }



        //得到N张相同的牌
        private IList<Card> GetNKindCards(Card keyCard, int nCard, IList<Card>? currentList = null)
        {
            listOfCards.Remove(keyCard);
            if (currentList != null)
            {
                foreach (var i in currentList)
                {
                    listOfCards.Remove(i);
                }
            }
            this.listOfCards.Shuffle();
            var result = listOfCards.Where(x => x.Number == keyCard.Number).Take(nCard - 1).ToList();
            result.Add(keyCard);
            if (currentList != null)
                result.AddRange(currentList);
            return result;
        }


    }
}
        
