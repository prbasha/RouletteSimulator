using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel.Views
{
    /// <summary>
    /// The Constants class contains any constants.
    /// </summary>
    public static class Constants
    {
        public const string WheelName = "Wheel";
        public const string WheelRotateTransformName = "WheelRotateTransform";
        public const string BallName = "Ball";
        public const string BallRotateTransformName = "BallRotateTransform";
        public const string BallTranslateTransformName = "BallTranslateTransform";
        public const double MidPoint = 0.5;
        public const double StartAngle = 0;
        public const double StartPosition = 0;
        public const int WheelSpeedRatio = 3;
        public const double WheelDecelerationRatio = 0.50;
        public const int MinimumWheelSpinDurationSeconds = 25;
        public const int MaximumWheelSpinDurationSeconds = 36;
        public const int MinimumWheelSpinDistanceDegrees = 1080;
        public const int MaximumWheelSpinDistanceDegrees = 2161;
        public const int BallSpeedRatio = 6;
        public const double BallDecelerationRatio = 0.25;
        public const int MinimumBallSpinDurationSeconds = 15;
        public const int MaximumBallSpinDurationSeconds = 21;
        public const int MinimumBallSpinDistanceDegrees = 1080;
        public const int MaximumBallSpinDistanceDegrees = 2161;
        public const double FullCircleDegrees = 360;
        public const double OuterWheelDiameterPercentage = 0.95;
        public const double CenterWheelDiameterPercentage = 0.80;
        public const double InnerWheelDiameterPercentage = 0.76;
        public const double NumberOfPockets = 37;
        public const double PocketStepDegrees = 9.7297;
        public const double PocketHeightPercentage = 0.15;
        public const double PocketWidth1Percentage = 0.85;
        public const double PocketWidth2Percentage = 0.15;
        public const double BallDiameterPercentage = 0.03;
        public const double BallYOffsetPercentage = 0.90;
        public const int Zero = 0;
        public static readonly int[] RedWinningNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        public static readonly int[] BlackWinningNumbers = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
        public const int MinimumWinningNumber = 0;
        public const int MaximumWinningNumber = 37;
    }
}
