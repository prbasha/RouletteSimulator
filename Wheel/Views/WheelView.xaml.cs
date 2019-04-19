using Prism.Events;
using RouletteSimulator.Core.EventAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            // Spin the wheel.
            RouletteWheel.SpinWheel();
        }

        /// <summary>
        /// The TossBallEventHandler handles an incoming TossBallEvent event.
        /// </summary>
        private void TossBallEventHandler()
        {
            // Toss the ball.
            RouletteWheel.TossBall();
        }

        /// <summary>
        /// The BoardClearedEventHandler handles an incoming BoardClearedEvent event.
        /// </summary>
        private void BoardClearedEventHandler()
        {
            // Retrieve the ball.
            RouletteWheel.RetrieveBall();
        }

        /// <summary>
        /// The WheelSpinningEventHandler method is called to handle an OnWheelSpinning event.
        /// </summary>
        /// <param name="wheelSpinning"></param>
        private void WheelSpinningEventHandler(bool wheelSpinning)
        {
            // Update the status of the wheel.
            _eventAggregator.GetEvent<WheelSpinningEvent>().Publish(wheelSpinning);
        }

        /// <summary>
        /// The BallTossedEventHandler method is called to handle an OnBallTossed event.
        /// </summary>
        /// <param name="ballTossed"></param>
        private void BallTossedEventHandler(bool ballTossed)
        {
            // Update the status of the ball.
            _eventAggregator.GetEvent<BallTossedEvent>().Publish(ballTossed);
        }

        #endregion
    }
}
