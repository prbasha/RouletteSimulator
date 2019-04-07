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

        #endregion

        #region Methods

        /// <summary>
        /// The CalculateWinnings method calculates the winnings for this bet, for a provided winning number.
        /// </summary>
        /// <param name="winningNumber"></param>
        /// <returns></returns>
        public override int CalculateWinnings(int winningNumber)
        {
            try
            {
                return (winningNumber == _firstNumber || winningNumber == _secondNumber || winningNumber == _thirdNumber || winningNumber == _fourthNumber) ? CalculateWinnings() : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("CornerBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
