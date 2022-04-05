namespace TexasHoldem
{
    using System.Collections.Generic;
    using System.Linq;


    // For performance considerations this class is not implemented using Chain of Responsibility
    // 出于性能考虑，此类未使用责任链实现
    public class HandEvaluator : IHandEvaluator
    {
        private const int ComparableCards = 5;

        /// <summary>
        /// 传入玩家的手牌和公共牌，计算出其符合的最大牌型。
        /// </summary>
        /// <param name="cards">一个玩家的牌+所有公开的公共牌（总共至少5张）.</param>
        /// <returns>返回 BestHand 类型的对象</returns>
        public BestHand GetBestHand(IEnumerable<Card> cards)
        {
            //花色数组
            var cardSuitCounts = new int[(int)CardSuit.Spade + 1];
            //类型数组
            var cardNumberCounts = new int[(int)CardNumber.Ace + 1];
            foreach (var card in cards)
            {
                cardSuitCounts[(int)card.Suit]++;
                cardNumberCounts[(int)card.Number]++;
            }

            // Flushes  同花
            if (cardSuitCounts.Any(x => x >= ComparableCards))
            {
                // Straight flush
                var straightFlushCards = this.GetStraightFlushCards(cardSuitCounts, cards);
                if (straightFlushCards.Count > 0)
                {
                    return new BestHand(HandRankType.STRAIGHT_FLUSH, straightFlushCards);
                }

                // Flush - it is not possible to have Flush and either Four of a kind or Full house at the same time
                for (var i = 0; i < cardSuitCounts.Length; i++)
                {
                    if (cardSuitCounts[i] >= ComparableCards)
                    {
                        var flushCards =
                            cards.Where(x => x.Suit == (CardSuit)i)
                                .Select(x => x.Number)
                                .OrderByDescending(x => x)
                                .Take(ComparableCards)
                                .ToList();
                        return new BestHand(HandRankType.FLUSH, flushCards);
                    }
                }
            }

            // Four of a kind
            
            if (cardNumberCounts.Any(x => x == 4)) //有任意计数值等于4
            {
                var bestFourOfAKind = this.GetTypesWithNCards(cardNumberCounts, 4)[0];
                var bestCards = new List<CardNumber>
                                    {
                                        bestFourOfAKind,
                                        bestFourOfAKind,
                                        bestFourOfAKind,
                                        bestFourOfAKind,
                                        cards.Where(x => x.Number != bestFourOfAKind).Max(x => x.Number), //在其余的手牌和公共牌中找出一个数字最大的牌（德州扑克花色无大小之分）
                                    };

                return new BestHand(HandRankType.FOUR_OF_A_KIND, bestCards);
            }

            // Full
            var pairTypes = this.GetTypesWithNCards(cardNumberCounts, 2);
            var threeOfAKindTypes = this.GetTypesWithNCards(cardNumberCounts, 3);
            if ((pairTypes.Count > 0 && threeOfAKindTypes.Count > 0) || threeOfAKindTypes.Count > 1)
            {
                var bestCards = new List<CardNumber>();
                for (var i = 0; i < 3; i++)
                {
                    bestCards.Add(threeOfAKindTypes[0]);
                }

                if (threeOfAKindTypes.Count > 1)
                {
                    for (var i = 0; i < 2; i++)
                    {
                        bestCards.Add(threeOfAKindTypes[1]);
                    }
                }

                if (pairTypes.Count > 0)
                {
                    for (var i = 0; i < 2; i++)
                    {
                        bestCards.Add(pairTypes[0]);
                    }
                }

                return new BestHand(HandRankType.FULL_HOUSE, bestCards);
            }

            // Straight
            var straightCards = this.GetStraightCards(cardNumberCounts);
            if (straightCards != null)
            {
                return new BestHand(HandRankType.STRAIGHT, straightCards);
            }

            // 3 of a kind
            if (threeOfAKindTypes.Count > 0)
            {
                var bestThreeOfAKindType = threeOfAKindTypes[0];
                var bestCards =
                    cards.Where(x => x.Number != bestThreeOfAKindType)
                        .Select(x => x.Number)
                        .OrderByDescending(x => x)
                        .Take(ComparableCards - 3).ToList();
                bestCards.AddRange(Enumerable.Repeat(bestThreeOfAKindType, 3));

                return new BestHand(HandRankType.THREE_OF_A_KIND, bestCards);
            }

            // Two pairs
            if (pairTypes.Count >= 2)
            {
                var bestCards = new List<CardNumber>
                                    {
                                        pairTypes[0],
                                        pairTypes[0],
                                        pairTypes[1],
                                        pairTypes[1],
                                        cards.Where(x => x.Number != pairTypes[0] && x.Number != pairTypes[1])
                                            .Max(x => x.Number),
                                    };
                return new BestHand(HandRankType.TWO_PAIR, bestCards);
            }

            // Pair
            if (pairTypes.Count == 1)
            {
                var bestCards =
                    cards.Where(x => x.Number != pairTypes[0])
                        .Select(x => x.Number)
                        .OrderByDescending(x => x)
                        .Take(3).ToList();
                bestCards.Add(pairTypes[0]);
                bestCards.Add(pairTypes[0]);
                return new BestHand(HandRankType.PAIR, bestCards);
            }
            else
            {
                // High card
                var bestCards = new List<CardNumber>();
                for (var i = cardNumberCounts.Length - 1; i >= 0; i--)
                {
                    if (cardNumberCounts[i] > 0)
                    {
                        bestCards.Add((CardNumber)i);
                    }

                    if (bestCards.Count == ComparableCards)
                    {
                        break;
                    }
                }

                return new BestHand(HandRankType.HIGH_CARD, bestCards);
            }
        }

        private IList<CardNumber> GetTypesWithNCards(int[] cardTypeCounts, int n)
        {
            var pairs = new List<CardNumber>();
            for (var i = cardTypeCounts.Length - 1; i >= 0; i--)
            {
                if (cardTypeCounts[i] == n)
                {
                    pairs.Add((CardNumber)i);
                }
            }

            return pairs;
        }

        private ICollection<CardNumber> GetStraightFlushCards(int[] cardSuitCounts, IEnumerable<Card> cards)
        {
            var straightFlushCardTypes = new List<CardNumber>();
            for (var i = 0; i < cardSuitCounts.Length; i++)
            {
                if (cardSuitCounts[i] < ComparableCards)
                {
                    continue;
                }

                var cardTypeCounts = new int[(int)CardNumber.Ace + 1];
                foreach (var card in cards)
                {
                    if (card.Suit == (CardSuit)i)
                    {
                        cardTypeCounts[(int)card.Number]++;
                    }
                }

                var bestStraight = this.GetStraightCards(cardTypeCounts);
                if (bestStraight != null)
                {
                    straightFlushCardTypes.AddRange(bestStraight);
                }
            }

            return straightFlushCardTypes;
        }

        private ICollection<CardNumber> GetStraightCards(int[] cardTypeCounts)
        {
            var lastCardType = cardTypeCounts.Length;
            var straightLength = 0;
            for (var i = cardTypeCounts.Length - 1; i >= 1; i--)
            {
                var hasCardsOfType = cardTypeCounts[i] > 0 || (i == 1 && cardTypeCounts[(int)CardNumber.Ace] > 0);
                if (hasCardsOfType && i == lastCardType - 1)
                {
                    straightLength++;
                    if (straightLength == ComparableCards)
                    {
                        var bestStraight = new List<CardNumber>(ComparableCards);
                        for (var j = i; j <= i + ComparableCards - 1; j++)
                        {
                            if (j == 1)
                            {
                                bestStraight.Add(CardNumber.Ace);
                            }
                            else
                            {
                                bestStraight.Add((CardNumber)j);
                            }
                        }

                        return bestStraight;
                    }
                }
                else
                {
                    straightLength = 0;
                }

                lastCardType = i;
            }

            return null;
        }
    }
}
