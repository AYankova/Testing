namespace Santase.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Santase.Logic.Cards;

    public interface IGameHand
    {
        PlayerPosition Winner { get; }

        Card FirstPlayerCard { get; }

        Announce FirstPlayerAnnounce { get; }

        Card SecondPlayerCard { get; }

        Announce SecondPlayerAnnounce { get; }

        PlayerPosition GameClosedBy { get; }

        void Start();
    }
}