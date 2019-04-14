using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.EventsAggregator;
using RouletteSimulator.Core.Models.PersonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.ViewModels
{
    /// <summary>
    /// The PlayerViewModel class represents the view model for the Player module.
    /// </summary>
    public class PlayerViewModel : BindableBase
    {
        #region Fields

        private IEventAggregator _eventAggregator;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="eventAggregator"></param>
        public PlayerViewModel(IEventAggregator eventAggregator)
        {
            RoulettePlayer = new RoulettePlayer();    // Models.

            // Listen to events.
            RoulettePlayer.OnChipSelected += new ChipSelected(ChipSelectedEventHandler);
            RoulettePlayer.OnClearBets += new ClearBets(ClearBetsEventHandler);

            // Event aggregator.
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<BetPlacedEvent>().Subscribe(BetPlacedEventHandler, true);
            _eventAggregator.GetEvent<PayWinningsEvent>().Subscribe(PayWinningsEventHandler, true);
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the roulette player.
        /// </summary>
        public RoulettePlayer RoulettePlayer { get; }

        #endregion

        #region Methods

        /// <summary>
        /// The ChipSelectedEventHandler method is called to handle an OnChipSelected event.
        /// </summary>
        /// <param name="selectedChip"></param>
        private void ChipSelectedEventHandler(ChipType selectedChip)
        {
            // Publish the selected chip.
            _eventAggregator.GetEvent<SelectedChipEvent>().Publish(selectedChip);
        }

        /// <summary>
        /// The ChipSelectedEventHandler method is called to handle an BetPlacedEvent event.
        /// </summary>
        /// <param name="betAmount"></param>
        private void BetPlacedEventHandler(int betAmount)
        {
            // Deduct the bet from the player.
            RoulettePlayer.DeductBet(betAmount);
        }

        /// <summary>
        /// The ClearBetsEventHandler method is called to handle an OnClearBets event.
        /// </summary>
        private void ClearBetsEventHandler()
        {
            // Publish the bet cleared event.
            _eventAggregator.GetEvent<BetClearedEvent>().Publish();
        }

        /// <summary>
        /// The PayWinningsEventHandler handles an incoming PayWinningsEvent event.
        /// </summary>
        /// <param name="winnings"></param>
        private void PayWinningsEventHandler(int winnings)
        {
            // Pay the winnings to the player.
            RoulettePlayer.ReceiveWinnings(winnings);
        }

        #endregion
    }
}
