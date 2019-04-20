using Prism.Events;
using Prism.Mvvm;
using RouletteSimulator.Core.EventAggregator;
using RouletteSimulator.Core.Models.PersonModels;

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
            // Spin the wheel.
            _eventAggregator.GetEvent<SpinWheelEvent>().Publish();
        }

        /// <summary>
        /// The TossBallEventHandler method is called to handle an OnTossBall event.
        /// </summary>
        private void TossBallEventHandler()
        {
            // Toss the ball.
            _eventAggregator.GetEvent<TossBallEvent>().Publish();
        }

        /// <summary>
        /// The PlaceBetsEventHandler method is called to handle an OnPlaceBets event.
        /// </summary>
        /// <param name="placeBets"></param>
        private void PlaceBetsEventHandler(bool placeBets)
        {
            // Announce place bets status.
            _eventAggregator.GetEvent<PlaceBetsEvent>().Publish(placeBets);
        }

        /// <summary>
        /// The WheelSpinningEventHandler method is called to handle a WheelSpinningEvent event.
        /// </summary>
        /// <param name="wheelSpinning"></param>
        private void WheelSpinningEventHandler(bool wheelSpinning)
        {
            // Update the status of the wheel.
            RouletteDealer.IsWheelSpinning = wheelSpinning;
        }

        /// <summary>
        /// The BallTossedEventHandler method is called to handle a BallTossedEvent event.
        /// </summary>
        /// <param name="wheelSpinning"></param>
        private void BallTossedEventHandler(bool ballTossed)
        {
            // Update the status of the ball.
            RouletteDealer.IsBallTossed = ballTossed;
        }

        #endregion
    }
}
