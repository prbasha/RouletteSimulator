using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace RouletteSimulator.Core.Models.PersonModels
{
    /// <summary>
    /// The RouletteDealer class represents a roulette dealer.
    /// </summary>
    public class RouletteDealer : BindableBase
    {
        #region Fields

        private bool _isWheelSpinning;
        private bool _isBallTossed;
        private DispatcherTimer _spinTimer;
        private DispatcherTimer _ballTimer;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RouletteDealer()
        {
            // Wheel/board states.
            _isWheelSpinning = false;
            _isBallTossed = false;

            // Timers.
            _spinTimer = new DispatcherTimer();
            _spinTimer.Tick += SpinTimerTick;
            _spinTimer.Interval += new TimeSpan(0, 0, Constants.SpinTimeoutSeconds);
            _ballTimer = new DispatcherTimer();
            _ballTimer.Tick += BallTimerTick;
            _ballTimer.Interval += new TimeSpan(0, 0, Constants.BallTimeoutSeconds);

            // Commands.
            SpinWheelCommand = new DelegateCommand(SpinWheel, CanSpinWheel);
        }

        #endregion

        #region Events

        public static event SpinWheel OnSpinWheel;
        public static event TossBall OnTossBall;
        public static event NoMoreBets OnNoMoreBets;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a boolean flag indicating if the wheel is currently spinning.
        /// </summary>
        public bool IsWheelSpinning
        {
            get
            {
                return _isWheelSpinning;
            }
            set
            {
                SetProperty(ref _isWheelSpinning, value);
                SpinWheelCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets a boolean flag indicating if the ball is currently in the wheel.
        /// </summary>
        public bool IsBallTossed
        {
            get
            {
                return _isBallTossed;
            }
            set
            {
                SetProperty(ref _isBallTossed, value);
                SpinWheelCommand.RaiseCanExecuteChanged();
            }
        }
        
        /// <summary>
        /// Gets or sets the SpinWheelCommand.
        /// </summary>
        public DelegateCommand SpinWheelCommand { get; private set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// The SpinWheel method is called to spin the roulette wheel.
        /// </summary>
        private void SpinWheel()
        {
            if (!IsWheelSpinning && !IsBallTossed)
            {
                OnSpinWheel?.Invoke();  // Spin the weel.
                _spinTimer.Start();     // Start the spin timer.
            }
        }

        /// <summary>
        /// The CanSpinWheel method is called to determine if the wheel can be spun.
        /// </summary>
        /// <returns></returns>
        private bool CanSpinWheel()
        {
            return !IsWheelSpinning && !IsBallTossed;
        }

        /// <summary>
        /// The TossBall method is called to toss the ball into the roulette wheel.
        /// </summary>
        private void TossBall()
        {
            if (IsWheelSpinning && !IsBallTossed)
            {
                OnTossBall?.Invoke();   // Toss the ball.
                _ballTimer.Start();     // Start the ball timer.
            }
        }
        
        /// <summary>
        /// The SpinTimerTick method is called when the spin timer times out.
        /// It is called a set period of time after the wheel starts spinning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpinTimerTick(object sender, EventArgs e)
        {
            _spinTimer.Stop();  // Stop the spin timer.
            TossBall();         // Toss the ball on to the wheel.
        }

        /// <summary>
        /// The BallTimerTick method is called when the ball timer times out.
        /// It is called a set period of time after the ball hits the wheel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BallTimerTick(object sender, EventArgs e)
        {
            _ballTimer.Stop();      // Stop the ball timer.
            OnNoMoreBets?.Invoke(); // Announce no more bets.
        }

        #endregion
    }
}
