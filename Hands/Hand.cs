namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Hand : IHand
    {
        private IList<ICard> cards = new List<ICard>();

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return new List<ICard>(this.cards);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("list of cards", "can't be null or empty");
                }

                this.ValidateCard(value);
                this.cards = value;
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.Cards);
        }

        private void ValidateCard(IList<ICard> cards)
        {
            foreach (var card in cards)
            {
                if (card == null)
                {
                    throw new ArgumentNullException("card", "can't be null");
                }
            }
        }
    }
}
