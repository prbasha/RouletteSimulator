using Prism.Commands;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.Models.ChipModels;

namespace RouletteSimulator.Core.Models.PersonModels
{
    /// <summary>
    /// The RoulettePlayer class represents the person playing the roulette game.
    /// </summary>
    public class RoulettePlayer : Person
    {
        #region Fields
        
        private int _totalCash;
        private ChipType _selectedChip;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RoulettePlayer() : base()
        {
            // Cash/bets.
            _totalCash = Constants.InitialCashDollars;
            
            // Chips.
            _selectedChip = ChipType.Undefined;
            OneChip = new One();
            FiveChip = new Five();
            TwentyFiveChip = new TwentyFive();
            OneHundredChip = new OneHundred();
            FiveHundredChip = new FiveHundred();
            OneThousandChip = new OneThousand();
            FiveThousandChip = new FiveThousand();
            TwentyFiveThousandChip = new TwentyFiveThousand();
            OneHundredThousandChip = new OneHundredThousand();
            FiveHundredThousandChip = new FiveHundredThousand();

            // Commands.
            ClearBetsCommand = new DelegateCommand(ClearBets).ObservesCanExecute(() => PlaceBets);
        }

        #endregion

        #region Events

        public static event ChipSelected OnChipSelected;
        public static event ClearBets OnClearBets;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the place bets status.
        /// </summary>
        public override bool PlaceBets
        {
            get
            {
                return base.PlaceBets;
            }
            set
            {
                base.PlaceBets = value;

                EmotionalState = EmotionalState.Mutual; // Reset emotional state.
            }
        }

        /// <summary>
        /// Gets the total cash held by the player.
        /// </summary>
        public int TotalCash
        {
            get
            {
                return _totalCash;
            }
            private set
            {
                SetProperty(ref _totalCash, value);
                
                // Update the selected chip.
                if (TotalCash <= 0 || TotalCash < Chip.GetChipValue(SelectedChip))
                {
                    SelectedChip = ChipType.Undefined;
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the chip currently selected by the player.
        /// </summary>
        public ChipType SelectedChip
        {
            get
            {
                return _selectedChip;
            }
            set
            {
                if (value == ChipType.Undefined)
                {
                    // Clear the selected chip.
                    SetProperty(ref _selectedChip, value);
                    OnChipSelected?.Invoke(_selectedChip);
                }
                else if (TotalCash <= 0)
                {
                    // Player has no money - clear the selected chip.
                    SetProperty(ref _selectedChip, ChipType.Undefined);
                    OnChipSelected?.Invoke(_selectedChip);
                }
                else if (TotalCash < Chip.GetChipValue(value))
                {
                    // Player is lacking sufficient funds for the selected chip - do nothing.
                }
                else
                {
                    // Update the selected chip.
                    SetProperty(ref _selectedChip, value);
                    OnChipSelected?.Invoke(_selectedChip);
                }
            }
        }
        
        /// <summary>
        /// Gets the one dollar chip.
        /// </summary>
        public One OneChip { get; }

        /// <summary>
        /// Gets the five dollar chip.
        /// </summary>
        public Five FiveChip { get; }

        /// <summary>
        /// Gets the twenty five dollar chip.
        /// </summary>
        public TwentyFive TwentyFiveChip { get; }

        /// <summary>
        /// Gets the one hundred dollar chip.
        /// </summary>
        public OneHundred OneHundredChip { get; }

        /// <summary>
        /// Gets the five hundred dollar chip.
        /// </summary>
        public FiveHundred FiveHundredChip { get; }

        /// <summary>
        /// Gets the one thousand dollar chip.
        /// </summary>
        public OneThousand OneThousandChip { get; }

        /// <summary>
        /// Gets the five thousand dollar chip.
        /// </summary>
        public FiveThousand FiveThousandChip { get; }

        /// <summary>
        /// Gets the twenty five thousand dollar chip.
        /// </summary>
        public TwentyFiveThousand TwentyFiveThousandChip { get; }

        /// <summary>
        /// Gets the one hundred thousand dollar chip.
        /// </summary>
        public OneHundredThousand OneHundredThousandChip { get; }

        /// <summary>
        /// Gets the five hundred thousand dollar chip.
        /// </summary>
        public FiveHundredThousand FiveHundredThousandChip { get; }

        /// <summary>
        /// Gets or sets the ClearBetsCommand.
        /// </summary>
        public DelegateCommand ClearBetsCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The DeductBet method is called to deduct a bet amount.
        /// </summary>
        /// <param name="betAmount"></param>
        public override void DeductBet(int betAmount)
        {
            if (TotalCash >= betAmount)
            {
                TotalCash = TotalCash - betAmount;      // Deduct the bet from the total cash.
                CurrentBet = CurrentBet + betAmount;
            }
        }

        /// <summary>
        /// The ClearBets method is called to clear all bets.
        /// </summary>
        public override void ClearBets()
        {
            if (CurrentBet > 0)
            {
                TotalCash = TotalCash + CurrentBet; // Restore player's cash.
                CurrentBet = 0;
                OnClearBets?.Invoke();
            }
        }

        /// <summary>
        /// The ReceiveWinnings is called to add the winnings to the player's total.
        /// </summary>
        /// <param name="winnings"></param>
        public override void ReceiveWinnings(int winnings)
        {
            base.ReceiveWinnings(winnings);

            // Add the winnings to the player's total cash.
            if (winnings > 0)
            {
                TotalCash = TotalCash + winnings;
            }
        }

        /// <summary>
        /// The UpdateEmotionalState method is called to update the person's emotional state.
        /// </summary>
        protected override void UpdateEmotionalState()
        {
            if (CurrentWinnings == 0)
            {
                EmotionalState = EmotionalState.Mutual;
            }
            else if (CurrentWinnings > 0)
            {
                EmotionalState = EmotionalState.Happy;  // Player won - player is happy.
            }
            else if (CurrentWinnings < 0)
            {
                EmotionalState = EmotionalState.Sad;    // Player lost - player is sad.
            }
        }

        #endregion
    }
}
