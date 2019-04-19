using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

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
        private Canvas _wheelControl;
        private Canvas _ballControl;
        private Storyboard _wheelStoryBoard;
        private DoubleAnimation _wheelAnimation;
        private Storyboard _ballStoryBoard;
        private DoubleAnimation _ballSpinningAnimation;
        private DoubleAnimation _ballFallingAnimation;
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
        private double _ballDiameterXPixels;
        private double _ballDiameterYPixels;
        private double _ballOffsetXPixels;
        private double _ballOffsetYPixels;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="wheelControl"></param>
        /// <param name="ballControl"></param>
        public RouletteWheel(Canvas wheelControl, Canvas ballControl)
        {
            try
            {
                // Wheel control.
                _wheelControl = wheelControl;
                _wheelControl.RenderTransformOrigin = new Point(Constants.MidPoint, Constants.MidPoint);
                // Add a RotateTransform to the wheel control.
                RotateTransform wheelRotateTransform = new RotateTransform(Constants.StartAngle);
                _wheelControl.RegisterName(Constants.WheelRotateTransformName, wheelRotateTransform);
                _wheelControl.RenderTransform = wheelRotateTransform;
                
                // Ball control.
                _ballControl = ballControl;
                _ballControl.RenderTransformOrigin = new Point(Constants.MidPoint, Constants.MidPoint);
                // Create a TransformGroup.
                TransformGroup ballTransformGroup = new TransformGroup();
                // Add a RotateTransform to the TransformGroup.
                RotateTransform ballRotateTransform = new RotateTransform(Constants.StartAngle);
                _ballControl.RegisterName(Constants.BallRotateTransformName, ballRotateTransform);
                ballTransformGroup.Children.Add(ballRotateTransform);
                // Add a TranslateTransform to the TransformGroup.
                TranslateTransform ballTranslateTransform = new TranslateTransform(Constants.StartPosition, Constants.StartPosition);
                _ballControl.RegisterName(Constants.BallTranslateTransformName, ballTranslateTransform);
                ballTransformGroup.Children.Add(ballTranslateTransform);
                // Add the TransformGroup to the ball control.
                _ballControl.RenderTransform = ballTransformGroup;
                
                // Wheel pockets.
                Pockets = new ObservableCollection<Pocket>();
                for (int i = 0; i < Constants.NumberOfPockets; i++)
                {
                    Pockets.Add(new Pocket() { Number = i, AngularPositionDegrees = i * Constants.PocketStepDegrees });
                }
                
                // Random number generator.
                _randomNumberGenerator = new Random();

                // Commands.
                BorderSizeChangedCommand = new DelegateCommand<object>(BorderSizeChanged);
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteWheel(Canvas wheelControl, Canvas ballControl): " + ex.ToString());
            }
        }

        #endregion

        #region Events

        public static event WheelSpinning OnWheelSpinning;
        public static event BallTossed OnBallTossed;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the wheel control.
        /// </summary>
        public string WheelControlName { get; private set; }

        /// <summary>
        /// Gets the name of the ball control.
        /// </summary>
        public string BallControlName { get; private set; }
        
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
        /// Gets or sets the x-axis ball offset in pixels.
        /// </summary>
        public double BallOffsetXPixels
        {
            get
            {
                return _ballOffsetXPixels;
            }
            private set
            {
                SetProperty(ref _ballOffsetXPixels, value);
            }
        }

        /// <summary>
        /// Gets or sets the y-axis ball offset in pixels.
        /// </summary>
        public double BallOffsetYPixels
        {
            get
            {
                return _ballOffsetYPixels;
            }
            private set
            {
                SetProperty(ref _ballOffsetYPixels, value);
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
                
                if (_wheelAnimation == null)
                {
                    // Initialize the animation.
                    _wheelAnimation = new DoubleAnimation();
                    _wheelAnimation.SpeedRatio = Constants.WheelSpeedRatio;
                    _wheelAnimation.DecelerationRatio = Constants.WheelDecelerationRatio;
                    _wheelAnimation.FillBehavior = FillBehavior.HoldEnd;
                    Storyboard.SetTargetName(_wheelAnimation, Constants.WheelRotateTransformName);
                    Storyboard.SetTargetProperty(_wheelAnimation, new PropertyPath(RotateTransform.AngleProperty));
                    _wheelStoryBoard.Children.Add(_wheelAnimation);  // Add the animation to the story board.
                }

                // Number of rotations in total degrees - multiply by wheel speed ratio (negative degrees for counter clockwise).
                _wheelAnimation.By = -1 * _randomNumberGenerator.Next(Constants.MinimumWheelSpinDistanceDegrees * Constants.WheelSpeedRatio, Constants.MaximumWheelSpinDistanceDegrees * Constants.WheelSpeedRatio);

                // Duration of spin seconds - multiply by wheel speed ratio.
                _wheelAnimation.Duration = TimeSpan.FromSeconds(_randomNumberGenerator.Next(Constants.MinimumWheelSpinDurationSeconds * Constants.WheelSpeedRatio, Constants.MaximumWheelSpinDurationSeconds * Constants.WheelSpeedRatio));

                // Select a winning number, and retrieve the corresponding winning pocket.
                _winningNumber = _randomNumberGenerator.Next(Constants.MinimumWinningNumber, Constants.MaximumWinningNumber);
                Pocket winningPocket = Pockets.SingleOrDefault(x => x.Number == _winningNumber);
                double winningNumberStartAngleDegrees = winningPocket.AngularPositionDegrees + ((RotateTransform)_wheelControl.RenderTransform).Angle;
                _winningNumberEndAngleDegrees = CorrectAngleDegrees(winningNumberStartAngleDegrees + (double)_wheelAnimation.By);
                
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
            OnWheelSpinning?.Invoke(false);  // Publish the status of the wheel.
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

                if (_ballSpinningAnimation == null)
                {
                    // Initialize the ball spinning animation.
                    _ballSpinningAnimation = new DoubleAnimation();
                    _ballSpinningAnimation.SpeedRatio = Constants.BallSpeedRatio;
                    _ballSpinningAnimation.DecelerationRatio = Constants.BallDecelerationRatio;
                    //_ballSpinningAnimation.FillBehavior = FillBehavior.HoldEnd;
                    Storyboard.SetTargetName(_ballSpinningAnimation, Constants.BallRotateTransformName);
                    Storyboard.SetTargetProperty(_ballSpinningAnimation, new PropertyPath(RotateTransform.AngleProperty));
                    _ballStoryBoard.Children.Add(_ballSpinningAnimation);  // Add the animation to the story board.
                }

                // Number of rotations in total degrees - multiply by ball speed ratio (positive degrees for clockwise).
                _ballSpinningAnimation.From = 0;
                _ballSpinningAnimation.To = _winningNumberEndAngleDegrees + (Constants.FullCircleDegrees * Constants.BallSpeedRatio);

                // Duration of spin seconds - multiply by ball speed ratio.
                _ballSpinningAnimation.Duration = TimeSpan.FromSeconds(_randomNumberGenerator.Next(Constants.MinimumBallSpinDurationSeconds * Constants.BallSpeedRatio, Constants.MaximumBallSpinDurationSeconds * Constants.BallSpeedRatio));

                //if (_ballFallingAnimation == null)
                //{
                //    // Initialize the ball falling animation.
                //    _ballFallingAnimation = new DoubleAnimation();
                //    _ballFallingAnimation.SpeedRatio = Constants.BallSpeedRatio;
                //    _ballFallingAnimation.DecelerationRatio = Constants.BallDecelerationRatio;
                //    //_ballFallingAnimation.FillBehavior = FillBehavior.HoldEnd;
                //    Storyboard.SetTargetName(_ballFallingAnimation, Constants.BallTranslateTransformName);
                //    Storyboard.SetTargetProperty(_ballFallingAnimation, new PropertyPath(TranslateTransform.YProperty));
                //    _ballStoryBoard.Children.Add(_ballFallingAnimation);  // Add the animation to the story board.
                //}

                //// Distance for the ball to fall in pixels - multiply by ball speed ratio (positive degrees for clockwise).
                //double ballYTravelDistancePixels = _ballControl.Width > _ballControl.Height ? (Constants.BallYTravelDistancePercentage * _ballControl.Height) / 2 : (Constants.BallYTravelDistancePercentage * _ballControl.Width) / 2;
                //_ballFallingAnimation.To = BallOffsetYPixels + ballYTravelDistancePixels;

                //// Duration of fall in seconds - same as rotation duration.
                //_ballFallingAnimation.Duration = _ballSpinningAnimation.Duration;
                
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
            OnBallTossed?.Invoke(false);  // Publish the status of the ball.
            SystemSounds.Beep.Play();
        }

        /// <summary>
        /// The RetrieveBall method is called to remove the ball from the wheel.
        /// </summary>
        public void RetrieveBall()
        {
            // TBD: Remove the ball from the pocket it landed in.
            OnBallTossed?.Invoke(false);    // Publish the status of the ball - ball is no longer in the wheel.
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
                _wheelControl.Width = mainBorder.ActualWidth;
                _wheelControl.Height = mainBorder.ActualHeight;
                _ballControl.Width = mainBorder.ActualWidth;
                _ballControl.Height = mainBorder.ActualHeight;

                // Main center point for all 3 wheels and the ball.
                CenterPointXPixels = _wheelControl.Width / 2;
                CenterPointYPixels = _wheelControl.Height / 2;

                // Outer wheel diameter and offset.
                OuterWheelDiameterXPixels = _wheelControl.Width > _wheelControl.Height ? Constants.OuterWheelDiameterPercentage * _wheelControl.Height : Constants.OuterWheelDiameterPercentage * _wheelControl.Width;
                OuterWheelDiameterYPixels = OuterWheelDiameterXPixels;
                OuterWheelOffsetXPixels = (_wheelControl.Width / 2) - (OuterWheelDiameterXPixels / 2);
                OuterWheelOffsetYPixels = (_wheelControl.Height / 2) - (OuterWheelDiameterYPixels / 2);

                // Center wheel diameter and offset.
                CenterWheelDiameterXPixels = _wheelControl.Width > _wheelControl.Height ? Constants.CenterWheelDiameterPercentage * _wheelControl.Height : Constants.CenterWheelDiameterPercentage * _wheelControl.Width;
                CenterWheelDiameterYPixels = CenterWheelDiameterXPixels;
                CenterWheelOffsetXPixels = (_wheelControl.Width / 2) - (CenterWheelDiameterXPixels / 2);
                CenterWheelOffsetYPixels = (_wheelControl.Height / 2) - (CenterWheelDiameterYPixels / 2);

                // Inner wheel diameter and circumference.
                double innerWheelDiameter = _wheelControl.Width > _wheelControl.Height ? Constants.InnerWheelDiameterPercentage * _wheelControl.Height : Constants.InnerWheelDiameterPercentage * _wheelControl.Width;
                double innerWheelCircumference = Math.PI * innerWheelDiameter;
                
                // Pocket width and position.
                double pocketWidthPixels = innerWheelCircumference / Constants.NumberOfPockets;
                double pocketHeightPixels = innerWheelDiameter * Constants.PocketHeightPercentage;
                double pocketXPositionPixels = CenterPointXPixels - (pocketWidthPixels / 2);
                double pocketYPositionPixels = (CenterPointYPixels - (innerWheelDiameter / 2));

                // Update the width and position for every pocket.
                foreach (Pocket pocket in Pockets)
                {
                    pocket.UpdatePocketShape(pocketWidthPixels, pocketHeightPixels, pocketXPositionPixels, pocketYPositionPixels, CenterPointXPixels, CenterPointYPixels);
                }

                // Ball diameter and offset.
                double ballInitialYOffsetPixels = _ballControl.Width > _ballControl.Height ? (Constants.BallYOffsetPercentage * _ballControl.Height) / 2 : (Constants.BallYOffsetPercentage * _ballControl.Width) / 2;
                BallDiameterXPixels = _ballControl.Width > _ballControl.Height ? Constants.BallDiameterPercentage * _ballControl.Height : Constants.BallDiameterPercentage * _ballControl.Width;
                BallDiameterYPixels = BallDiameterXPixels;
                BallOffsetXPixels = (_ballControl.Width / 2) - (BallDiameterXPixels / 2);
                BallOffsetYPixels = (_ballControl.Height / 2) - (BallDiameterYPixels / 2) - ballInitialYOffsetPixels;
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
