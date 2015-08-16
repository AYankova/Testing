namespace Santase.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Santase.Logic.Cards;

    public interface ICardWinner
    {
        PlayerPosition Winner(
            Card firstPlayerCard,
            Card secondPlayerCard,
            CardSuit trumpSuit);
    }
}