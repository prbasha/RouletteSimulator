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
    /// The One class represents a one dollar casino chip.
    /// </summary>
    public class One : Chip
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
        public One(int position = 0) : base(position)
        {
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the chip type.
        /// </summary>
        public override ChipType ChipType { get { return ChipType.One; } }

        /// <summary>
        /// Gets the chip value (in dollars).
        /// </summary>
        public override int Value { get { return Constants.OneDollar; } }

        /// <summary>
        /// Gets the chip color.
        /// </summary>
        public override Brush Color { get { return Brushes.Brown; } }

        #endregion

        #region Methods
        #endregion
    }
}
