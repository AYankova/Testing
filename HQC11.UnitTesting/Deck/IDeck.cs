namespace Santase.Logic.Cards
{
    public interface IDeck
    {
        int CardsLeft { get; }

        Card GetTrumpCard { get; }

        void ChangeTrumpCard(Card newCard);

        Card GetNextCard();
    }
}