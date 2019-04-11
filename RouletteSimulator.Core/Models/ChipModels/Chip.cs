using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RouletteSimulator.Core.Models.ChipModels
{
    /// <summary>
    /// The Chip class represents a generic casino chip.
    /// It is an abstract class.
    /// </summary>
    public abstract class Chip
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Chip()
        {
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the chip type.
        /// </summary>
        public abstract ChipType ChipType { get; }

        /// <summary>
        /// Gets the chip value (in dollars).
        /// </summary>
        public abstract int Value { get; }

        /// <summary>
        /// Gets the chip color.
        /// </summary>
        public abstract Color Color { get; }

        /// <summary>
        /// Gets a text label for the chip.
        /// </summary>
        public string Label
        {
            get
            {
                string label = "$";

                switch (ChipType)
                {
                    case ChipType.One:
                    case ChipType.Five:
                    case ChipType.TwentyFive:
                    case ChipType.OneHundred:
                    case ChipType.FiveHundred:
                        label = label + Value.ToString();
                        break;
                    case ChipType.OneThousand:
                    case ChipType.FiveThousand:
                    case ChipType.TwentyFiveThousand:
                    case ChipType.OneHundredThousand:
                    case ChipType.FiveHundredThousand:
                        label = label + Value.ToString().TrimEnd('0') + "K";
                        break;
                }

                return label;
            }
        }

        #endregion

        #region Methods
        #endregion
    }
}
