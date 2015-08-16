namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsOnePairTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOnePairShouldThrowAnExceptionWhenAHandWithNullCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsOnePair(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsOnePairShouldThrowAnExceptionWhenANullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsOnePair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsOnePairShouldThrowAnExceptionWhenAnInvalidHandWithLessThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsOnePair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsOnePairShouldThrowAnExceptionWhenAnInvalidHandWithMoreThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsOnePair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsOnePairShouldThrowAnExceptionWhenAnInvalidHandWithTwoSameCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsOnePair(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsOnePairShouldThrowAnExceptionWhenFiveOfAKindArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsOnePair(hand);
        }

        [Test]
        public void IsOnePairShouldReturnTrueWhenHandContainsOnePair()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseWhenPassedThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsAreTheSameSuit()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnTrueIfThereAreTwoCardsTheSameFace()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeStraightFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Seven, CardSuit.Clubs), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeStraightFlushWithAce()
        {
            var cards = new List<ICard>() { new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeFourOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Ten, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeFullHouse()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeStraight()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Hearts), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsMakeTwoPairs()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Hearts), new Card(CardFace.Queen, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnTrueIfCardsMakeOnePair()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfCardsAreHigh()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }
    }
}
