using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Wheel.Views
{
    /// <summary>
    /// The RouletteWheel class represents a roulette wheel.
    /// </summary>
    public class RouletteWheel : BindableBase
    {
        #region Fields

        private int _winningNumber;
        private double _winningNumberEndAngleDegrees;
        private Random _randomNumberGenerator;
        private double _mainBorderWidthPixels;
        private double _mainBorderHeightPixels;

        private ItemsControl _wheelControl;
        private Storyboard _wheelStoryBoard;
        private RotateTransform _wheelRotateTransform;
        private DoubleAnimation _wheelSpinningAnimation1;
        private DateTime _wheelSpinningAnimation1EndTime;
        private DoubleAnimation _wheelSpinningAnimation2;

        private Ellipse _ballControl;
        private Storyboard _ballStoryBoard;
        private TranslateTransform _ballTranslateTransform;
        private RotateTransform _ballRotateTransform;
        private DoubleAnimation _ballSpinningAnimation1;
        private DoubleAnimation _ballFallingAnimation;
        private DoubleAnimation _ballSpinningAnimation2;

        private double _centerPointXPixels;
        private double _centerPointYPixels;
        private double _outerWheelDiameterXPixels;
        private double _outerWheelDiameterYPixels;
        private double _outerWheelOffsetXPixels;
        private double _outerWheelOffsetYPixels;
        private double _centerWheelDiameterXPixels;
        private double _centerWheelDiameterYPixels;
        private double _centerWheelOffsetXPixels;
        private double _centerWheelOffsetYPixels;
        private double _innerWheelDiameterXPixels;
        private double _innerWheelDiameterYPixels;
        private double _innerWheelOffsetXPixels;
        private double _innerWheelOffsetYPixels;
        private double _ballDiameterXPixels;
        private double _ballDiameterYPixels;
        private double _ballCenterPositionXPixels;
        private double _ballCenterPositionYPixels;
        private double _ballYOffsetPixels;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wheelControl"></param>
        /// <param name="ballControl"></param>
        public RouletteWheel(ItemsControl wheelControl, Ellipse ballControl)
        {
            try
            {
                // Wheel control.
                _wheelControl = wheelControl;
                _wheelControl.RenderTransformOrigin = new Point(Constants.MidPoint, Constants.MidPoint);
                // Add a RotateTransform to the wheel control.
                _wheelRotateTransform = new RotateTransform();
                _wheelControl.RegisterName(Constants.WheelRotateTransformName, _wheelRotateTransform);
                _wheelControl.RenderTransform = _wheelRotateTransform;
                
                // Ball control.
                _ballControl = ballControl;
                _ballControl.RenderTransformOrigin = new Point(Constants.MidPoint, Constants.MidPoint);
                // Create a TransformGroup.
                TransformGroup ballTransformGroup = new TransformGroup();
                // Add a TranslateTransform to the TransformGroup.
                _ballTranslateTransform = new TranslateTransform();
                _ballControl.RegisterName(Constants.BallTranslateTransformName, _ballTranslateTransform);
                ballTransformGroup.Children.Add(_ballTranslateTransform);
                // Add a RotateTransform to the TransformGroup.
                _ballRotateTransform = new RotateTransform();
                _ballControl.RegisterName(Constants.BallRotateTransformName, _ballRotateTransform);
                ballTransformGroup.Children.Add(_ballRotateTransform);
                // Add the TransformGroup to the ball control.
                _ballControl.RenderTransform = ballTransformGroup;
                
                // Wheel pockets.
                Pockets = new ObservableCollection<Pocket>();
                for (int i = 0; i < Constants.WheelNumbers.Count(); i++)
                {
                    Pockets.Add(new Pocket() { Number = Constants.WheelNumbers[i], AngularPositionDegrees = i * Constants.PocketStepDegrees });
                }

                // Random number generator.
                _randomNumberGenerator = new Random();

                // Commands.
                BorderSizeChangedCommand = new DelegateCommand<object>(BorderSizeChanged);
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteWheel(Canvas wheelCanvas, Canvas ballControl): " + ex.ToString());
            }
        }

        #endregion

        #region Events

        public static event WheelSpinning OnWheelSpinning;
        public static event BallTossed OnBallTossed;
        public static event WinningNumber OnWinningNumber;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or sets the main border width in pixels.
        /// </summary>
        public double MainBorderWidthPixels
        {
            get
            {
                return _mainBorderWidthPixels;
            }
            private set
            {
                SetProperty(ref _mainBorderWidthPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the main border height in pixels.
        /// </summary>
        public double MainBorderHeightPixels
        {
            get
            {
                return _mainBorderHeightPixels;
            }
            private set
            {
                SetProperty(ref _mainBorderHeightPixels, value);
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
        /// Gets or sets the center point y-coordinate in pixels.
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
        /// Gets or sets the x-axis outer wheel diameter in pixels.
        /// </summary>
        public double OuterWheelDiameterXPixels
        {
            get
            {
                return _outerWheelDiameterXPixels;
            }
            private set
            {
                SetProperty(ref _outerWheelDiameterXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis outer wheel diameter in pixels.
        /// </summary>
        public double OuterWheelDiameterYPixels
        {
            get
            {
                return _outerWheelDiameterYPixels;
            }
            private set
            {
                SetProperty(ref _outerWheelDiameterYPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the x-axis outer wheel offset in pixels.
        /// </summary>
        public double OuterWheelOffsetXPixels
        {
            get
            {
                return _outerWheelOffsetXPixels;
            }
            private set
            {
                SetProperty(ref _outerWheelOffsetXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis outer wheel offset in pixels.
        /// </summary>
        public double OuterWheelOffsetYPixels
        {
            get
            {
                return _outerWheelOffsetYPixels;
            }
            private set
            {
                SetProperty(ref _outerWheelOffsetYPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the x-axis center wheel diameter in pixels.
        /// </summary>
        public double CenterWheelDiameterXPixels
        {
            get
            {
                return _centerWheelDiameterXPixels;
            }
            private set
            {
                SetProperty(ref _centerWheelDiameterXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis center wheel diameter in pixels.
        /// </summary>
        public double CenterWheelDiameterYPixels
        {
            get
            {
                return _centerWheelDiameterYPixels;
            }
            private set
            {
                SetProperty(ref _centerWheelDiameterYPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the x-axis center wheel offset in pixels.
        /// </summary>
        public double CenterWheelOffsetXPixels
        {
            get
            {
                return _centerWheelOffsetXPixels;
            }
            private set
            {
                SetProperty(ref _centerWheelOffsetXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis center wheel offset in pixels.
        /// </summary>
        public double CenterWheelOffsetYPixels
        {
            get
            {
                return _centerWheelOffsetYPixels;
            }
            private set
            {
                SetProperty(ref _centerWheelOffsetYPixels, value);
            }
        }
        
        /// <summary>
        /// Gets or sets the x-axis ball diameter in pixels.
        /// </summary>
        public double BallDiameterXPixels
        {
            get
            {
                return _ballDiameterXPixels;
            }
            private set
            {
                SetProperty(ref _ballDiameterXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis ball diameter in pixels.
        /// </summary>
        public double BallDiameterYPixels
        {
            get
            {
                return _ballDiameterYPixels;
            }
            private set
            {
                SetProperty(ref _ballDiameterYPixels, value);
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
        /// The SpinWheel method is called to spin the wheel.
        /// </summary>
        public void SpinWheel()
        {
            try
            {
                if (_wheelStoryBoard == null)
                {
                    // Initialize the story board.
                    _wheelStoryBoard = new Storyboard();
                    _wheelStoryBoard.Completed += new EventHandler(WheelStopped);
                }
                else if (_wheelStoryBoard.GetCurrentState(_wheelControl) == ClockState.Stopped || _wheelStoryBoard.GetIsPaused(_wheelControl))
                {
                    return; // Wheel is already spinning or is paused - do not spin.
                }
                
                // Wheel spinning animation 1.
                if (_wheelSpinningAnimation1 == null)
                {
                    // Initialize the animation.
                    _wheelSpinningAnimation1 = new DoubleAnimation();
                    _wheelSpinningAnimation1.SpeedRatio = Constants.WheelSpeedRatio;
                    //_wheelSpinningAnimation1.DecelerationRatio = Constants.WheelDecelerationRatio;
                    _wheelSpinningAnimation1.FillBehavior = FillBehavior.HoldEnd;
                    Storyboard.SetTargetName(_wheelSpinningAnimation1, Constants.WheelRotateTransformName);
                    Storyboard.SetTargetProperty(_wheelSpinningAnimation1, new PropertyPath(RotateTransform.AngleProperty));
                    _wheelStoryBoard.Children.Add(_wheelSpinningAnimation1);  // Add the animation to the story board.
                }
                // Number of rotations in total degrees - multiply by wheel speed ratio (negative degrees for counter clockwise).
                double wheelEndAngleDegrees = -1 * _randomNumberGenerator.Next(Constants.MinimumWheelSpinDistanceDegrees, Constants.MaximumWheelSpinDistanceDegrees);
                _wheelSpinningAnimation1.By = wheelEndAngleDegrees * Constants.WheelSpeedRatio;
                // Duration of spin seconds - multiply by wheel speed ratio.
                double spinDurationSeconds = _randomNumberGenerator.Next(Constants.MinimumWheelSpinDurationSeconds, Constants.MaximumWheelSpinDurationSeconds);
                _wheelSpinningAnimation1.Duration = TimeSpan.FromSeconds(spinDurationSeconds * Constants.WheelSpeedRatio);
                _wheelSpinningAnimation1EndTime = DateTime.Now.AddSeconds(spinDurationSeconds);

                // Wheel spinning animation 2.
                if (_wheelSpinningAnimation2 == null)
                {
                    // Initialize the animation.
                    _wheelSpinningAnimation2 = new DoubleAnimation();
                    _wheelSpinningAnimation2.SpeedRatio = Constants.WheelSpeedRatio;
                    _wheelSpinningAnimation2.DecelerationRatio = Constants.StoppingDecelerationRatio;
                    _wheelSpinningAnimation2.FillBehavior = FillBehavior.HoldEnd;
                    _wheelSpinningAnimation2.By = -1 * Constants.FullCircleDegrees;
                    _wheelSpinningAnimation2.Duration = TimeSpan.FromSeconds(Constants.StoppingDurationSeconds * Constants.WheelSpeedRatio);
                    Storyboard.SetTargetName(_wheelSpinningAnimation2, Constants.WheelRotateTransformName);
                    Storyboard.SetTargetProperty(_wheelSpinningAnimation2, new PropertyPath(RotateTransform.AngleProperty));
                    _wheelStoryBoard.Children.Add(_wheelSpinningAnimation2);  // Add the animation to the story board.
                }
                // Begin time - begins after the first wheel spinning animation.
                _wheelSpinningAnimation2.BeginTime = TimeSpan.FromSeconds(spinDurationSeconds);

                // Select a winning number, and retrieve the corresponding winning pocket.
                _winningNumber = _randomNumberGenerator.Next(Constants.MinimumWinningNumber, Constants.MaximumWinningNumber);
                Pocket winningPocket = Pockets.SingleOrDefault(x => x.Number == _winningNumber);
                double winningNumberStartAngleDegrees = winningPocket.AngularPositionDegrees + ((RotateTransform)_wheelControl.RenderTransform).Angle;
                _winningNumberEndAngleDegrees = CorrectAngleDegrees(winningNumberStartAngleDegrees + (double)_wheelSpinningAnimation1.By);
                
                _wheelStoryBoard.Begin(_wheelControl, true);    // Start the story board.
                OnWheelSpinning?.Invoke(true);                  // Publish the status of the wheel.
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteWheel.SpinWheel(): " + ex.ToString());
            }
        }

        /// <summary>
        /// The WheelStopped method is called when the wheel stops spinning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WheelStopped(object sender, EventArgs e)
        {
            OnWheelSpinning?.Invoke(false);  // Publish the status of the wheel - the wheel is no longer spinning.
        }

        /// <summary>
        /// The TossBall method is called to toss the ball.
        /// </summary>
        public void TossBall()
        {
            try
            {
                if (_ballStoryBoard == null)
                {
                    // Initialize the story board.
                    _ballStoryBoard = new Storyboard();
                    _ballStoryBoard.Completed += new EventHandler(BallStopped);
                }
                else if (_ballStoryBoard.GetCurrentState(_ballControl) == ClockState.Stopped || _ballStoryBoard.GetIsPaused(_ballControl))
                {
                    return; // Ball is already moving or is paused - do not spin.
                }

                // Ball spinning animation 1.
                if (_ballSpinningAnimation1 == null)
                {
                    // Initialize the ball spinning animation.
                    _ballSpinningAnimation1 = new DoubleAnimation();
                    _ballSpinningAnimation1.SpeedRatio = Constants.BallSpeedRatio;
                    Storyboard.SetTargetName(_ballSpinningAnimation1, Constants.BallRotateTransformName);
                    Storyboard.SetTargetProperty(_ballSpinningAnimation1, new PropertyPath(RotateTransform.AngleProperty));
                    _ballStoryBoard.Children.Add(_ballSpinningAnimation1);  // Add the animation to the story board.
                }
                // Number of rotations in total degrees - multiply by ball speed ratio (positive degrees for clockwise).
                _ballSpinningAnimation1.From = 0;
                _ballSpinningAnimation1.To = _winningNumberEndAngleDegrees + (Constants.FullCircleDegrees * Constants.BallSpeedRatio);
                // Duration of spin seconds - multiply by ball speed ratio.
                TimeSpan ballSpinningDuration = _wheelSpinningAnimation1EndTime.Subtract(DateTime.Now);
                _ballSpinningAnimation1.Duration = TimeSpan.FromSeconds(ballSpinningDuration.TotalSeconds * Constants.BallSpeedRatio);

                // Ball falling animation.
                if (_ballFallingAnimation == null)
                {
                    // Initialize the ball falling animation.
                    _ballFallingAnimation = new DoubleAnimation();
                    _ballFallingAnimation.SpeedRatio = Constants.BallSpeedRatio;
                    Storyboard.SetTargetName(_ballFallingAnimation, Constants.BallTranslateTransformName);
                    Storyboard.SetTargetProperty(_ballFallingAnimation, new PropertyPath(TranslateTransform.YProperty));
                    _ballStoryBoard.Children.Add(_ballFallingAnimation);  // Add the animation to the story board.
                }
                // Distance for the ball to fall in pixels.
                _ballFallingAnimation.From = _ballCenterPositionYPixels - _ballYOffsetPixels;   // Start at the top-edge of the wheel.
                _ballFallingAnimation.To = _ballCenterPositionYPixels - (_ballYOffsetPixels * Constants.BallFallPercent);
                // Duration of fall in seconds - same as rotation duration.
                _ballFallingAnimation.Duration = _ballSpinningAnimation1.Duration;

                // Ball spinning animation 2.
                if (_ballSpinningAnimation2 == null)
                {
                    // Initialize the ball spinning animation.
                    _ballSpinningAnimation2 = _wheelSpinningAnimation2.Clone();
                    Storyboard.SetTargetName(_ballSpinningAnimation2, Constants.BallRotateTransformName);
                    Storyboard.SetTargetProperty(_ballSpinningAnimation2, new PropertyPath(RotateTransform.AngleProperty));
                    _ballStoryBoard.Children.Add(_ballSpinningAnimation2);  // Add the animation to the story board.
                }
                // Begin time - begins after the first ball spinning animation.
                _ballSpinningAnimation2.BeginTime = TimeSpan.FromSeconds(ballSpinningDuration.TotalSeconds);

                _ballControl.Visibility = Visibility.Visible;
                _ballStoryBoard.Begin(_ballControl, true);  // Start the story board.
                OnBallTossed?.Invoke(true);                 // Publish the status of the ball.
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteBall.TossBall(): " + ex.ToString());
            }
        }

        /// <summary>
        /// The BallStopped method is called when the ball stops moving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BallStopped(object sender, EventArgs e)
        {
            OnWinningNumber?.Invoke(_winningNumber);    // Publish the winning number.
        }

        /// <summary>
        /// The RetrieveBall method is called to remove the ball from the wheel.
        /// </summary>
        public void RetrieveBall()
        {
            _ballControl.Visibility = Visibility.Hidden;
            OnBallTossed?.Invoke(false);    // Publish the status of the ball - the ball is no longer in the wheel.
        }

        /// <summary>
        /// The BorderSizeChanged method is called to update with width/height of the wheel/ball controls.
        /// </summary>
        /// <param name="parameter"></param>
        public void BorderSizeChanged(object parameter)
        {
            try
            {
                // Retrieve the new border width/height.
                Border mainBorder = (Border)parameter;
                MainBorderWidthPixels = mainBorder.ActualWidth;
                MainBorderHeightPixels = mainBorder.ActualHeight;
                
                // Main center point for all 3 wheels and the ball.
                CenterPointXPixels = mainBorder.ActualWidth / 2;
                CenterPointYPixels = mainBorder.ActualHeight / 2;

                // Outer wheel diameter and offset.
                OuterWheelDiameterXPixels = mainBorder.ActualWidth > mainBorder.ActualHeight ? Constants.OuterWheelDiameterPercentage * mainBorder.ActualHeight : Constants.OuterWheelDiameterPercentage * mainBorder.ActualWidth;
                OuterWheelDiameterYPixels = OuterWheelDiameterXPixels;
                OuterWheelOffsetXPixels = (mainBorder.ActualWidth / 2) - (OuterWheelDiameterXPixels / 2);
                OuterWheelOffsetYPixels = (mainBorder.ActualHeight / 2) - (OuterWheelDiameterYPixels / 2);

                // Center wheel diameter and offset.
                CenterWheelDiameterXPixels = mainBorder.ActualWidth > mainBorder.ActualHeight ? Constants.CenterWheelDiameterPercentage * mainBorder.ActualHeight : Constants.CenterWheelDiameterPercentage * mainBorder.ActualWidth;
                CenterWheelDiameterYPixels = CenterWheelDiameterXPixels;
                CenterWheelOffsetXPixels = (mainBorder.ActualWidth / 2) - (CenterWheelDiameterXPixels / 2);
                CenterWheelOffsetYPixels = (mainBorder.ActualHeight / 2) - (CenterWheelDiameterYPixels / 2);

                // Inner wheel diameter and offset.
                _innerWheelDiameterXPixels = mainBorder.ActualWidth > mainBorder.ActualHeight ? Constants.InnerWheelDiameterPercentage * mainBorder.ActualHeight : Constants.InnerWheelDiameterPercentage * mainBorder.ActualWidth;
                _innerWheelDiameterYPixels = _innerWheelDiameterXPixels;
                _innerWheelOffsetXPixels = (mainBorder.ActualWidth / 2) - (_innerWheelDiameterXPixels / 2);
                _innerWheelOffsetYPixels = (mainBorder.ActualHeight / 2) - (_innerWheelDiameterYPixels / 2);
                double innerWheelCircumference = Math.PI * _innerWheelDiameterXPixels;
                
                // Pocket width and position.
                double pocketWidthPixels = innerWheelCircumference / Constants.NumberOfPockets;
                double pocketHeightPixels = _innerWheelDiameterXPixels * Constants.PocketHeightPercentage;
                double pocketXPositionPixels = CenterPointXPixels - (pocketWidthPixels / 2);
                double pocketYPositionPixels = (CenterPointYPixels - (_innerWheelDiameterXPixels / 2));
                
                // Update the width and position for every pocket.
                foreach (Pocket pocket in Pockets)
                {
                    pocket.UpdatePocketShape(pocketWidthPixels, pocketHeightPixels, pocketXPositionPixels, pocketYPositionPixels, CenterPointXPixels, CenterPointYPixels);
                }
                
                // Ball diameter.
                BallDiameterXPixels = mainBorder.ActualWidth > mainBorder.ActualHeight ? Constants.BallDiameterPercentage * mainBorder.ActualHeight : Constants.BallDiameterPercentage * mainBorder.ActualWidth;
                BallDiameterYPixels = BallDiameterXPixels;
                // Ball xy coordinates at the very center of the canvas (taking into account the height/width offset of the ball).
                _ballCenterPositionXPixels = CenterPointXPixels - (BallDiameterXPixels / 2);
                _ballCenterPositionYPixels = CenterPointYPixels - (BallDiameterYPixels / 2);
                // Ball y-offset (offsets the ball near the top-edge of the wheel).
                _ballYOffsetPixels = mainBorder.ActualWidth > mainBorder.ActualHeight ? (Constants.BallYOffsetPercentage * mainBorder.ActualHeight) / 2 : (Constants.BallYOffsetPercentage * mainBorder.ActualWidth) / 2;
                // Ball xy translation (places the ball near the top-edge of the wheel).
                _ballTranslateTransform.X = _ballCenterPositionXPixels;
                _ballTranslateTransform.Y = _ballCenterPositionYPixels - _ballYOffsetPixels;
                // Ball rotation (rotates the ball around the very center of the canvas, taking into account the height/width of the ball).
                _ballRotateTransform.CenterX = _ballCenterPositionXPixels;
                _ballRotateTransform.CenterY = _ballCenterPositionYPixels;
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteWheel.BorderSizeChanged(object parameter): " + ex.ToString());
            }
        }

        /// <summary>
        /// The CorrectAngleDegrees method is called to correct and angle that lies outside the 0 to +360 degree range.
        /// </summary>
        /// <param name="angleDegrees"></param>
        /// <returns></returns>
        public static double CorrectAngleDegrees(double angleDegrees)
        {
            double correctedAngleDegrees = angleDegrees % Constants.FullCircleDegrees;

            if (correctedAngleDegrees < 0)
            {
                correctedAngleDegrees += Constants.FullCircleDegrees;
            }

            return correctedAngleDegrees;
        }

        #endregion
    }
}
