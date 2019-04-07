using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The Constants class contains any constants.
    /// </summary>
    public static class Constants
    {
        // Exposures/Outcomes.
        public const int StraightExposure = 35;
        public const int StraightOutcome = 1;
        public const int SplitExposure = 17;
        public const int SplitOutcome = 1;
        public const int StreetExposure = 11;
        public const int StreetOutcome = 1;
        public const int TrioExposure = 11;
        public const int TrioOutcome = 1;
        public const int FirstFourExposure = 8;
        public const int FirstFourOutcome = 1;
        public const int CornerExposure = 8;
        public const int CornerOutcome = 1;
        public const int DoubleStreetExposure = 5;
        public const int DoubleStreetOutcome = 1;
        public const int ColumnExposure = 2;
        public const int ColumnOutcome = 1;
        public const int DozenExposure = 2;
        public const int DozenOutcome = 1;
        public const int LowHighExposure = 1;
        public const int LowHighOutcome = 1;
        public const int EvenOddExposure = 1;
        public const int EvenOddOutcome = 1;
        public const int RedBlackExposure = 1;
        public const int RedBlackOutcome = 1;
        // Outside bets winning numbers.
        public static readonly int[] FirstColumnWinningNumbers = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
        public static readonly int[] SecondColumnWinningNumbers = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        public static readonly int[] ThirdColumnWinningNumbers = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
        public static readonly int[] FirstDozenWinningNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public static readonly int[] SecondDozenWinningNumbers = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        public static readonly int[] ThirdDozenWinningNumbers = { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
        public static readonly int[] LowWinningNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
        public static readonly int[] HighWinningNumbers = { 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
        public static readonly int[] EvenWinningNumbers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };
        public static readonly int[] OddWinningNumbers = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
        public static readonly int[] RedWinningNumbers = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        public static readonly int[] BlackWinningNumbers = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
    }
}
