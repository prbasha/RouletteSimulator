using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The LowHighBet class represents a single low or high bet.
    /// </summary>
    public class LowHighBet : Bet
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LowHighBet() : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// Creates a LowHighBet for the provided bet type.
        /// </summary>
        public LowHighBet(BetType betType) : this()
        {
            if (betType == BetType.Low || betType == BetType.High)
            {
                _betType = betType;
            }
            else
            {
                throw new Exception("LowHighBet(BetType betType): betType must be Low or High.");
            }
        }

        #endregion

        #region Events

        public static event HighLightLowHighBet OnHighLightLowHighBet;
        public static event ClearHighLightLowHighBet OnClearHighLightLowHighBet;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the exposure.
        /// </summary>
        public override int Exposure
        {
            get
            {
                return Constants.LowHighExposure;
            }
        }

        /// <summary>
        /// Gets the outcome.
        /// </summary>
        public override int Outcome
        {
            get
            {
                return Constants.LowHighOutcome;
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
                    case BetType.Low:
                        label = Constants.LowLabel;
                        break;
                    case BetType.High:
                        label = Constants.HighLabel;
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
            OnHighLightLowHighBet?.Invoke(this);
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void ClearHighLightBet(object parameter)
        {
            OnClearHighLightLowHighBet?.Invoke(this);
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
                    case BetType.Low:
                        winnings = Constants.LowWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                    case BetType.High:
                        winnings = Constants.HighWinningNumbers.Contains(winningNumber) ? CalculateWinnings() : 0;
                        break;
                }

                return winnings;
            }
            catch (Exception ex)
            {
                throw new Exception("LowHighBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
