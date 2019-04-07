using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteSimulator.Core.Enumerations;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The StreetBet class represents a single street bet.
    /// </summary>
    public class StreetBet : SplitBet
    {
        #region Fields

        protected int _thirdNumber;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StreetBet() : base()
        {
            _betType = BetType.Street;
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
                return Constants.StreetExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.StreetOutcome;
            }
        }

        /// <summary>
        /// Gets or sets the third number to bet on.
        /// </summary>
        public int ThirdNumber
        {
            get
            {
                return _thirdNumber;
            }
            set
            {
                SetProperty(ref _thirdNumber, value);
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
                return (winningNumber == _firstNumber || winningNumber == _secondNumber || winningNumber == _thirdNumber) ? CalculateWinnings() : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("StreetBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
