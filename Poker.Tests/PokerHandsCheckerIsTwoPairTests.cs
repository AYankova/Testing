namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsTwoPairTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsTwoPairShouldThrowAnExceptionWhenAHandWithNullCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsTwoPair(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsTwoPairShouldThrowAnExceptionWhenANullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsTwoPair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsTwoPairPairShouldThrowAnExceptionWhenAnInvalidHandWithLessThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsTwoPair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsTwoPairShouldThrowAnExceptionWhenAnInvalidHandWithMoreThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsTwoPair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsTwoPairShouldThrowAnExceptionWhenAnInvalidHandWithTwoSameCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsTwoPair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsTwoPairShouldThrowAnExceptionWhenFiveOfAKindArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsTwoPair(hand);
        }

        [Test]
        public void IsTwoPairShouldReturnTrueWhenHandContainsTwoPairs()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseWhendPassedThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfAllCardsAreTheSameSuit()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfThereAreOnlyTwoCardsTheSameFace()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeStraightFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Seven, CardSuit.Clubs), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeStraightFlushWithAce()
        {
            var cards = new List<ICard>() { new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeFourOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Ten, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeFullHouse()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeStraight()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Hearts), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnTrueIfCardsMakeTwoPairs()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Hearts), new Card(CardFace.Queen, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsMakeOnePair()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfCardsAreHigh()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }
    }
}
