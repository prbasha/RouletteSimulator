using Prism.Events;
using RouletteSimulator.Core.EventAggregator;
using System.Windows.Controls;

namespace Wheel.Views
{
    /// <summary>
    /// The WheelView class represents the view for the Wheel module.
    /// </summary>
    public partial class WheelView : UserControl
    {
        #region Fields

        private IEventAggregator _eventAggregator;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public WheelView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            
            DataContext = this;                                             // Set data context (for data binding).
            RouletteWheel = new RouletteWheel(wheelControl, ballControl);   // Initialize the roulette wheel.

            // Listen to events.
            RouletteWheel.OnWheelSpinning += new WheelSpinning(WheelSpinningEventHandler);
            RouletteWheel.OnBallTossed += new BallTossed(BallTossedEventHandler);
            RouletteWheel.OnWinningNumber += new WinningNumber(WinningNumberEventHandler);

            // Event aggregator.
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SpinWheelEvent>().Subscribe(SpinWheelEventHandler, true);
            _eventAggregator.GetEvent<TossBallEvent>().Subscribe(TossBallEventHandler, true);
            _eventAggregator.GetEvent<BoardClearedEvent>().Subscribe(BoardClearedEventHandler, true);

            // Publish the initial status of the wheel/ball.
            _eventAggregator.GetEvent<WheelSpinningEvent>().Publish(false);
            _eventAggregator.GetEvent<BallTossedEvent>().Publish(false);
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the roulette board.
        /// </summary>
        public RouletteWheel RouletteWheel { get; }

        #endregion

        #region Methods

        /// <summary>
        /// The SpinWheelEventHandler handles an incoming SpinWheelEvent event.
        /// </summary>
        private void SpinWheelEventHandler()
        {
            RouletteWheel.SpinWheel();  // Spin the wheel.
        }

        /// <summary>
        /// The TossBallEventHandler handles an incoming TossBallEvent event.
        /// </summary>
        private void TossBallEventHandler()
        {
            RouletteWheel.TossBall();   // Toss the ball.
        }

        /// <summary>
        /// The BoardClearedEventHandler handles an incoming BoardClearedEvent event.
        /// </summary>
        private void BoardClearedEventHandler()
        {
            RouletteWheel.RetrieveBall();   // Retrieve the ball.
        }

        /// <summary>
        /// The WheelSpinningEventHandler method is called to handle an OnWheelSpinning event.
        /// </summary>
        /// <param name="wheelSpinning"></param>
        private void WheelSpinningEventHandler(bool wheelSpinning)
        {
            _eventAggregator.GetEvent<WheelSpinningEvent>().Publish(wheelSpinning); // Update the status of the wheel.
        }

        /// <summary>
        /// The BallTossedEventHandler method is called to handle an OnBallTossed event.
        /// </summary>
        /// <param name="ballTossed"></param>
        private void BallTossedEventHandler(bool ballTossed)
        {
            _eventAggregator.GetEvent<BallTossedEvent>().Publish(ballTossed);   // Update the status of the ball.
        }

        /// <summary>
        /// The WinningNumberEventHandler method is called to handle an OnWinningNumber event.
        /// </summary>
        /// <param name="winningNumber"></param>
        private void WinningNumberEventHandler(int winningNumber)
        {
            _eventAggregator.GetEvent<WinningNumberEvent>().Publish(winningNumber); // Publish the winning number.
        }

        #endregion
    }
}
