using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;

namespace RouletteSimulator.Core.Models.PersonModels
{
    /// <summary>
    /// The Person class represents a person. 
    /// It is an abstract class.
    /// </summary>
    public abstract class Person : BindableBase
    {
        #region Fields

        protected bool _placeBets;
        protected int _currentBet;
        protected int _currentwinnings;
        protected EmotionalState _emotionalState;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Person()
        {
            _placeBets = true;
            _currentBet = 0;
            _currentwinnings = 0;
            _emotionalState = EmotionalState.Mutual;
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the place bets status.
        /// </summary>
        public virtual bool PlaceBets
        {
            get
            {
                return _placeBets;
            }
            set
            {
                SetProperty(ref _placeBets, value);
                CurrentWinnings = 0;    // Clear the current winnings.
            }
        }

        /// <summary>
        /// Gets the current bet placed by the player.
        /// </summary>
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            protected set
            {
                SetProperty(ref _currentBet, value);
            }
        }

        /// <summary>
        /// Gets the winnings from the current bet.
        /// </summary>
        public int CurrentWinnings
        {
            get
            {
                return _currentwinnings;
            }
            private set
            {
                SetProperty(ref _currentwinnings, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the emotional state of the dealer.
        /// </summary>
        public EmotionalState EmotionalState
        {
            get
            {
                return _emotionalState;
            }
            protected set
            {
                SetProperty(ref _emotionalState, value);
            }
        }
        
        #endregion

        #region Methods
        
        /// <summary>
        /// The DeductBet method is called to deduct a bet amount.
        /// </summary>
        /// <param name="betAmount"></param>
        public abstract void DeductBet(int betAmount);

        /// <summary>
        /// The ClearBets method is called to clear all bets.
        /// </summary>
        public abstract void ClearBets();

        /// <summary>
        /// The ReceiveWinnings is called to add the winnings to the player's total.
        /// </summary>
        /// <param name="winnings"></param>
        public virtual void ReceiveWinnings(int winnings)
        {
            CurrentWinnings = winnings <= 0 ? winnings : winnings - CurrentBet;    // Determine actual winnings from the current bet.
            CurrentBet = 0;         // Clear the current bet.
            UpdateEmotionalState(); // Update emotional state, based on the winnings.
        }

        /// <summary>
        /// The UpdateEmotionalState method is called to update the person's emotional state.
        /// </summary>
        protected abstract void UpdateEmotionalState();
        
        #endregion
    }
}
