namespace Santase.Logic.Players
{
    using System;
    using Santase.Logic.Cards;

    public interface IPlayer
    {
        void AddCard(Card card);

        PlayerAction GetTurn(
            PlayerTurnContext context,
            IPlayerActionValidater actionValidator);

        void EndTurn(PlayerTurnContext context);
    }
}