namespace Santase.Logic.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Santase.Logic.Cards;

    public abstract class BasePlayer : IPlayer
    {
        protected IList<Card> cards;

        protected BasePlayer()
        {
            this.cards = new List<Card>();
        }

        public virtual void AddCard(Card card)
        {
            this.cards.Add(card);
        }

        public abstract PlayerAction GetTurn(PlayerTurnContext context, IPlayerActionValidater actionValidater);

        public virtual void EndTurn(PlayerTurnContext context)
        {
        }

        protected Announce PossibleAnnounce(Card cardToBePlayed, Card trumpCard)
        {
            CardType cardTypeToSearch;
            if (cardToBePlayed.Type == CardType.Queen)
            {
                cardTypeToSearch = CardType.King;
            }
            else if (cardToBePlayed.Type == CardType.King)
            {
                cardTypeToSearch = CardType.Queen;
            }
            else
            {
                return Announce.None;
            }

            var cardToSearch = new Card(
                cardToBePlayed.Suit,
                cardTypeToSearch);

            if (!this.cards.Contains(cardToSearch))
            {
                return Announce.None;
            }

            if (cardToBePlayed.Suit == trumpCard.Suit)
            {
                return Announce.Fourty;
            }
            else
            {
                return Announce.Twenty;
            }
        }
    }
}