using RouletteSimulator.Core.Enumerations;
using System.Windows.Media;

namespace RouletteSimulator.Core.Models.ChipModels
{
    /// <summary>
    /// The TwentyFive class represents a twenty five dollar casino chip.
    /// </summary>
    public class TwentyFive : Chip
    {
        #region Fields 
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// Creates a new Chip.
        /// An optional position parameter is used to determine a y-axis offset, when stacking chips.
        /// </summary>
        /// <param name="position"></param>
        public TwentyFive(int position = 0) : base(position)
        {
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the chip type.
        /// </summary>
        public override ChipType ChipType { get { return ChipType.TwentyFive; } }

        /// <summary>
        /// Gets the chip value (in dollars).
        /// </summary>
        public override int Value { get { return Constants.TwentyFiveDollar; } }

        /// <summary>
        /// Gets the chip color.
        /// </summary>
        public override Brush Color { get { return Brushes.Coral; } }

        #endregion

        #region Methods
        #endregion
    }
}
