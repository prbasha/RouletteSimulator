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
        public DozenBet() : base()
        {
        }

        /// <summary>
        /// Constructor.
        /// Creates a DozenBet for the provided bet type.
        /// </summary>
        public DozenBet(BetType betType) : this()
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

        public static event HighLightDozenBet OnHighLightDozenBet;
        public static event ClearHighLightDozenBet OnClearHighLightDozenBet;

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
                    case BetType.FirstDozen:
                        label = Constants.FirstDozenLabel;
                        break;
                    case BetType.SecondDozen:
                        label = Constants.SecondDozenLabel;
                        break;
                    case BetType.ThirdDozen:
                        label = Constants.ThirdDozenLabel;
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
            OnHighLightDozenBet?.Invoke(this);
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void ClearHighLightBet(object parameter)
        {
            OnClearHighLightDozenBet?.Invoke(this);
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
