using Prism.Events;
using Prism.Mvvm;
using RouletteSimulator.Core.EventAggregator;
using RouletteSimulator.Core.Models.PersonModels;
using RouletteSimulator.Core.Models.WheelModels;

namespace Dealer.ViewModels
{
    /// <summary>
    /// The DealerViewModel class represents the view model for the Dealer module.
    /// </summary>
    public class DealerViewModel : BindableBase
    {
        #region Fields

        private IEventAggregator _eventAggregator;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="eventAggregator"></param>
        public DealerViewModel(IEventAggregator eventAggregator)
        {
            RouletteDealer = new RouletteDealer();    // Models.

            // Listen to events.
            RouletteDealer.OnSpinWheel += new SpinWheel(SpinWheelEventHandler);
            RouletteDealer.OnTossBall += new TossBall(TossBallEventHandler);
            RouletteDealer.OnPlaceBets += new PlaceBets(PlaceBetsEventHandler);
            
            // Event aggregator.
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<WheelSpinningEvent>().Subscribe(WheelSpinningEventHandler, true);
            _eventAggregator.GetEvent<BallTossedEvent>().Subscribe(BallTossedEventHandler, true);
            _eventAggregator.GetEvent<WinningNumberEvent>().Subscribe(WinningNumberEventHandler, true);
            
            RouletteDealer.PlaceBets = true;    // Start accepting bets.
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the roulette dealer.
        /// </summary>
        public RouletteDealer RouletteDealer { get; }

        #endregion

        #region Methods

        /// <summary>
        /// The SpinWheelEventHandler method is called to handle an OnSpinWheel event.
        /// </summary>
        private void SpinWheelEventHandler()
        {
            _eventAggregator.GetEvent<SpinWheelEvent>().Publish();  // Spin the wheel.
        }

        /// <summary>
        /// The TossBallEventHandler method is called to handle an OnTossBall event.
        /// </summary>
        private void TossBallEventHandler()
        {
            _eventAggregator.GetEvent<TossBallEvent>().Publish();   // Toss the ball.
        }

        /// <summary>
        /// The PlaceBetsEventHandler method is called to handle an OnPlaceBets event.
        /// </summary>
        /// <param name="placeBets"></param>
        private void PlaceBetsEventHandler(bool placeBets)
        {
            _eventAggregator.GetEvent<PlaceBetsEvent>().Publish(placeBets); // Announce place bets status.
        }

        /// <summary>
        /// The WheelSpinningEventHandler method is called to handle a WheelSpinningEvent event.
        /// </summary>
        /// <param name="wheelSpinning"></param>
        private void WheelSpinningEventHandler(bool wheelSpinning)
        {
            RouletteDealer.IsWheelSpinning = wheelSpinning; // Update the status of the wheel.
        }

        /// <summary>
        /// The BallTossedEventHandler method is called to handle a BallTossedEvent event.
        /// </summary>
        /// <param name="wheelSpinning"></param>
        private void BallTossedEventHandler(bool ballTossed)
        {
            RouletteDealer.IsBallTossed = ballTossed;   // Update the status of the ball.
        }

        /// <summary>
        /// The WinningNumberEventHandler method is called to handle a WinningNumberEvent event.
        /// </summary>
        /// <param name="winningNumber"></param>
        private void WinningNumberEventHandler(Pocket winningNumber)
        {
            RouletteDealer.AnnounceWinningNumber(winningNumber);    // Announce the winning number.
        }

        #endregion
    }
}
