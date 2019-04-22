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
        public const double WheelSpeedRatio = 2;
        public const double WheelDecelerationRatio = 0.50;
        public const int WheelSpinDurationSeconds = 23;
        public const int MinimumWheelSpinDistanceDegrees = 1080;
        public const int MaximumWheelSpinDistanceDegrees = 2161;
        public const double BallSpeedRatio = 4;
        public const double BallDecelerationRatio = 0.25;
        public const double BallFallPercent = 0.65;
        public const double StoppingDecelerationRatio = 1;
        public const int StoppingSpinDistanceDegrees = 1080;
        public const double FullCircleDegrees = 360;
        public const double OuterWheelDiameterPercentage = 0.95;
        public const double CenterWheelDiameterPercentage = 0.80;
        public const double InnerWheelDiameterPercentage = 0.76;
        public const double BallDiameterPercentage = 0.03;
        public const double BallYOffsetPercentage = 0.90;
        public const int MinimumWinningNumber = 0;
        public const int MaximumWinningNumber = 37;
        public const string BallAudioFile = @"\Sounds\ball_rolling.wav";
    }
}
