using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The DozenBet class represents a single dozen bet.
    /// </summary>
    public class DozenBet : Bet
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DozenBet()
        {
        }

        /// <summary>
        /// Constructor.
        /// Creates a DozenBet for the provided bet type.
        /// </summary>
        public DozenBet(BetType betType)
        {
            if (betType == BetType.FirstDozen || betType == BetType.SecondDozen || betType == BetType.ThirdDozen)
            {
                _betType = betType;
            }
            else
            {
                throw new Exception("DozenBet(BetType betType): betType must be FirstDozen, SecondDozen, or ThirdDozen.");
            }
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
                return Constants.DozenExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.DozenOutcome;
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
                int winnings = 0;

                switch (_betType)
                {
                    case BetType.FirstDozen:
                        winnings = Constants.FirstDozenWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                    case BetType.SecondDozen:
                        winnings = Constants.SecondDozenWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                    case BetType.ThirdDozen:
                        winnings = Constants.ThirdDozenWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                }

                return winnings;
            }
            catch (Exception ex)
            {
                throw new Exception("DozenBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
