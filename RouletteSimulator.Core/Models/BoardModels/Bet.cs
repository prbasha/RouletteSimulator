using Prism.Commands;
using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.Models.ChipModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
        
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Bet()
        {
            _betAmount = 0;
            SelectedChip = ChipType.Undefined;

            // Commands.
            HighLightBetCommand = new DelegateCommand<object>(HighLightBet);
            ClearHighLightBetCommand = new DelegateCommand<object>(ClearHighLightBet);
            PlaceBetCommand = new DelegateCommand<object>(PlaceBet);
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

        public static event PlaceBet OnPlaceBet;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current selected chip type.
        /// </summary>
        public static ChipType SelectedChip
        {
            get;
            set;
        }

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

        /// <summary>
        /// Gets or sets the PlaceBetCommand.
        /// </summary>
        public ICommand PlaceBetCommand { get; private set; }

        /// <summary>
        /// Gets the text label for the bet.
        /// </summary>
        public abstract string Label
        {
            get;
        }

        /// <summary>
        /// Gets the Border control for this chip.
        /// </summary>
        public Border Border
        {
            get;
            private set;
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// The HighLightBet method is called to highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract void HighLightBet(object parameter);

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract void ClearHighLightBet(object parameter);

        /// <summary>
        /// The PlaceBet method is called to place a bet for the current selected chip.
        /// </summary>
        /// <param name="parameter"></param>
        public void PlaceBet(object parameter)
        {
            try
            {
                if (parameter != null && SelectedChip != ChipType.Undefined)
                {
                    switch (SelectedChip)
                    {
                        case ChipType.One:
                            BetAmount = BetAmount + ChipModels.Constants.OneDollar;
                            break;
                        case ChipType.Five:
                            BetAmount = BetAmount + ChipModels.Constants.FiveDollar;
                            break;
                        case ChipType.TwentyFive:
                            BetAmount = BetAmount + ChipModels.Constants.TwentyFiveDollar;
                            break;
                        case ChipType.OneHundred:
                            BetAmount = BetAmount + ChipModels.Constants.OneHundredDollar;
                            break;
                        case ChipType.FiveHundred:
                            BetAmount = BetAmount + ChipModels.Constants.FiveHundredDollar;
                            break;
                        case ChipType.OneThousand:
                            BetAmount = BetAmount + ChipModels.Constants.OneHundredThousandDollar;
                            break;
                        case ChipType.FiveThousand:
                            BetAmount = BetAmount + ChipModels.Constants.FiveThousandDollar;
                            break;
                        case ChipType.TwentyFiveThousand:
                            BetAmount = BetAmount + ChipModels.Constants.TwentyFiveThousandDollar;
                            break;
                        case ChipType.OneHundredThousand:
                            BetAmount = BetAmount + ChipModels.Constants.OneHundredThousandDollar;
                            break;
                        case ChipType.FiveHundredThousand:
                            BetAmount = BetAmount + ChipModels.Constants.FiveHundredThousandDollar;
                            break;
                    }

                    Border = (Border)parameter; // Retrieve the Border control for this Bet object.
                    OnPlaceBet?.Invoke(this);   // Place the bet on the board.
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bet.PlaceBet(object parameter): " + ex.ToString());
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
