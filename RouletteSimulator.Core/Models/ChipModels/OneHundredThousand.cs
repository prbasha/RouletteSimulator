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
    /// The OneHundredThousand class represents a one hundred thousand dollar casino chip.
    /// </summary>
    public class OneHundredThousand : Chip
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
        public OneHundredThousand(int position = 0) : base(position)
        {
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the chip type.
        /// </summary>
        public override ChipType ChipType { get { return ChipType.OneHundredThousand; } }

        /// <summary>
        /// Gets the chip value (in dollars).
        /// </summary>
        public override int Value { get { return Constants.OneHundredThousandDollar; } }

        /// <summary>
        /// Gets the chip color.
        /// </summary>
        public override Brush Color { get { return Brushes.OrangeRed; } }

        #endregion

        #region Methods
        #endregion
    }
}
