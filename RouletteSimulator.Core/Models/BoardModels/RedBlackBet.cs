using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The RedBlackBet class represents a single red or black bet.
    /// </summary>
    public class RedBlackBet : Bet
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RedBlackBet()
        {
        }

        /// <summary>
        /// Constructor.
        /// Creates a RedBlackBet for the provided bet type.
        /// </summary>
        public RedBlackBet(BetType betType)
        {
            if (betType == BetType.Red || betType == BetType.Black)
            {
                _betType = betType;
            }
            else
            {
                throw new Exception("RedBlackBet(BetType betType): betType must be Red or Black.");
            }
        }

        #endregion

        #region Redts
        #endregion

        #region Properties

        /// <summary>
        /// Gets the exposure.
        /// </summary>
        public override int Exposure
        {
            get
            {
                return Constants.RedBlackExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.RedBlackOutcome;
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
                    case BetType.Red:
                        winnings = Constants.RedWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                    case BetType.Black:
                        winnings = Constants.BlackWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                }

                return winnings;
            }
            catch (Exception ex)
            {
                throw new Exception("RedBlackBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
