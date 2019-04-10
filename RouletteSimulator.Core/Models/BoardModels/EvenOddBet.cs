using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The EvenOddBet class represents a single even or odd bet.
    /// </summary>
    public class EvenOddBet : Bet
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EvenOddBet() : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// Creates a EvenOddBet for the provided bet type.
        /// </summary>
        public EvenOddBet(BetType betType) : this()
        {
            if (betType == BetType.Even || betType == BetType.Odd)
            {
                _betType = betType;
            }
            else
            {
                throw new Exception("EvenOddBet(BetType betType): betType must be Even or Odd.");
            }
        }

        #endregion

        #region Events

        public static event HighLightEvenOddBet OnHighLightEvenOddBet;
        public static event ClearHighLightEvenOddBet OnClearHighLightEvenOddBet;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the exposure.
        /// </summary>
        public override int Exposure
        {
            get
            {
                return Constants.EvenOddExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.EvenOddOutcome;
            }
        }

        /// <summary>
        /// Gets the text label for the bet.
        /// </summary>
        public override string Label
        {
            get
            {
                string label = string.Empty;

                switch (_betType)
                {
                    case BetType.Even:
                        label = Constants.EvenLabel;
                        break;
                    case BetType.Odd:
                        label = Constants.OddLabel;
                        break;
                }

                return label;
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
            OnHighLightEvenOddBet?.Invoke(this);
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void ClearHighLightBet(object parameter)
        {
            OnClearHighLightEvenOddBet?.Invoke(this);
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
                    case BetType.Even:
                        winnings = Constants.EvenWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                    case BetType.Odd:
                        winnings = Constants.OddWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                }

                return winnings;
            }
            catch (Exception ex)
            {
                throw new Exception("EvenOddBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
