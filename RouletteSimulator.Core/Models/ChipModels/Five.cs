using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.ChipModels
{
    /// <summary>
    /// The Five class represents a five dollar casino chip.
    /// </summary>
    public class Five : Chip
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
        public override ChipType ChipType { get { return ChipType.Five; } }

        /// <summary>
        /// Gets the chip value (in dollars).
        /// </summary>
        public override int Value { get { return Constants.FiveDollar; } }

        /// <summary>
        /// Gets the chip color.
        /// </summary>
        public override Color Color { get { return Color.Aqua; } }

        #endregion

        #region Methods
        #endregion
    }
}
