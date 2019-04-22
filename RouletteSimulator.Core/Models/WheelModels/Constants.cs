namespace RouletteSimulator.Core.Models.WheelModels
{
    /// <summary>
    /// The Constants class contains any constants.
    /// </summary>
    public static class Constants
    {
        public const double NumberOfPockets = 37;
        public const double PocketStepDegrees = 9.7297;
        public const double PocketHeightPercentage = 0.15;
        public const double PocketWidth1Percentage = 0.85;
        public const double PocketWidth2Percentage = 0.15;
        public const int Zero = 0;
        public static readonly int[] WheelNumbers = { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };
        public static readonly int[] RedWinningNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        public static readonly int[] BlackWinningNumbers = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
    }
}
