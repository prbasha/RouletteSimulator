using Prism.Events;
using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.EventAggregator;
using RouletteSimulator.Core.Models.BoardModels;

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
            RouletteBoard.OnBoardCleared += new BoardCleared(BoardClearedEventHandler);

            // Event aggregator.
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SelectedChipEvent>().Subscribe(SelectedChipEventHandler, true);
            _eventAggregator.GetEvent<WinningNumberEvent>().Subscribe(WinningNumberEventHandler, true);
            _eventAggregator.GetEvent<BetClearedEvent>().Subscribe(BetClearedEventHandler, true);
            _eventAggregator.GetEvent<PlaceBetsEvent>().Subscribe(PlaceBetsEventHandler, true);
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
            _eventAggregator.GetEvent<BetPlacedEvent>().Publish(betAmount); // Publish the bet.
        }

        /// <summary>
        /// The BoardClearedEventHandler handles an incoming OnBoardCleared event.
        /// </summary>
        private void BoardClearedEventHandler()
        {
            _eventAggregator.GetEvent<BoardClearedEvent>().Publish();   // Publish the board cleared event.
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
            _eventAggregator.GetEvent<PayWinningsEvent>().Publish(RouletteBoard.CalculateWinnings(winningNumber));  // Publish the winnings.
        }

        /// <summary>
        /// The BetClearedEventHandler handles an incoming BetClearedEvent event.
        /// </summary>
        private void BetClearedEventHandler()
        {
            RouletteBoard.ClearBets();  // Clear all bets.
        }

        /// <summary>
        /// The PlaceBetsEventHandler handles an incoming PlaceBetsEvent event.
        /// </summary>
        private void PlaceBetsEventHandler(bool placeBets)
        {
            Bet.PlaceBets = placeBets;
        }

        #endregion
    }
}
