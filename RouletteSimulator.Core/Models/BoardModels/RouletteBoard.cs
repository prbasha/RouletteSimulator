using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    /// <summary>
    /// The RouletteBoard class represents a roulette board.
    /// </summary>
    public class RouletteBoard : BindableBase
    {

        #region Fields

        // TBD: Inside bets (straight, split, street, corner, double street, trio, first four).

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RouletteBoard()
        {
            try
            {
                // Initialize Outside bets.
                FirstColumnBet = new ColumnBet(BetType.FirstColumn);
                SecondColumnBet = new ColumnBet(BetType.SecondColumn);
                ThirdColumnBet = new ColumnBet(BetType.ThirdColumn);
                FirstDozenBet = new DozenBet(BetType.FirstDozen);
                SecondDozenBet = new DozenBet(BetType.SecondDozen);
                ThirdDozenBet = new DozenBet(BetType.ThirdDozen);
                LowBet = new LowHighBet(BetType.Low);
                HighBet = new LowHighBet(BetType.High);
                EvenBet = new EvenOddBet(BetType.Even);
                OddBet = new EvenOddBet(BetType.Odd);
                RedBet = new RedBlackBet(BetType.Red);
                BlackBet = new RedBlackBet(BetType.Black);

                // Initialize Inside bets.
                ZeroBet = new StraightBet { FirstNumber = 0 };
                TrioBet1 = new StreetBet() { FirstNumber = 0, SecondNumber = 1, ThirdNumber = 2 };
                TrioBet2 = new StreetBet() { FirstNumber = 0, SecondNumber = 2, ThirdNumber = 3 };
                FirstFourBet = new CornerBet() { FirstNumber = 0, SecondNumber = 1, ThirdNumber = 2, FourthNumber = 3 };
                StraightBets = new ObservableCollection<StraightBet>()
                {
                    new StraightBet() {FirstNumber = 1},
                    new StraightBet() {FirstNumber = 2},
                    new StraightBet() {FirstNumber = 3},
                    new StraightBet() {FirstNumber = 4},
                    new StraightBet() {FirstNumber = 5},
                    new StraightBet() {FirstNumber = 6},
                    new StraightBet() {FirstNumber = 7},
                    new StraightBet() {FirstNumber = 8},
                    new StraightBet() {FirstNumber = 9},
                    new StraightBet() {FirstNumber = 10},
                    new StraightBet() {FirstNumber = 11},
                    new StraightBet() {FirstNumber = 12},
                    new StraightBet() {FirstNumber = 13},
                    new StraightBet() {FirstNumber = 14},
                    new StraightBet() {FirstNumber = 15},
                    new StraightBet() {FirstNumber = 16},
                    new StraightBet() {FirstNumber = 17},
                    new StraightBet() {FirstNumber = 18},
                    new StraightBet() {FirstNumber = 19},
                    new StraightBet() {FirstNumber = 20},
                    new StraightBet() {FirstNumber = 21},
                    new StraightBet() {FirstNumber = 22},
                    new StraightBet() {FirstNumber = 23},
                    new StraightBet() {FirstNumber = 24},
                    new StraightBet() {FirstNumber = 25},
                    new StraightBet() {FirstNumber = 26},
                    new StraightBet() {FirstNumber = 27},
                    new StraightBet() {FirstNumber = 28},
                    new StraightBet() {FirstNumber = 29},
                    new StraightBet() {FirstNumber = 30},
                    new StraightBet() {FirstNumber = 31},
                    new StraightBet() {FirstNumber = 32},
                    new StraightBet() {FirstNumber = 33},
                    new StraightBet() {FirstNumber = 34},
                    new StraightBet() {FirstNumber = 35},
                    new StraightBet() {FirstNumber = 36}
                };
                HorizontalSplitBets = new ObservableCollection<SplitBet>()
                {
                    new SplitBet() {FirstNumber = 1, SecondNumber = 2},
                    new SplitBet() {FirstNumber = 2, SecondNumber = 3},
                    new SplitBet() {FirstNumber = 4, SecondNumber = 5},
                    new SplitBet() {FirstNumber = 5, SecondNumber = 6},
                    new SplitBet() {FirstNumber = 7, SecondNumber = 8},
                    new SplitBet() {FirstNumber = 8, SecondNumber = 9},
                    new SplitBet() {FirstNumber = 10, SecondNumber = 11},
                    new SplitBet() {FirstNumber = 11, SecondNumber = 12},
                    new SplitBet() {FirstNumber = 13, SecondNumber = 14},
                    new SplitBet() {FirstNumber = 14, SecondNumber = 15},
                    new SplitBet() {FirstNumber = 16, SecondNumber = 17},
                    new SplitBet() {FirstNumber = 17, SecondNumber = 18},
                    new SplitBet() {FirstNumber = 19, SecondNumber = 20},
                    new SplitBet() {FirstNumber = 20, SecondNumber = 21},
                    new SplitBet() {FirstNumber = 22, SecondNumber = 23},
                    new SplitBet() {FirstNumber = 23, SecondNumber = 24},
                    new SplitBet() {FirstNumber = 25, SecondNumber = 26},
                    new SplitBet() {FirstNumber = 26, SecondNumber = 27},
                    new SplitBet() {FirstNumber = 28, SecondNumber = 29},
                    new SplitBet() {FirstNumber = 29, SecondNumber = 30},
                    new SplitBet() {FirstNumber = 31, SecondNumber = 32},
                    new SplitBet() {FirstNumber = 32, SecondNumber = 33},
                    new SplitBet() {FirstNumber = 34, SecondNumber = 35},
                    new SplitBet() {FirstNumber = 35, SecondNumber = 36}
                };
                VerticalSplitBets = new ObservableCollection<SplitBet>()
                {
                    new SplitBet() {FirstNumber = 0, SecondNumber = 1},
                    new SplitBet() {FirstNumber = 0, SecondNumber = 2},
                    new SplitBet() {FirstNumber = 0, SecondNumber = 3},
                    new SplitBet() {FirstNumber = 1, SecondNumber = 4},
                    new SplitBet() {FirstNumber = 2, SecondNumber = 5},
                    new SplitBet() {FirstNumber = 3, SecondNumber = 6},
                    new SplitBet() {FirstNumber = 4, SecondNumber = 7},
                    new SplitBet() {FirstNumber = 5, SecondNumber = 8},
                    new SplitBet() {FirstNumber = 6, SecondNumber = 9},
                    new SplitBet() {FirstNumber = 7, SecondNumber = 10},
                    new SplitBet() {FirstNumber = 8, SecondNumber = 11},
                    new SplitBet() {FirstNumber = 9, SecondNumber = 12},
                    new SplitBet() {FirstNumber = 10, SecondNumber = 13},
                    new SplitBet() {FirstNumber = 11, SecondNumber = 14},
                    new SplitBet() {FirstNumber = 12, SecondNumber = 15},
                    new SplitBet() {FirstNumber = 13, SecondNumber = 16},
                    new SplitBet() {FirstNumber = 14, SecondNumber = 17},
                    new SplitBet() {FirstNumber = 15, SecondNumber = 18},
                    new SplitBet() {FirstNumber = 16, SecondNumber = 19},
                    new SplitBet() {FirstNumber = 17, SecondNumber = 20},
                    new SplitBet() {FirstNumber = 18, SecondNumber = 21},
                    new SplitBet() {FirstNumber = 19, SecondNumber = 22},
                    new SplitBet() {FirstNumber = 20, SecondNumber = 23},
                    new SplitBet() {FirstNumber = 21, SecondNumber = 24},
                    new SplitBet() {FirstNumber = 22, SecondNumber = 25},
                    new SplitBet() {FirstNumber = 23, SecondNumber = 26},
                    new SplitBet() {FirstNumber = 24, SecondNumber = 27},
                    new SplitBet() {FirstNumber = 25, SecondNumber = 28},
                    new SplitBet() {FirstNumber = 26, SecondNumber = 29},
                    new SplitBet() {FirstNumber = 27, SecondNumber = 30},
                    new SplitBet() {FirstNumber = 28, SecondNumber = 31},
                    new SplitBet() {FirstNumber = 29, SecondNumber = 32},
                    new SplitBet() {FirstNumber = 30, SecondNumber = 33},
                    new SplitBet() {FirstNumber = 31, SecondNumber = 34},
                    new SplitBet() {FirstNumber = 32, SecondNumber = 35},
                    new SplitBet() {FirstNumber = 33, SecondNumber = 36}
                };
                StreetBets = new ObservableCollection<StreetBet>()
                {
                    new StreetBet() {FirstNumber = 1, SecondNumber = 2, ThirdNumber = 3},
                    new StreetBet() {FirstNumber = 4, SecondNumber = 5, ThirdNumber = 6},
                    new StreetBet() {FirstNumber = 7, SecondNumber = 8, ThirdNumber = 9},
                    new StreetBet() {FirstNumber = 10, SecondNumber = 11, ThirdNumber = 12},
                    new StreetBet() {FirstNumber = 13, SecondNumber = 14, ThirdNumber = 15},
                    new StreetBet() {FirstNumber = 16, SecondNumber = 17, ThirdNumber = 18},
                    new StreetBet() {FirstNumber = 19, SecondNumber = 20, ThirdNumber = 21},
                    new StreetBet() {FirstNumber = 22, SecondNumber = 23, ThirdNumber = 24},
                    new StreetBet() {FirstNumber = 25, SecondNumber = 26, ThirdNumber = 27},
                    new StreetBet() {FirstNumber = 28, SecondNumber = 29, ThirdNumber = 30},
                    new StreetBet() {FirstNumber = 31, SecondNumber = 32, ThirdNumber = 33},
                    new StreetBet() {FirstNumber = 34, SecondNumber = 35, ThirdNumber = 36}
                };
                CornerBets = new ObservableCollection<CornerBet>()
                {
                    new CornerBet() {FirstNumber = 1, SecondNumber = 2, ThirdNumber = 4, FourthNumber = 5},
                    new CornerBet() {FirstNumber = 2, SecondNumber = 3, ThirdNumber = 5, FourthNumber = 6},
                    new CornerBet() {FirstNumber = 4, SecondNumber = 5, ThirdNumber = 7, FourthNumber = 8},
                    new CornerBet() {FirstNumber = 5, SecondNumber = 6, ThirdNumber = 8, FourthNumber = 9},
                    new CornerBet() {FirstNumber = 7, SecondNumber = 8, ThirdNumber = 10, FourthNumber = 11},
                    new CornerBet() {FirstNumber = 8, SecondNumber = 9, ThirdNumber = 11, FourthNumber = 12},
                    new CornerBet() {FirstNumber = 10, SecondNumber = 11, ThirdNumber = 13, FourthNumber = 14},
                    new CornerBet() {FirstNumber = 11, SecondNumber = 12, ThirdNumber = 14, FourthNumber = 15},
                    new CornerBet() {FirstNumber = 13, SecondNumber = 14, ThirdNumber = 16, FourthNumber = 17},
                    new CornerBet() {FirstNumber = 14, SecondNumber = 15, ThirdNumber = 17, FourthNumber = 18},
                    new CornerBet() {FirstNumber = 16, SecondNumber = 17, ThirdNumber = 19, FourthNumber = 20},
                    new CornerBet() {FirstNumber = 17, SecondNumber = 18, ThirdNumber = 20, FourthNumber = 21},
                    new CornerBet() {FirstNumber = 19, SecondNumber = 20, ThirdNumber = 22, FourthNumber = 23},
                    new CornerBet() {FirstNumber = 20, SecondNumber = 21, ThirdNumber = 23, FourthNumber = 24},
                    new CornerBet() {FirstNumber = 22, SecondNumber = 23, ThirdNumber = 25, FourthNumber = 26},
                    new CornerBet() {FirstNumber = 23, SecondNumber = 24, ThirdNumber = 26, FourthNumber = 27},
                    new CornerBet() {FirstNumber = 25, SecondNumber = 26, ThirdNumber = 28, FourthNumber = 29},
                    new CornerBet() {FirstNumber = 26, SecondNumber = 27, ThirdNumber = 29, FourthNumber = 30},
                    new CornerBet() {FirstNumber = 28, SecondNumber = 29, ThirdNumber = 31, FourthNumber = 32},
                    new CornerBet() {FirstNumber = 29, SecondNumber = 30, ThirdNumber = 32, FourthNumber = 33},
                    new CornerBet() {FirstNumber = 31, SecondNumber = 32, ThirdNumber = 34, FourthNumber = 35},
                    new CornerBet() {FirstNumber = 32, SecondNumber = 33, ThirdNumber = 35, FourthNumber = 36}
                };
                DoubleStreetBets = new ObservableCollection<DoubleStreetBet>()
                {
                    new DoubleStreetBet() {FirstNumber = 1, SecondNumber = 2, ThirdNumber = 3, FourthNumber = 4, FifthNumber = 5, SixthNumber = 6},
                    new DoubleStreetBet() {FirstNumber = 4, SecondNumber = 5, ThirdNumber = 6, FourthNumber = 7, FifthNumber = 8, SixthNumber = 9},
                    new DoubleStreetBet() {FirstNumber = 7, SecondNumber = 8, ThirdNumber = 9, FourthNumber = 10, FifthNumber = 11, SixthNumber = 12},
                    new DoubleStreetBet() {FirstNumber = 10, SecondNumber = 11, ThirdNumber = 12, FourthNumber = 13, FifthNumber = 14, SixthNumber = 15},
                    new DoubleStreetBet() {FirstNumber = 13, SecondNumber = 14, ThirdNumber = 15, FourthNumber = 16, FifthNumber = 17, SixthNumber = 18},
                    new DoubleStreetBet() {FirstNumber = 16, SecondNumber = 17, ThirdNumber = 18, FourthNumber = 19, FifthNumber = 20, SixthNumber = 21},
                    new DoubleStreetBet() {FirstNumber = 19, SecondNumber = 20, ThirdNumber = 21, FourthNumber = 22, FifthNumber = 23, SixthNumber = 24},
                    new DoubleStreetBet() {FirstNumber = 22, SecondNumber = 23, ThirdNumber = 24, FourthNumber = 25, FifthNumber = 26, SixthNumber = 27},
                    new DoubleStreetBet() {FirstNumber = 25, SecondNumber = 26, ThirdNumber = 27, FourthNumber = 28, FifthNumber = 29, SixthNumber = 30},
                    new DoubleStreetBet() {FirstNumber = 28, SecondNumber = 29, ThirdNumber = 30, FourthNumber = 31, FifthNumber = 32, SixthNumber = 33},
                    new DoubleStreetBet() {FirstNumber = 31, SecondNumber = 32, ThirdNumber = 33, FourthNumber = 34, FifthNumber = 35, SixthNumber = 36}
                };
            }
            catch (Exception ex)
            {
                throw new Exception("RouletteBoard(): " + ex.ToString());
            }
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the first column bet.
        /// </summary>
        public ColumnBet FirstColumnBet { get; }

        /// <summary>
        /// Gets the second column bet.
        /// </summary>
        public ColumnBet SecondColumnBet { get; }

        /// <summary>
        /// Gets the third column bet.
        /// </summary>
        public ColumnBet ThirdColumnBet { get; }

        /// <summary>
        /// Gets the first dozen bet.
        /// </summary>
        public DozenBet FirstDozenBet { get; }

        /// <summary>
        /// Gets the second dozen bet.
        /// </summary>
        public DozenBet SecondDozenBet { get; }

        /// <summary>
        /// Gets the third dozen bet.
        /// </summary>
        public DozenBet ThirdDozenBet { get; }

        /// <summary>
        /// Gets the low bet.
        /// </summary>
        public LowHighBet LowBet { get; }

        /// <summary>
        /// Gets the high bet.
        /// </summary>
        public LowHighBet HighBet { get; }

        /// <summary>
        /// Gets the even bet.
        /// </summary>
        public EvenOddBet EvenBet { get; }

        /// <summary>
        /// Gets odd bet.
        /// </summary>
        public EvenOddBet OddBet { get; }

        /// <summary>
        /// Gets the red bet.
        /// </summary>
        public RedBlackBet RedBet { get; }

        /// <summary>
        /// Gets black bet.
        /// </summary>
        public RedBlackBet BlackBet { get; }

        /// <summary>
        /// Gets the collection of straight bets.
        /// </summary>
        public ObservableCollection<StraightBet> StraightBets { get; }

        /// <summary>
        /// Gets the collection of horizontal split bets.
        /// </summary>
        public ObservableCollection<SplitBet> HorizontalSplitBets { get; }

        /// <summary>
        /// Gets the collection of vertical split bets.
        /// </summary>
        public ObservableCollection<SplitBet> VerticalSplitBets { get; }

        /// <summary>
        /// Gets the collection of street bets.
        /// </summary>
        public ObservableCollection<StreetBet> StreetBets { get; }
        
        /// <summary>
        /// Gets the collection of corner bets.
        /// </summary>
        public ObservableCollection<CornerBet> CornerBets { get; }

        /// <summary>
        /// Gets the collection of double-street bets.
        /// </summary>
        public ObservableCollection<DoubleStreetBet> DoubleStreetBets { get; }

        /// <summary>
        ///Gets the zero bet.
        /// </summary>
        public StraightBet ZeroBet { get;  }

        /// <summary>
        /// Gets the first trio bet.
        /// </summary>
        public StreetBet TrioBet1 { get; }

        /// <summary>
        /// Gets the second trio bet.
        /// </summary>
        public StreetBet TrioBet2 { get; }

        /// <summary>
        /// Gets the first-four bet.
        /// </summary>
        public CornerBet FirstFourBet { get; }

        #endregion

        #region Methods
        #endregion
    }
}
