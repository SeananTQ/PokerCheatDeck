namespace TexasHoldem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;



    public class BestHand : IComparable<BestHand>
    {
        internal BestHand(HandRankType rankType, ICollection<CardNumber> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Cards collection should contains exactly 5 elements", nameof(cards));
            }

            this.Cards = cards;
            this.RankType = rankType;
        }

        // When comparing or ranking cards, the suit doesn't matter
        public ICollection<CardNumber> Cards { get; }

        public HandRankType RankType { get; }

        public int CompareTo(BestHand other)
        {
            if (this.RankType > other.RankType)
            {
                return 1;
            }

            if (this.RankType < other.RankType)
            {
                return -1;
            }

            switch (this.RankType)
            {
                case HandRankType.HIGH_CARD:
                    return CompareTwoHandsWithHighCard(this.Cards, other.Cards);
                case HandRankType.PAIR:
                    return CompareTwoHandsWithPair(this.Cards, other.Cards);
                case HandRankType.TWO_PAIR:
                    return CompareTwoHandsWithTwoPairs(this.Cards, other.Cards);
                case HandRankType.THREE_OF_A_KIND:
                    return CompareTwoHandsWithThreeOfAKind(this.Cards, other.Cards);
                case HandRankType.STRAIGHT:
                    return CompareTwoHandsWithStraight(this.Cards, other.Cards);
                case HandRankType.FLUSH:
                    return CompareTwoHandsWithHighCard(this.Cards, other.Cards);
                case HandRankType.FULL_HOUSE:
                    return CompareTwoHandsWithFullHouse(this.Cards, other.Cards);
                case HandRankType.FOUR_OF_A_KIND:
                    return CompareTwoHandsWithFourOfAKind(this.Cards, other.Cards);
                case HandRankType.STRAIGHT_FLUSH:
                    return CompareTwoHandsWithStraight(this.Cards, other.Cards);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static int CompareTwoHandsWithHighCard(
            ICollection<CardNumber> firstHand,
            ICollection<CardNumber> secondHand)
        {
            var firstSorted = firstHand.OrderByDescending(x => x).ToList();
            var secondSorted = secondHand.OrderByDescending(x => x).ToList();
            var cardsToCompare = Math.Min(firstHand.Count, secondHand.Count);
            for (var i = 0; i < cardsToCompare; i++)
            {
                if (firstSorted[i] > secondSorted[i])
                {
                    return 1;
                }

                if (firstSorted[i] < secondSorted[i])
                {
                    return -1;
                }
            }

            return 0;
        }

        private static int CompareTwoHandsWithPair(
            ICollection<CardNumber> firstHand,
            ICollection<CardNumber> secondHand)
        {
            var firstPairType = firstHand.GroupBy(x => x).First(x => x.Count() >= 2);
            var secondPairType = secondHand.GroupBy(x => x).First(x => x.Count() >= 2);

            if (firstPairType.Key > secondPairType.Key)
            {
                return 1;
            }

            if (firstPairType.Key < secondPairType.Key)
            {
                return -1;
            }

            // Equal pair => compare high card
            return CompareTwoHandsWithHighCard(firstHand, secondHand);
        }

        private static int CompareTwoHandsWithTwoPairs(
            ICollection<CardNumber> firstHand,
            ICollection<CardNumber> secondHand)
        {
            var firstPairType = firstHand.GroupBy(x => x).Where(x => x.Count() == 2).OrderByDescending(x => x.Key).ToList();
            var secondPairType = secondHand.GroupBy(x => x).Where(x => x.Count() == 2).OrderByDescending(x => x.Key).ToList();

            for (int i = 0; i < firstPairType.Count; i++)
            {
                if (firstPairType[i].Key > secondPairType[i].Key)
                {
                    return 1;
                }

                if (secondPairType[i].Key > firstPairType[i].Key)
                {
                    return -1;
                }
            }

            // Equal pairs => compare high card
            return CompareTwoHandsWithHighCard(firstHand, secondHand);
        }

        private static int CompareTwoHandsWithThreeOfAKind(
            ICollection<CardNumber> firstHand,
            ICollection<CardNumber> secondHand)
        {
            var firstThreeOfAKindType = firstHand.GroupBy(x => x).Where(x => x.Count() == 3).OrderByDescending(x => x.Key).FirstOrDefault();
            var secondThreeOfAKindType = secondHand.GroupBy(x => x).Where(x => x.Count() == 3).OrderByDescending(x => x.Key).FirstOrDefault();
            if (firstThreeOfAKindType.Key > secondThreeOfAKindType.Key)
            {
                return 1;
            }

            if (secondThreeOfAKindType.Key > firstThreeOfAKindType.Key)
            {
                return -1;
            }

            // Equal triples => compare high card
            return CompareTwoHandsWithHighCard(firstHand, secondHand);
        }

        private static int CompareTwoHandsWithStraight(
            ICollection<CardNumber> firstHand,
            ICollection<CardNumber> secondHand)
        {
            var firstBiggestCardType = firstHand.Max();
            if (firstBiggestCardType == CardNumber.Ace && firstHand.Contains(CardNumber.Five))
            {
                firstBiggestCardType = CardNumber.Five;
            }

            var secondBiggestCardType = secondHand.Max();
            if (secondBiggestCardType == CardNumber.Ace && secondHand.Contains(CardNumber.Five))
            {
                secondBiggestCardType = CardNumber.Five;
            }

            return firstBiggestCardType.CompareTo(secondBiggestCardType);
        }

        private static int CompareTwoHandsWithFullHouse(
            ICollection<CardNumber> firstHand,
            ICollection<CardNumber> secondHand)
        {
            var firstThreeOfAKindType = firstHand.GroupBy(x => x).Where(x => x.Count() == 3).OrderByDescending(x => x.Key).FirstOrDefault();
            var secondThreeOfAKindType = secondHand.GroupBy(x => x).Where(x => x.Count() == 3).OrderByDescending(x => x.Key).FirstOrDefault();

            if (firstThreeOfAKindType.Key > secondThreeOfAKindType.Key)
            {
                return 1;
            }

            if (secondThreeOfAKindType.Key > firstThreeOfAKindType.Key)
            {
                return -1;
            }

            var firstPairType = firstHand.GroupBy(x => x).First(x => x.Count() == 2);
            var secondPairType = secondHand.GroupBy(x => x).First(x => x.Count() == 2);
            return firstPairType.Key.CompareTo(secondPairType.Key);
        }

        private static int CompareTwoHandsWithFourOfAKind(
            ICollection<CardNumber> firstHand,
            ICollection<CardNumber> secondHand)
        {
            var firstFourOfAKingType = firstHand.GroupBy(x => x).First(x => x.Count() == 4);
            var secondFourOfAKindType = secondHand.GroupBy(x => x).First(x => x.Count() == 4);

            if (firstFourOfAKingType.Key > secondFourOfAKindType.Key)
            {
                return 1;
            }

            if (firstFourOfAKingType.Key < secondFourOfAKindType.Key)
            {
                return -1;
            }

            // Equal pair => compare high card
            return CompareTwoHandsWithHighCard(firstHand, secondHand);
        }
    }
}
