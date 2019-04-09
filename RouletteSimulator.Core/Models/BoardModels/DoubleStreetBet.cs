using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteSimulator.Core.Enumerations;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The CornerBet class represents a single double-street bet.
    /// </summary>
    public class DoubleStreetBet : CornerBet
    {
        #region Fields

        protected int _fifthNumber;
        protected int _sixthNumber;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DoubleStreetBet() : base()
        {
            _betType = BetType.DoubleStreet;
        }

        #endregion

        #region Events

        public static event HighLightDoubleStreetBet OnHighLightDoubleStreetBet;
        public static event ClearHighLightDoubleStreetBet OnClearHighLightDoubleStreetBet;

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
        /// Gets or sets the fifth number to bet on.
        /// </summary>
        public int FifthNumber
        {
            get
            {
                return _fifthNumber;
            }
            set
            {
                SetProperty(ref _fifthNumber, value);
            }
        }

        /// <summary>
        /// Gets or sets the sixth number to bet on.
        /// </summary>
        public int SixthNumber
        {
            get
            {
                return _sixthNumber;
            }
            set
            {
                SetProperty(ref _sixthNumber, value);
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
            OnHighLightDoubleStreetBet?.Invoke(this);
        }

        /// <summary>
        /// The ClearHighLightBet method is called to un-highlight the bet.
        /// </summary>
        /// <param name="parameter"></param>
        protected override void ClearHighLightBet(object parameter)
        {
            OnClearHighLightDoubleStreetBet?.Invoke(this);
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
                if (winningNumber == _firstNumber || winningNumber == _secondNumber || 
                    winningNumber == _thirdNumber || winningNumber == _fourthNumber ||
                    winningNumber == _fifthNumber || winningNumber == _sixthNumber)
                {
                    return CalculateWinnings();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CornerBet.CalculateWinnings(int winningNumber): " + ex.ToString());
            }
        }

        #endregion
    }
}
