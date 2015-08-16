namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerIsValidHandTests
    {
        [Test]
        public void IsValidHandShouldReturnTrueIfValidHandIsPassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsValidHandShouldThrowAnExceptionIfNullListOfCardsIsPassed()
        {
            List<ICard> cards = null;
            var checker = new PokerHandsChecker();

            checker.IsValidHand(new Hand(cards));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsValidHandShouldThrowAnExceptionIfNullHandIsPassed()
        {
            IHand hand = null;
            var checker = new PokerHandsChecker();

            checker.IsValidHand(hand);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(9)]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldThrowAnExceptionIfCountOfTheCardsInTheHandIsNotExactly5(int count)
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards.Take(count).ToList());
            var checker = new PokerHandsChecker();

            checker.IsValidHand(hand);
        }

       [Test]
       [ExpectedException(typeof(ArgumentException))]
        public void IsValidHandShouldThrowAnExceptionWhenFiveCardsWithTheSameFaceArePassed()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.King, CardSuit.Clubs), new Card(CardFace.King, CardSuit.Hearts), new Card(CardFace.King, CardSuit.Diamonds), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();

            checker.IsValidHand(hand);
        }

       [Test]
       [ExpectedException(typeof(ArgumentException))]
       public void IsValidHandShouldThrowAnExceptionWhenTwoEqualCardsArePassed()
       {
           var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Two, CardSuit.Clubs), new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.King, CardSuit.Spades) };
           var hand = new Hand(cards);
           var checker = new PokerHandsChecker();

           checker.IsValidHand(hand);
       }
    }
}
