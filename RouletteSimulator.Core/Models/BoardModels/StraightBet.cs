using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using RouletteSimulator.Core.Enumerations;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The StraightBet class represents a single straight bet.
    /// </summary>
    public class StraightBet : Bet
    {
        #region Fields
        
        protected int _firstNumber;
        private bool _isHighLighted;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StraightBet() : base()
        {
            _betType = BetType.Straight;
            _isHighLighted = false;
        }
        
        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the exposure.
        /// </summary>
        public override int Exposure
        {
            get
            {
                return Constants.StraightExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.StraightOutcome;
            }
        }

        /// <summary>
        /// Gets or sets the first number to bet on.
        /// </summary>
        public int FirstNumber
        {
            get
            {
                return _firstNumber;
            }
            set
            {
                SetProperty(ref _firstNumber, value);
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
            set
            {
                SetProperty(ref _isHighLighted, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The HighLightBet method is called to highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void HighLightBet(object parameter)
        {
            IsHighLighted = true;
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void ClearHighLightBet(object parameter)
        {
            IsHighLighted = false;
        }

        /// <summary>
        /// The CalculateWinnings method calculates the winnings for this bet, for a provided winning number.
        /// </summary>
        /// <param name="winningNumber"></param>
        /// <returns></returns>
        public override int CalculateWinnings(int winningNumber)
        {
            try
            {
                return (winningNumber == _firstNumber) ? CalculateWinnings() : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("StraightBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }
        
        #endregion
    }
}
