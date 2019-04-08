using Prism.Commands;
using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The Bet class represents a single bet.
    /// It is an abstract class.
    /// </summary>
    public abstract class Bet : BindableBase
    {
        #region Fields

        protected BetType _betType;
        protected int _betAmount;
        protected bool _isHighLighted;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Bet()
        {
            _betAmount = 0;
            _isHighLighted = false;

            // Commands.
            HighLightBetCommand = new DelegateCommand<object>(HighLightBet);
            ClearHighLightBetCommand = new DelegateCommand<object>(ClearHighLightBet);
        }

        /// <summary>
        /// Constructor.
        /// Creates a Bet for the provided bet type.
        /// </summary>
        /// <param name="betType"></param>
        public Bet(BetType betType) : this()
        {
            _betType = betType;
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the bet type.
        /// </summary>
        public BetType BetType
        {
            get
            {
                return _betType;
            }
            set
            {
                SetProperty(ref _betType, value);
            }
        }

        /// <summary>
        /// Gets or sets the bet amount.
        /// </summary>
        public int BetAmount
        {
            get
            {
                return _betAmount;
            }
            protected set
            {
                if (value >= 0)
                {
                    SetProperty(ref _betAmount, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the highlighted flag.
        /// </summary>
        public bool IsHighLighted
        {
            get
            {
                return _isHighLighted;
            }
            private set
            {
                SetProperty(ref _isHighLighted, value);
            }
        }

        /// <summary>
        /// Gets the exposure.
        /// </summary>
        public abstract int Exposure
        {
            get;
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public abstract int Outcome
        {
            get;
        }

        /// <summary>
        /// Gets or sets the HighLightBetCommand.
        /// </summary>
        public ICommand HighLightBetCommand { get; private set; }

        /// <summary>
        /// Gets or sets the ClearHighLightBetCommand.
        /// </summary>
        public ICommand ClearHighLightBetCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The HighLightBet method is called to highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void HighLightBet(object parameter)
        {
            IsHighLighted = true;
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected virtual void ClearHighLightBet(object parameter)
        {
            IsHighLighted = false;
        }

        /// <summary>
        /// The PlaceBet method is called to place a bet for the provided amount.
        /// </summary>
        /// <param name="betAmount"></param>
        public void PlaceBet(int amount)
        {
            if (amount > 0)
            {
                BetAmount = BetAmount + amount;
                // TBD: update chips collection.
            }
        }

        /// <summary>
        /// The ClearBet method is called to clear the bet amount.
        /// </summary>
        public void ClearBet()
        {
            BetAmount = 0;
        }

        /// <summary>
        /// The CalculateWinnings method calculates the winnings for this bet.
        /// </summary>
        /// <returns></returns>
        protected int CalculateWinnings()
        {
            if (BetAmount > 0)
            {
                return (Exposure + Outcome) * BetAmount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// The CalculateWinnings method calculates the winnings for this bet, for a provided winning number.
        /// </summary>
        /// <param name="winningNumber"></param>
        /// <returns></returns>
        public abstract int CalculateWinnings(int winningNumber);

        #endregion
    }
}
