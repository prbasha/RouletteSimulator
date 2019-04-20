using Prism.Mvvm;
using System.Linq;
using System.Windows.Media;

namespace Wheel.Views
{
    /// <summary>
    /// The Pocket class represents a single pocket on a roulette wheel.
    /// </summary>
    public class Pocket : BindableBase
    {
        #region Fields

        private int _number;
        private double _widthPixels;
        public double _xPositionPixels;
        public double _yPositionPixels;
        private double _centerPointXPixels;
        private double _centerPointYPixels;

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

        /// <summary>
        /// Gets or sets the first number to bet on.
        /// </summary>
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                SetProperty(ref _number, value);
            }
        }

        /// <summary>
        /// Returns a boolan flag indicating if this is a green number.
        /// </summary>
        public bool IsGreenNumber
        {
            get
            {
                return Number == Constants.Zero;
            }
        }

        /// <summary>
        /// Returns a boolan flag indicating if this is a red number.
        /// </summary>
        public bool IsRedNumber
        {
            get
            {
                return Constants.RedWinningNumbers.Contains(Number);
            }
        }

        /// <summary>
        /// Returns a boolan flag indicating if this is a black number.
        /// </summary>
        public bool IsBlackNumber
        {
            get
            {
                return Constants.BlackWinningNumbers.Contains(Number);
            }
        }

        /// <summary>
        /// Gets the text label for the pocket.
        /// </summary>
        public string Label
        {
            get
            {
                return Number.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the x-position in pixels.
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
        /// Gets or sets the y-position in pixels.
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
        /// Gets or sets the pocket width in pixels.
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
            }
        }

        /// <summary>
        /// Gets or sets the center point x-coordinate in pixels.
        /// </summary>
        public double CenterPointXPixels
        {
            get
            {
                return _centerPointXPixels;
            }
            private set
            {
                SetProperty(ref _centerPointXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the wheel center point y-coordinate in pixels.
        /// </summary>
        public double CenterPointYPixels
        {
            get
            {
                return _centerPointYPixels;
            }
            private set
            {
                SetProperty(ref _centerPointYPixels, value);
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

        /// <summary>
        /// The UpdatePocketShape method is called to update the shape that represents the pocket.
        /// This is triggered by a window resize.
        /// </summary>
        /// <param name="widthPixels"></param>
        /// <param name="heightPixels"></param>
        /// <param name="xPositionPixels"></param>
        /// <param name="yPositionPixels"></param>
        /// <param name="wheelCenterPointXPixels"></param>
        /// <param name="wheelCenterPointYPixels"></param>
        public void UpdatePocketShape(double widthPixels, double heightPixels, double xPositionPixels, double yPositionPixels, double wheelCenterPointXPixels, double wheelCenterPointYPixels)
        {
            // Update polygon.
            Points = new PointCollection();
            Points.Add(new System.Windows.Point(xPositionPixels, yPositionPixels));
            Points.Add(new System.Windows.Point(xPositionPixels + widthPixels, yPositionPixels));
            Points.Add(new System.Windows.Point(xPositionPixels + (Constants.PocketWidth1Percentage * widthPixels), yPositionPixels + heightPixels));
            Points.Add(new System.Windows.Point(xPositionPixels + (Constants.PocketWidth2Percentage * widthPixels), yPositionPixels + heightPixels));
            RaisePropertyChanged("Points");

            // Update the x/y position and width of the pocket.
            XPositionPixels = xPositionPixels;
            YPositionPixels = yPositionPixels;
            WidthPixels = widthPixels;

            // Update wheel center point.
            CenterPointXPixels = wheelCenterPointXPixels;
            CenterPointYPixels = wheelCenterPointYPixels;
        }

        #endregion
    }
}
