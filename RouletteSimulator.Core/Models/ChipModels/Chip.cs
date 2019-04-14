using Prism.Mvvm;
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
    /// The Chip class represents a generic casino chip.
    /// It is an abstract class.
    /// </summary>
    public abstract class Chip : BindableBase
    {
        #region Fields

        private double _xPositionPixels;
        private double _yPositionPixels;
        private double _widthPixels;
        private double _heightPixels;

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
        /// Gets or sets the x position in pixels.
        /// </summary>
        public double XPositionPixels
        {
            get
            {
                return _xPositionPixels;
            }
            set
            {
                SetProperty(ref _xPositionPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y position in pixels.
        /// </summary>
        public double YPositionPixels
        {
            get
            {
                return _yPositionPixels;
            }
            set
            {
                SetProperty(ref _yPositionPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the width in pixels.
        /// </summary>
        public double WidthPixels
        {
            get
            {
                return _widthPixels;
            }
            set
            {
                SetProperty(ref _widthPixels, value);
                RaisePropertyChanged("OffsetXPixels");
            }
        }

        /// <summary>
        /// Gets or sets the height in pixels.
        /// </summary>
        public double HeightPixels
        {
            get
            {
                return _heightPixels;
            }
            set
            {
                SetProperty(ref _heightPixels, value);
                RaisePropertyChanged("OffsetYPixels");
            }
        }

        /// <summary>
        /// Gets the x offset in pixels.
        /// </summary>
        public double OffsetXPixels
        {
            get
            {
                return -1 * WidthPixels / 2;
            }
        }

        /// <summary>
        /// Gets the y offset in pixels.
        /// </summary>
        public double OffsetYPixels
        {
            get
            {
                return -1 * HeightPixels / 2;
            }
        }

        /// <summary>
        /// Gets the chip width/height as a percentage of the board width.
        /// </summary>
        public static double WidthHeightPercent
        {
            get
            {
                return Constants.WidthHeightPercent;
            }
        }

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
