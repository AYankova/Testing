namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ValidHandCount = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand", "can't be null");
            }

            if (hand.Cards.Count != ValidHandCount)
            {
                throw new ArgumentException("hand", string.Format("cards in a hand should be exactly {0}", ValidHandCount));
            }

            if (!this.ContainDifferentCards(hand))
            {
                throw new ArgumentException("hand", "duplicate hands are found. Don't cheat!");
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool areTheSameSuit = this.AreAllCardsTheSameSuit(hand);
            bool areStraight = this.AreCardsStraight(hand);

            return isValidHand && areTheSameSuit && areStraight;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (this.IsValidHand(hand))
            {
                var grouped = hand.Cards.GroupBy(card => card.Face).Where(gr => gr.Count() == 4);
                return grouped.Count() != 0;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool hasTwoOfAKind = this.HasTwoOfAKind(hand);
            bool hasThreeOfAKind = this.HasThreeOfAKind(hand);

            return isValidHand && hasTwoOfAKind && hasThreeOfAKind;
        }

        public bool IsFlush(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool areTheSameSuit = this.AreAllCardsTheSameSuit(hand);
            bool isNotStraightFlush = !this.IsStraightFlush(hand);

            return isValidHand && areTheSameSuit && isNotStraightFlush;
        }

        public bool IsStraight(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool areTheSameSuit = this.AreAllCardsTheSameSuit(hand);

            if (isValidHand && areTheSameSuit)
            {
                return false;
            }

            bool areStraight = this.AreCardsStraight(hand);

            return isValidHand && areStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool hasTwoOfAKind = this.HasTwoOfAKind(hand);
            bool hasThreeOfAKind = this.HasThreeOfAKind(hand);

            return isValidHand && hasThreeOfAKind && !hasTwoOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool hasTwoPairs = this.HasTwoPairs(hand);

            return isValidHand && hasTwoPairs;
        }

        public bool IsOnePair(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool hasOnePair = this.HasOnePair(hand);
            bool hasThreeOfAKind = this.HasThreeOfAKind(hand);

            return this.IsValidHand(hand) && hasOnePair && !hasThreeOfAKind;
        }

        public bool IsHighCard(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool isHighCard = !this.IsFlush(hand) && !this.IsStraight(hand) && !this.IsStraightFlush(hand) && !this.IsFullHouse(hand) && !this.IsOnePair(hand) && !this.IsTwoPair(hand) && !this.IsThreeOfAKind(hand) && !this.IsFourOfAKind(hand);

            return isValidHand && isHighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool ContainDifferentCards(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Equals(hand.Cards[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool AreAllCardsTheSameSuit(IHand hand)
        {
            return hand.Cards.GroupBy(card => card.Suit).Count() == 1;
        }

        private bool AreCardsStraight(IHand hand)
        {
            var sortedHand = hand.Cards.Select(value => (int)value.Face).OrderBy(value => value).ToArray();

            if (sortedHand.Contains((int)CardFace.Ace) && sortedHand.Contains((int)CardFace.Two))
            {
                var index = Array.IndexOf(sortedHand, (int)CardFace.Ace);
                sortedHand[index] = 1;
                sortedHand = sortedHand.OrderBy(value => value).ToArray();
            }

            for (int i = 0; i < sortedHand.Length - 1; i++)
            {
                if (sortedHand[i] + 1 != sortedHand[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasThreeOfAKind(IHand hand)
        {
            var grouped = hand.Cards.GroupBy(card => card.Face);
            bool hasThreeOfAKind = grouped.Any(gr => gr.Count() == 3);

            return hasThreeOfAKind;
        }

        private bool HasTwoOfAKind(IHand hand)
        {
            var grouped = hand.Cards.GroupBy(card => card.Face);
            bool hasTwoOfAKind = grouped.Any(gr => gr.Count() == 2);

            return hasTwoOfAKind;
        }

        private bool HasTwoPairs(IHand hand)
        {
            var grouped = hand.Cards.GroupBy(card => card.Face);
            var groupsWithTwoPairs = grouped.Count(gr => gr.Count() == 2);
            bool hasTwoPairs = groupsWithTwoPairs == 2;

            return hasTwoPairs;
        }

        private bool HasOnePair(IHand hand)
        {
            var grouped = hand.Cards.GroupBy(card => card.Face);
            var groupsWithTwoPairs = grouped.Count(gr => gr.Count() == 2);
            bool hasOnePairs = groupsWithTwoPairs == 1;

            return hasOnePairs;
        }
    }
}
