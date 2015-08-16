namespace PlayerActionValidator.Tests
{
    using System;
    using NUnit.Framework;
    using Santase.Logic;
    using Santase.Logic.Cards;
    using Santase.Logic.Players;
    using Santase.Logic.RoundStates;

    // TODO: Implement unit tests for IsValid
    [TestFixture]
    public class PlayerActionValidatorTests
    {
        [Test]
        public void Testing()
        {
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.King), Announce.None);
            var first = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            var second = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Ten), Announce.None);
            //// IPlayer first;
            //// IPlayer second;
            //// first.AddCard(new Card(CardSuit.Club, CardType.Nine));
            var firstToPlay = PlayerPosition.FirstPlayer;
            //// var gameRound = new GameRound(first, second, PlayerPosition.SecondPlayer);
            //// IGameRound gameRound;
            //// var context = new PlayerTurnContext(new StartRoundState(gameRound), new Card(CardSuit.Diamond, CardType.Ten), 24);
        }
    }
}
