namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsThreeOfAKindTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsThreeOfAKindShouldThrowAnExceptionWhenAHandWithNullCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsThreeOfAKind(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsThreeOfAKindShouldThrowAnExceptionWhenANullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsThreeOfAKind(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsThreeOfAKindShouldThrowAnExceptionWhenAnInvalidHandWithLessThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsThreeOfAKind(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsThreeOfAKindShouldThrowAnExceptionWhenAnInvalidHandWithMoreThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsThreeOfAKind(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsThreeOfAKindShouldThrowAnExceptionWhenAnInvalidHandWithTwoSameCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsThreeOfAKind(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsThreeOfAKindShouldThrowAnExceptionWhenFiveOfAKindArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsThreeOfAKind(hand);
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseWhenHandContainsTwoPairs()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnTrueWhenPassedThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsAreTheSameSuit()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfThereAreOnlyTwoCardsTheSameFace()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeStraightFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Seven, CardSuit.Clubs), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeStraightFlushWithAce()
        {
            var cards = new List<ICard>() { new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeFourOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Ten, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeFullHouse()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeStraight()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnTrueIfCardsMakeThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Hearts), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeTwoPairs()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Hearts), new Card(CardFace.Queen, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsMakeOnePair()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfCardsAreHigh()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }
    }
}
