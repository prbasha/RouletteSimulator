using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RouletteSimulator.Core.Models.WheelModels
{
    /// <summary>
    /// The Pocket class represents a single pocket on a roulette wheel.
    /// </summary>
    public class Pocket : BindableBase
    {
        #region Fields

        private double _widthPixels;
        public double _xPositionPixels;
        public double _yPositionPixels;
        private double _wheelCenterPointXPixels;
        private double _wheelCenterPointYPixels;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public Pocket()
        {
            Points = new PointCollection();
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        ///// <summary>
        ///// Gets or sets the x-position in pixels.
        ///// </summary>
        //public double XPositionPixels
        //{
        //    get
        //    {
        //        return _xPositionPixels;
        //    }
        //    set
        //    {
        //        SetProperty(ref _xPositionPixels, value);
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the y-position in pixels.
        ///// </summary>
        //public double YPositionPixels
        //{
        //    get
        //    {
        //        return _yPositionPixels;
        //    }
        //    set
        //    {
        //        SetProperty(ref _yPositionPixels, value);
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the pocket width in pixels.
        ///// </summary>
        //public double WidthPixels
        //{
        //    get
        //    {
        //        return _widthPixels;
        //    }
        //    set
        //    {
        //        SetProperty(ref _widthPixels, value);
        //    }
        //}

        /// <summary>
        /// Gets or sets the wheel center point x-coordinate in pixels.
        /// </summary>
        public double WheelCenterPointXPixels
        {
            get
            {
                return _wheelCenterPointXPixels;
            }
            private set
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
            private set
            {
                SetProperty(ref _wheelCenterPointYPixels, value);
            }
        }

        /// <summary>
        /// Gets the collection of polygon points.
        /// </summary>
        public PointCollection Points { get; private set; }

        /// <summary>
        /// Gets or sets the pocket angular position in pixels.
        /// </summary>
        public double AngularPositionDegrees { get; set; }

        #endregion

        #region Methods

        public void UpdatePocketShape(double widthPixels, double xPositionPixels, double yPositionPixels, double wheelCenterPointXPixels, double wheelCenterPointYPixels)
        {
            // Update polygon.
            Points = new PointCollection();
            Points.Add(new System.Windows.Point(xPositionPixels, yPositionPixels));
            Points.Add(new System.Windows.Point(xPositionPixels + widthPixels, yPositionPixels));
            Points.Add(new System.Windows.Point(xPositionPixels + (0.75 * widthPixels), yPositionPixels + widthPixels));
            Points.Add(new System.Windows.Point(xPositionPixels + (0.25 * widthPixels), yPositionPixels + widthPixels));
            RaisePropertyChanged("Points");

            // Update wheel center point.
            WheelCenterPointXPixels = wheelCenterPointXPixels;
            WheelCenterPointYPixels = wheelCenterPointYPixels;
        }

        #endregion
    }
}
