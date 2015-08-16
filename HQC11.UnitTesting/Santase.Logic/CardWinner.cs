namespace Santase.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Santase.Logic.Cards;

    public class CardWinner : ICardWinner
    {
        public PlayerPosition Winner(Card firstPlayerCard, Card secondPlayerCard, CardSuit trumpSuit)
        {
            if (firstPlayerCard.Suit == secondPlayerCard.Suit)
            {
                if (firstPlayerCard.GetValue() > secondPlayerCard.GetValue())
                {
                    return PlayerPosition.FirstPlayer;
                }
                else
                {
                    return PlayerPosition.SecondPlayer;
                }
            }

            if (secondPlayerCard.Suit == trumpSuit)
            {
                return PlayerPosition.SecondPlayer;
            }

            return PlayerPosition.FirstPlayer;
        }
    }
}