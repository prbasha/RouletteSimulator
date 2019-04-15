using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.EventsAggregator;
using RouletteSimulator.Core.Models.BoardModels;
using RouletteSimulator.Core.Models.ChipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Board.ViewModels
{
    /// <summary>
    /// The BoardViewModel class represents the view model for the Board module.
    /// </summary>
    public class BoardViewModel : BindableBase
    {
        #region Fields

        private IEventAggregator _eventAggregator;

        #endregion

        #region Constructors

        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="eventAggregator"></param>
        public BoardViewModel(IEventAggregator eventAggregator)
        {
            RouletteBoard = new RouletteBoard();    // Models.

            // Listen to events.
            Bet.OnBetPlaced += new BetPlaced(BetPlacedEventHandler);

            // Event aggregator.
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SelectedChipEvent>().Subscribe(SelectedChipEventHandler, ThreadOption.UIThread, true);
            _eventAggregator.GetEvent<WinningNumberEvent>().Subscribe(WinningNumberEventHandler, true);
            _eventAggregator.GetEvent<BetClearedEvent>().Subscribe(BetClearedEventHandler, true);
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the roulette board.
        /// </summary>
        public RouletteBoard RouletteBoard { get; }

        #endregion

        #region Methods

        /// <summary>
        /// The BetPlacedEventHandler handles an incoming OnBetPlaced event.
        /// </summary>
        /// <param name="betAmount"></param>
        private void BetPlacedEventHandler(int betAmount)
        {
            // Publish the bet.
            _eventAggregator.GetEvent<BetPlacedEvent>().Publish(betAmount);
        }

        /// <summary>
        /// The SelectedChipEventHandler handles an incoming SelectedChipEvent event.
        /// </summary>
        /// <param name="selectedChip"></param>
        private void SelectedChipEventHandler(ChipType selectedChip)
        {
            Bet.SelectedChip = selectedChip;    // Update chip selection.
        }

        /// <summary>
        /// The WinningNumberEventHandler handles an incoming WinningNumberEvent event.
        /// </summary>
        /// <param name="winningNumber"></param>
        private void WinningNumberEventHandler(int winningNumber)
        {
            // Publish the winnings.
            _eventAggregator.GetEvent<PayWinningsEvent>().Publish(RouletteBoard.CalculateWinnings(winningNumber));
        }

        /// <summary>
        /// The BetClearedEventHandler handles an incoming BetClearedEvent event.
        /// </summary>
        private void BetClearedEventHandler()
        {
            RouletteBoard.ClearBets();
        }

        #endregion
    }
}
