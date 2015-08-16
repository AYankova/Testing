namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsFullHouseTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFullHouseShouldThrowAnExceptionWhenAHandWithNullCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsFullHouse(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFullHouseShouldThrowAnExceptionWhenANullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsFullHouse(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFullHouseShouldThrowAnExceptionWhenAnInvalidHandWithLessThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFullHouse(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFullHouseShouldThrowAnExceptionWhenAnInvalidHandWithMoreThan5CardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Spades), new Card(CardFace.Four, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFullHouse(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFullHouseShouldThrowAnExceptionWhenAnInvalidHandWithTwoSameCardsIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFullHouse(hand);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFullHouseShouldThrowAnExceptionWhenFiveOfAKindArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsFullHouse(hand);
        }

        [Test]
        public void IsFullHouseShouldReturnFalseWhenHandContainsTwoPairs()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseWhendPassedThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsAreTheSameSuit()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Two, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfThereAreTwoCardsTheSameFace()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsMakeStraightFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Clubs), new Card(CardFace.Seven, CardSuit.Clubs), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsMakeStraightFlushWithAce()
        {
            var cards = new List<ICard>() { new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsMakeFourOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Ten, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnTrueIfCardsMakeFullHouse()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Ten, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Hearts), new Card(CardFace.Four, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsMakeFlush()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsMakeStraight()
        {
            var cards = new List<ICard>() { new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Seven, CardSuit.Spades), new Card(CardFace.Six, CardSuit.Clubs), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Four, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsAreThreeOfAKind()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Ace, CardSuit.Hearts), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsMakeTwoPairs()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Hearts), new Card(CardFace.Queen, CardSuit.Diamonds), new Card(CardFace.Three, CardSuit.Spades) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsMakeOnePair()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ace, CardSuit.Spades), new Card(CardFace.Eight, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Clubs), new Card(CardFace.Three, CardSuit.Clubs) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfCardsAreHigh()
        {
            var cards = new List<ICard>() { new Card(CardFace.Ace, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Clubs), new Card(CardFace.Nine, CardSuit.Spades), new Card(CardFace.Five, CardSuit.Diamonds), new Card(CardFace.Four, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }
    }
}
