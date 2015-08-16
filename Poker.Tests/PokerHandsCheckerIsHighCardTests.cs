namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsHighCardTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsHighCardShouldThrowAnExceptionWhenAHandWithNullCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsHighCard(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsHighCardShouldThrowAnExceptionWhenANullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsHighCard(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsHighCardShouldThrowAnExceptionWhenAnInvalidHandWithLessThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsHighCard(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsHighCardShouldThrowAnExceptionWhenAnInvalidHandWithMoreThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsHighCard(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsHighCardShouldThrowAnExceptionWhenAnInvalidHandWithTwoSameCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsHighCard(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsHighCardShouldThrowAnExceptionWhenFiveOfAKindArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsHighCard(hand);
        }

        [Test]
        public void IsHighCardShouldReturnTrueIfCardFacesAreDifferentAndDontMakeFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Hearts), new Card(CardFace.Seven, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsAreTheSameSuit()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfThereAreTwoCardsTheSameFace()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeStraightFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Seven, CardSuit.Clubs), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeStraightFlushWithAce()
        {
            var cards = new List<ICard>() { new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeFourOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Ten, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeFullHouse()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeStraight()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Hearts), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeTwoPair()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Hearts), new Card(CardFace.Queen, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseIfCardsMakeOnePair()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCardShouldReturnTrueIfCardsAreHigh()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsHighCard(hand));
        }
    }
}
