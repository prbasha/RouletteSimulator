using Prism.Events;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.Models.ChipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.EventsAggregator
{
    /// <summary>
    /// The SelectedChipEvent class represents a selected-chip event.
    /// </summary>
    public class SelectedChipEvent : PubSubEvent<ChipType> { }

    /// <summary>
    /// The BetPlacedEvent class represents a bet-placed event.
    /// </summary>
    public class BetPlacedEvent : PubSubEvent<int> { }

    /// <summary>
    /// The BetClearedEvent class represents a bet-cleared event.
    /// </summary>
    public class BetClearedEvent : PubSubEvent { }

    /// <summary>
    /// The WinningNumberEvent class represents a winning-number event.
    /// </summary>
    public class WinningNumberEvent : PubSubEvent<int> { }

    /// <summary>
    /// The PayWinningsEvent class represents a pay-winnings event.
    /// </summary>
    public class PayWinningsEvent : PubSubEvent<int> { }

    /// <summary>
    /// The SpinWheelEvent class represents a spin-wheel event.
    /// </summary>
    public class SpinWheelEvent : PubSubEvent { }

    /// <summary>
    /// The TossBallEvent class represents a toss-ball event.
    /// </summary>
    public class TossBallEvent : PubSubEvent { }

    /// <summary>
    /// The NoMoreBetsEvent class represents a no-more-bets event.
    /// </summary>
    public class NoMoreBetsEvent : PubSubEvent { }

    /// <summary>
    /// The WheelSpinningEvent class represents a wheel-spinning event.
    /// </summary>
    public class WheelSpinningEvent : PubSubEvent<bool> { }

    /// <summary>
    /// The BallTossedEvent class represents a ball-tossed event.
    /// </summary>
    public class BallTossedEvent : PubSubEvent<bool> { }
}
