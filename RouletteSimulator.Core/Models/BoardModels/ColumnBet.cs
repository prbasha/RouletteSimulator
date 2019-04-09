using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The ColumnBet class represents a single column bet.
    /// </summary>
    public class ColumnBet : Bet
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ColumnBet() : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// Creates a ColumnBet for the provided bet type.
        /// </summary>
        public ColumnBet(BetType betType)
        {
            if (betType == BetType.FirstColumn || betType == BetType.SecondColumn || betType == BetType.ThirdColumn)
            {
                _betType = betType;
            }
            else
            {
                throw new Exception("ColumnBet(BetType betType): betType must be FirstColumn, SecondColumn, or ThirdColumn.");
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
                return Constants.ColumnExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.ColumnOutcome;
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
            // TBD: raise a "HighLightSplitBet" event passing this object as the event parameter.
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void ClearHighLightBet(object parameter)
        {
            // TBD: raise a "ClearHighLightSplitBet" event passing this object as the event parameter.
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
                int winnings = 0;

                switch (_betType)
                {
                    case BetType.FirstColumn:
                        winnings = Constants.FirstColumnWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                    case BetType.SecondColumn:
                        winnings = Constants.SecondColumnWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                    case BetType.ThirdColumn:
                        winnings = Constants.ThirdColumnWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                }

                return winnings;
            }
            catch (Exception ex)
            {
                throw new Exception("ColumnBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
