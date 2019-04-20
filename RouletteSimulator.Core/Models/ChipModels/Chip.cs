using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using System.Windows.Media;

namespace RouletteSimulator.Core.Models.ChipModels
{
    /// <summary>
    /// The Chip class represents a generic casino chip.
    /// It is an abstract class.
    /// </summary>
    public abstract class Chip : BindableBase
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
        public Chip(int position = 0)
        {
            OffsetYPixels = HeightPixels * Constants.StackScale * position;
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
        public abstract Brush Color { get; }

        /// <summary>
        /// Gets a text label for the chip.
        /// </summary>
        public string Label
        {
            get
            {
                string label = string.Empty;

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
                        label = label + (Value/1000).ToString() + "K";
                        break;
                }

                return label;
            }
        }
        
        /// <summary>
        /// Gets or sets the width in pixels.
        /// </summary>
        public double WidthPixels
        {
            get
            {
                return Constants.WidthHeight;
            }
        }

        /// <summary>
        /// Gets or sets the height in pixels.
        /// </summary>
        public double HeightPixels
        {
            get
            {
                return Constants.WidthHeight;
            }
        }

        /// <summary>
        /// Gets the y offset in pixels.
        /// This is used when stacking chips.
        /// </summary>
        public double OffsetYPixels { get; private set; }
        
        #endregion

        #region Methods

        /// <summary>
        /// The GetChipValue method is called to return the dollar value for a provided chip type.
        /// </summary>
        /// <param name="chipType"></param>
        /// <returns></returns>
        public static int GetChipValue(ChipType chipType)
        {
            int value = 0;

            switch (chipType)
            {
                case ChipType.One:
                    value = Constants.OneDollar;
                    break;
                case ChipType.Five:
                    value = Constants.FiveDollar;
                    break;
                case ChipType.TwentyFive:
                    value = Constants.TwentyFiveDollar;
                    break;
                case ChipType.OneHundred:
                    value = Constants.OneHundredDollar;
                    break;
                case ChipType.FiveHundred:
                    value = Constants.FiveHundredDollar;
                    break;
                case ChipType.OneThousand:
                    value = Constants.OneThousandDollar;
                    break;
                case ChipType.FiveThousand:
                    value = Constants.FiveThousandDollar;
                    break;
                case ChipType.TwentyFiveThousand:
                    value = Constants.TwentyFiveThousandDollar;
                    break;
                case ChipType.OneHundredThousand:
                    value = Constants.OneHundredThousandDollar;
                    break;
                case ChipType.FiveHundredThousand:
                    value = Constants.FiveHundredThousandDollar;
                    break;
            }

            return value;
        }

        #endregion
    }
}
