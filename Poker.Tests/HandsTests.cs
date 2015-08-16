namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class HandsTests
    {
        [Test]
        public void CreatingNewHandWithValidCardsShouldNotThrowAnException()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Three, CardSuit.Clubs), new Card(CardFace.Ten, CardSuit.Spades), new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatingNewHandWithNullListOfCardsShouldThrowAnException()
        {
            List<ICard> cards = null;
            var hand = new Hand(cards);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatingNewHandWithListOfCardsContainingNullCardShouldThrowAnException()
        {
            var cards = new List<ICard>() { new Card(CardFace.King, CardSuit.Spades), new Card(CardFace.Three, CardSuit.Clubs), null, new Card(CardFace.Queen, CardSuit.Spades), new Card(CardFace.King, CardSuit.Diamonds) };
            var hand = new Hand(cards);
        }

        [Test]
        public void CreatingAHandWithValidListOfCardsShouldReturnCorrectToString()
        {
            var cardA = new Card(CardFace.King, CardSuit.Spades);
            var cardB = new Card(CardFace.Three, CardSuit.Clubs);
            var cards = new List<ICard>() { cardA, cardB };
            var hand = new Hand(cards);
            var expectedValue = cardA.ToString() + Environment.NewLine + cardB.ToString();

            Assert.AreEqual(expectedValue, hand.ToString());
        }
    }
}
