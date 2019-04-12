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
    /// The FiveHundredThousand class represents a one hundred thousand dollar casino chip.
    /// </summary>
    public class FiveHundredThousand : Chip
    {
        #region Fields 
        #endregion

        #region Constructors
        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the chip type.
        /// </summary>
        public override ChipType ChipType { get { return ChipType.FiveHundredThousand; } }

        /// <summary>
        /// Gets the chip value (in dollars).
        /// </summary>
        public override int Value { get { return Constants.FiveHundredThousandDollar; } }

        /// <summary>
        /// Gets the chip color.
        /// </summary>
        public override Brush Color { get { return Brushes.PeachPuff; } }

        #endregion

        #region Methods
        #endregion
    }
}
