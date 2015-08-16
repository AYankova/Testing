namespace Poker.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CardTests
    {
        [Test]
        public void CreatingACardShouldNotThrowAnException()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);
        }

        [Test]
        public void CreatingACardAndInvokingToStringToItShouldNotThrowAnException()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);
            card.ToString();
        }

        [Test]
        public void CreatingACardAndInvokingToStringToItShouldReturnCorrectString()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);
            var expectedValue = "Ace of Hearts";

            Assert.AreEqual(expectedValue, card.ToString());
        }

        [Test]
        public void CreatingTwoSameCardsAndInvokingEqualsShouldReturnThatCardsAreEqual()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);
            var anotherCard = new Card(CardFace.Ace, CardSuit.Hearts);

            Assert.IsTrue(card.Equals(anotherCard));
        }

        [Test]
        public void CreatingTwoDifferentCardsAndInvokingEqualsShouldReturnThatCardsAreNotEqual()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);
            var anotherCard = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.IsFalse(card.Equals(anotherCard));
        }

        [Test]
        public void CreatingACardAndTryingToCompareItWithAnObjectOfDifferentTypeShoukdNotThrowAnException()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);

            card.Equals(CardFace.Ace);
        }

        [Test]
        public void CreatingACardAndComparingItWithAnObjectOfDifferentTypeShoukdReturnFalse()
        {
            var card = new Card(CardFace.Ace, CardSuit.Hearts);

            Assert.IsFalse(card.Equals(CardFace.Ace));
        }
    }
}
