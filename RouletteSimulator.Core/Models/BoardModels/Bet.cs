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
        protected ObservableCollection<Chip> _chips;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Bet()
        {
            _betAmount = 0;
            _chips = new ObservableCollection<Chip>();

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
        /// Gets the collection of casino chips.
        /// </summary>
        public ObservableCollection<Chip> Chips
        {
            get
            {
                return _chips;
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
        /// Gets or sets the current selected chip type.
        /// </summary>
        public static ChipType SelectedChip
        {
            get;
            set;
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
                Chip chip = null;

                switch (SelectedChip)
                {
                    case ChipType.One:
                        chip = new One();
                        break;
                    case ChipType.Five:
                        chip = new Five();
                        break;
                    case ChipType.TwentyFive:
                        chip = new TwentyFive();
                        break;
                    case ChipType.OneHundred:
                        chip = new OneHundred();
                        break;
                    case ChipType.FiveHundred:
                        chip = new FiveHundred();
                        break;
                    case ChipType.OneThousand:
                        chip = new OneThousand();
                        break;
                    case ChipType.FiveThousand:
                        chip = new FiveThousand();
                        break;
                    case ChipType.TwentyFiveThousand:
                        chip = new TwentyFiveThousand();
                        break;
                    case ChipType.OneHundredThousand:
                        chip = new OneHundredThousand();
                        break;
                    case ChipType.FiveHundredThousand:
                        chip = new FiveHundredThousand();
                        break;
                }

                if (chip != null)
                {
                    BetAmount = BetAmount + chip.Value;
                    _chips.Add(chip);
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
            _chips.Clear();
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
