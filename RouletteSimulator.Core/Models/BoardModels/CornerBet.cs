using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteSimulator.Core.Enumerations;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The CornerBet class represents a single corner bet.
    /// </summary>
    public class CornerBet : StreetBet
    {
        #region Fields

        protected int _fourthNumber;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CornerBet() : base()
        {
            _betType = BetType.Corner;
        }

        #endregion

        #region Events

        public static event HighLightCornerBet OnHighLightCornerBet;
        public static event ClearHighLightCornerBet OnClearHighLightCornerBet;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the exposure.
        /// </summary>
        public override int Exposure
        {
            get
            {
                return Constants.CornerExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.CornerOutcome;
            }
        }

        /// <summary>
        /// Gets or sets the fourth number to bet on.
        /// </summary>
        public int FourthNumber
        {
            get
            {
                return _fourthNumber;
            }
            set
            {
                SetProperty(ref _fourthNumber, value);
            }
        }

        /// <summary>
        /// Gets the text label for the bet.
        /// </summary>
        public override string Label
        {
            get
            {
                return string.Empty;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The HighLightBet method is called to highlight the bet.
        /// </summary>
        protected override void HighLightBet()
        {
            OnHighLightCornerBet?.Invoke(this);
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        protected override void ClearHighLightBet()
        {
            OnClearHighLightCornerBet?.Invoke(this);
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
                return (winningNumber == _firstNumber || winningNumber == _secondNumber || winningNumber == _thirdNumber || winningNumber == _fourthNumber) ? CalculateWinnings() : CalculateLosses();
            }
            catch (Exception ex)
            {
                throw new Exception("CornerBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
