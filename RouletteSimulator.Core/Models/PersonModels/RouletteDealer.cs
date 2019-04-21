using Prism.Commands;
using Prism.Mvvm;
using RouletteSimulator.Core.Models.WheelModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace RouletteSimulator.Core.Models.PersonModels
{
    /// <summary>
    /// The RouletteDealer class represents a roulette dealer.
    /// </summary>
    public class RouletteDealer : BindableBase
    {
        #region Fields

        private bool _placeBets;
        private bool _isWheelSpinning;
        private bool _isBallTossed;
        private DispatcherTimer _spinTimer;
        private DispatcherTimer _ballTimer;
        private Pocket _winningNumber = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RouletteDealer()
        {
            // Game states.
            _placeBets = true;
            _isWheelSpinning = false;
            _isBallTossed = false;
            WinningNumberHistory = new ObservableCollection<Pocket>();

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
        public static event PlaceBets OnPlaceBets;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a boolean flag indicating if bets can be placed.
        /// </summary>
        public bool PlaceBets
        {
            get
            {
                return _placeBets;
            }
            set
            {
                SetProperty(ref _placeBets, value);
                OnPlaceBets?.Invoke(_placeBets);    // Publish place bets status.
            }
        }

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

                if (!_isBallTossed)
                {
                    PlaceBets = true;       // Ball is not in the wheel - place bets.

                    if (WinningNumber != null)
                    {
                        // Add the latest winning number to the winning number history.
                        if (WinningNumberHistory.Count == Constants.MaximumWinningNumbers)
                        {
                            WinningNumberHistory.RemoveAt(Constants.FirstWinningNumberIndex);
                        }
                        WinningNumberHistory.Add(WinningNumber);

                        WinningNumber = null;   // Clear the winning number.
                    }
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the winning number.
        /// </summary>
        public Pocket WinningNumber
        {
            get
            {
                return _winningNumber;
            }
            set
            {
                SetProperty(ref _winningNumber, value);
            }
        }

        public ObservableCollection<Pocket> WinningNumberHistory { get; }

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
                OnSpinWheel?.Invoke();  // Spin the wheel.
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
            _ballTimer.Stop();  // Stop the ball timer.
            PlaceBets = false;  // Ball has been in the wheel for X seconds - No more bets.
        }

        /// <summary>
        /// The AnnounceWinningNumber method is called to announce the latest winning number.
        /// </summary>
        /// <param name="winningNumber"></param>
        public void AnnounceWinningNumber(Pocket winningNumber)
        {
            WinningNumber = winningNumber;
        }

        #endregion
    }
}
