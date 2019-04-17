using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RouletteSimulator.Core.Models.WheelModels
{
    /// <summary>
    /// The RouletteWheel class represents a roulette wheel.
    /// </summary>
    public class RouletteWheel : BindableBase
    {
        #region Fields

        private Border _mainBorder;
        private double _borderWidthPixels;
        private double _borderHeightPixels;
        private double _wheelDiameterXPixels;
        private double _wheelDiameterYPixels;
        private double _wheelOffsetXPixels;
        private double _wheelOffsetYPixels;
        private double _wheelCenterPointXPixels;
        private double _wheelCenterPointYPixels;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RouletteWheel()
        {
            try
            {
                // Pockets.
                Pockets = new ObservableCollection<Pocket>();
                for (int i = 0 ; i < Constants.NumberOfPockets; i++)
                {
                    Pockets.Add(new Pocket() { AngularPositionDegrees = i * Constants.PocketStepDegrees });
                }

                // Commands.
                BorderSizeChangedCommand = new DelegateCommand<object>(BorderSizeChanged);
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteWheel(): " + ex.ToString());
            }
        }

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or sets the border width in pixels.
        /// </summary>
        public double BorderWidthPixels
        {
            get
            {
                return _borderWidthPixels;
            }
            set
            {
                SetProperty(ref _borderWidthPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the border height in pixels.
        /// </summary>
        public double BorderHeightPixels
        {
            get
            {
                return _borderHeightPixels;
            }
            set
            {
                SetProperty(ref _borderHeightPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the x-axis wheel diameter in pixels.
        /// </summary>
        public double WheelDiameterXPixels
        {
            get
            {
                return _wheelDiameterXPixels;
            }
            set
            {
                SetProperty(ref _wheelDiameterXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis wheel diameter in pixels.
        /// </summary>
        public double WheelDiameterYPixels
        {
            get
            {
                return _wheelDiameterYPixels;
            }
            set
            {
                SetProperty(ref _wheelDiameterYPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the x-axis wheel offset in pixels.
        /// </summary>
        public double WheelOffsetXPixels
        {
            get
            {
                return _wheelOffsetXPixels;
            }
            set
            {
                SetProperty(ref _wheelOffsetXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis wheel offset in pixels.
        /// </summary>
        public double WheelOffsetYPixels
        {
            get
            {
                return _wheelOffsetYPixels;
            }
            set
            {
                SetProperty(ref _wheelOffsetYPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the wheel center point x-coordinate in pixels.
        /// </summary>
        public double WheelCenterPointXPixels
        {
            get
            {
                return _wheelCenterPointXPixels;
            }
            set
            {
                SetProperty(ref _wheelCenterPointXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the wheel center point y-coordinate in pixels.
        /// </summary>
        public double WheelCenterPointYPixels
        {
            get
            {
                return _wheelCenterPointYPixels;
            }
            set
            {
                SetProperty(ref _wheelCenterPointYPixels, value);
            }
        }

        /// <summary>
        /// Gets the collection of pockets.
        /// </summary>
        public ObservableCollection<Pocket> Pockets { get; }

        /// <summary>
        /// Gets or sets the BorderSizeChangedCommand.
        /// </summary>
        public DelegateCommand<object> BorderSizeChangedCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The WheelSizeChanged method is called to update with width/height of the wheel.
        /// </summary>
        /// <param name="parameter"></param>
        public void BorderSizeChanged(object parameter)
        {
            try
            {
                // Capture the previous border width/height.
                double previousBorderWidthPixels = BorderWidthPixels;
                double previousBorderHeightPixels = BorderHeightPixels;

                // Retrieve the new border width/height.
                _mainBorder = (Border)parameter;
                BorderWidthPixels = _mainBorder.ActualWidth;
                BorderHeightPixels = _mainBorder.ActualHeight;

                // Determine the percentage of change.
                //double widthResize = (BorderWidthPixels - previousBorderWidthPixels) / previousBorderWidthPixels;
                //double heightResize = (BorderHeightPixels - previousBorderHeightPixels) / previousBorderHeightPixels;

                WheelDiameterXPixels = BorderWidthPixels > BorderHeightPixels ? Constants.WheelDiameterPercentage * BorderHeightPixels : Constants.WheelDiameterPercentage * BorderWidthPixels;
                WheelDiameterYPixels = WheelDiameterXPixels;
                WheelOffsetXPixels = (BorderWidthPixels / 2) - (WheelDiameterXPixels / 2);
                WheelOffsetYPixels = (BorderHeightPixels / 2) - (WheelDiameterYPixels / 2);

                // Wheel center point and circumference.
                WheelCenterPointXPixels = BorderWidthPixels / 2;
                WheelCenterPointYPixels = BorderHeightPixels / 2;
                double wheelCircumference = Math.PI * WheelDiameterXPixels;
                
                // Pocket width.
                double pocketWidthPixels = wheelCircumference / Constants.NumberOfPockets;

                // Apply the updated wheel center point and pocket width to the pockets.
                foreach (Pocket pocket in Pockets)
                {
                    pocket.WidthPixels = pocketWidthPixels;
                    pocket.XPositionPixels = WheelCenterPointXPixels - (pocket.WidthPixels/2);
                    pocket.YPositionPixels = WheelCenterPointYPixels - WheelDiameterYPixels/2;
                    pocket.WheelCenterPointXPixels = WheelCenterPointXPixels;
                    pocket.WheelCenterPointYPixels = WheelCenterPointYPixels;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteWheel.BorderSizeChanged(object parameter): " + ex.ToString());
            }
        }

        #endregion
    }
}
