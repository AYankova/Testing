namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsFlushTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFlushShouldThrowAnExceptionWhenAHandWithNullCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsFlush(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFlushShouldThrowAnExceptionWhenANullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsFlush(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFlushShouldThrowAnExceptionWhenAnInvalidHandWithLessCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFlush(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFlushShouldThrowAnExceptionWhenAnInvalidHandWithMoreCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFlush(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFlushShouldThrowAnExceptionWhenAnInvalidHandWithTwoSameCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFlush(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFlushShouldThrowAnExceptionWhenFiveOfAKindArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFlush(hand);
        }

        [Test]
        public void IsFlushShouldReturnTrueWhen5NotStraightSpadesArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Spades), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [Test]
        public void IsFlushShouldReturnFalseWhen5StraightSpadesArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Jack, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [Test]
        public void IsFlushShouldReturnFalseWhen4OfSameSuitArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Jack, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }
    }
}
