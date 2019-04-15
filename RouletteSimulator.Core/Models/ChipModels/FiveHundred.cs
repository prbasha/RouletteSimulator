using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RouletteSimulator.Core.Models.ChipModels
{
    /// <summary>
    /// The FiveHundred class represents a five hundred dollar casino chip.
    /// </summary>
    public class FiveHundred : Chip
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
        public FiveHundred(int position = 0) : base(position)
        {
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the chip type.
        /// </summary>
        public override ChipType ChipType { get { return ChipType.FiveHundred; } }

        /// <summary>
        /// Gets the chip value (in dollars).
        /// </summary>
        public override int Value { get { return Constants.FiveHundredDollar; } }

        /// <summary>
        /// Gets the chip color.
        /// </summary>
        public override Brush Color { get { return Brushes.DarkTurquoise; } }

        #endregion

        #region Methods
        #endregion
    }
}
