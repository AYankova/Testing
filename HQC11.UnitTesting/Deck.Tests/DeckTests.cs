namespace Deck.Tests
{
    using System;
    using NUnit.Framework;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void CreateNewDeckShouldNotThrowAnException()
        {
            var deck = new Deck();
        }

        [Test]
        public void CreatingNewDeckShouldReturnNotNullTrumpCard()
        {
            var deck = new Deck();
            var trumpCard = deck.GetTrumpCard;

            Assert.IsNotNull(trumpCard);
        }

        [Test]
        public void CreatingNewDeckShouldReturnNotNullLeftCards()
        {
            var deck = new Deck();
            var cardsLeft = deck.CardsLeft;

            Assert.IsNotNull(cardsLeft);
        }

        [Test]
        public void CreatingNewDeckShouldReturn24CardsLeft()
        {
            var deck = new Deck();
            var cardsLeft = deck.CardsLeft;

            Assert.AreEqual(24, cardsLeft);
        }

        [Test]
        public void CreatingNewDeckAndChangingDefaultTrumpCardWithDifferentShouldReturnAnotherTrumpCard()
        {
            var deck = new Deck();
            var trumpCard = deck.GetTrumpCard;
            var newCard = new Card(CardSuit.Club, CardType.Nine);

            if (newCard.Equals(trumpCard))
            {
                Assert.Fail("The default trumpCard is the same as the changed! Ignore or rerun this test!");
            }

            deck.ChangeTrumpCard(newCard);

            Assert.AreNotSame(trumpCard, deck.GetTrumpCard);
        }

        [Test]
        public void CreatingNewDeckAndChangingDefaultTrumpCardWithTheSameTrumpCardShouldReturnTheSameTrumpCard()
        {
            var deck = new Deck();
            var trumpCard = deck.GetTrumpCard;

            deck.ChangeTrumpCard(trumpCard);

            Assert.AreSame(trumpCard, deck.GetTrumpCard);
        }

        [Test]
        public void CreatingNewDeckAndGettingNextCardShouldNotThrowAnException()
        {
            var deck = new Deck();
            var nextCard = deck.GetNextCard();
        }

        [Test]
        public void CreatingNewDeckAndGettingNextCardShouldReturn23LeftCards()
        {
            var deck = new Deck();
            var nextCard = deck.GetNextCard();

            Assert.AreEqual(23, deck.CardsLeft);
        }

        [TestCase(2)]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(22)]
        public void CreatingNewDeckAndGettingNextCardsShouldReturnCorrectLeftCards(int count)
        {
            var deck = new Deck();

            for (int i = 0; i < count; i++)
            {
                var nextCard = deck.GetNextCard();
            }

            Assert.AreEqual(24 - count, deck.CardsLeft);
        }

        [Test]
        public void CreatingNewDeckAndGetting24NextCardsShouldReturn0LeftCards()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                var nextCard = deck.GetNextCard();
            }

            Assert.AreEqual(0, deck.CardsLeft);
        }

        [TestCase(25)]
        [TestCase(40)]
        [TestCase(1000)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreatingNewDeckAndGettingMoreThan24NextCardsShouldThrowAnException(int countOfCards)
        {
            var deck = new Deck();

            for (int i = 0; i < countOfCards; i++)
            {
                var nextCard = deck.GetNextCard();
            }
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(23)]
        public void CreatingNewDeckAndGettingNextCardAndThenChangingTrumpCardShouldNotThrowAnException(int count)
        {
            var deck = new Deck();

            for (int i = 0; i < count; i++)
            {
                var nextCard = deck.GetNextCard();
            }

            deck.ChangeTrumpCard(new Card(CardSuit.Spade, CardType.Ace));
        }

        [Test]
        public void CreatingNewDeckAndGetting23NextCardsAndThenChangingTrumpCardShouldReturnNextCardTheSameAsTrumpCard()
        {
            var deck = new Deck();

            for (int i = 0; i < 23; i++)
            {
                var nextCard = deck.GetNextCard();
            }

            deck.ChangeTrumpCard(new Card(CardSuit.Spade, CardType.Ace));
            var lastCard = deck.GetNextCard();

            Assert.AreSame(lastCard, deck.GetTrumpCard);
        }
    }
}
