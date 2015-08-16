namespace Santase.Logic.Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDeck
    {
        int CardsLeft { get; }

        Card GetTrumpCard { get; }

        void ChangeTrumpCard(Card newCard);

        Card GetNextCard();
    }
}