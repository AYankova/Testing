namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsFourOfAKindTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFourOfAKindShouldThrowAnExceptionWhenAHandWithNullCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsFourOfAKind(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFourOfAKindShouldThrowAnExceptionWhenANullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsFourOfAKind(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindShouldThrowAnExceptionWhenAnInvalidHandWithLessThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFourOfAKind(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindShouldThrowAnExceptionWhenAnInvalidHandWithMoreThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFourOfAKind(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindShouldThrowAnExceptionWhenAnInvalidHandWithTwoSameCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFourOfAKind(hand);
        }

        [Test]
        public void IsFourOfAKindShouldReturnTrueWhenAValidHandWithFourOfAKindCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindShouldThrowAnExceptionWhenFiveOfAKindCardsArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFourOfAKind(hand);
        }

        [Test]
        public void IsFourOfAKindShouldReturnFalseWhenThreeOfAKindArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [Test]
        public void IsFourOfAKindShouldReturnFalseWhenTwoPairsArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Hearts), new Card(CardFace.Ten, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [Test]
        public void IsFourOfAKindShouldReturnFalseWhenOnePairIsPassed()
        {
            var checker = new PokerHandsChecker();
            var cards = new List<ICard> { new Card(CardFace.Four, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Diamonds), new Card(CardFace.Six, CardSuit.Hearts), new Card(CardFace.Seven, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Hearts) };
            var hand = new Hand(cards);

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }
    }
}
