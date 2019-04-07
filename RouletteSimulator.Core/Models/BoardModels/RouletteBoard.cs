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

                StraightBets = new ObservableCollection<StraightBet>()
                {
                    new StraightBet(){FirstNumber = 1},
                    new StraightBet(){FirstNumber = 2},
                    new StraightBet(){FirstNumber = 3},
                    new StraightBet(){FirstNumber = 4},
                    new StraightBet(){FirstNumber = 5},
                    new StraightBet(){FirstNumber = 6},
                    new StraightBet(){FirstNumber = 7},
                    new StraightBet(){FirstNumber = 8},
                    new StraightBet(){FirstNumber = 9},
                    new StraightBet(){FirstNumber = 10},
                    new StraightBet(){FirstNumber = 11},
                    new StraightBet(){FirstNumber = 12},
                    new StraightBet(){FirstNumber = 13},
                    new StraightBet(){FirstNumber = 14},
                    new StraightBet(){FirstNumber = 15},
                    new StraightBet(){FirstNumber = 16},
                    new StraightBet(){FirstNumber = 17},
                    new StraightBet(){FirstNumber = 18},
                    new StraightBet(){FirstNumber = 19},
                    new StraightBet(){FirstNumber = 20},
                    new StraightBet(){FirstNumber = 21},
                    new StraightBet(){FirstNumber = 22},
                    new StraightBet(){FirstNumber = 23},
                    new StraightBet(){FirstNumber = 24},
                    new StraightBet(){FirstNumber = 25},
                    new StraightBet(){FirstNumber = 26},
                    new StraightBet(){FirstNumber = 27},
                    new StraightBet(){FirstNumber = 28},
                    new StraightBet(){FirstNumber = 29},
                    new StraightBet(){FirstNumber = 30},
                    new StraightBet(){FirstNumber = 31},
                    new StraightBet(){FirstNumber = 32},
                    new StraightBet(){FirstNumber = 33},
                    new StraightBet(){FirstNumber = 34},
                    new StraightBet(){FirstNumber = 35},
                    new StraightBet(){FirstNumber = 36}
                };

                HorizontalSplitBets = new ObservableCollection<SplitBet>()
                {
                    new SplitBet(){FirstNumber = 1, SecondNumber = 2},
                    new SplitBet(){FirstNumber = 2, SecondNumber = 3},
                    new SplitBet(){FirstNumber = 4, SecondNumber = 5},
                    new SplitBet(){FirstNumber = 5, SecondNumber = 6},
                    new SplitBet(){FirstNumber = 7, SecondNumber = 8},
                    new SplitBet(){FirstNumber = 8, SecondNumber = 9},
                    new SplitBet(){FirstNumber = 10, SecondNumber = 11},
                    new SplitBet(){FirstNumber = 11, SecondNumber = 12},
                    new SplitBet(){FirstNumber = 13, SecondNumber = 14},
                    new SplitBet(){FirstNumber = 14, SecondNumber = 15},
                    new SplitBet(){FirstNumber = 16, SecondNumber = 17},
                    new SplitBet(){FirstNumber = 17, SecondNumber = 18},
                    new SplitBet(){FirstNumber = 19, SecondNumber = 20},
                    new SplitBet(){FirstNumber = 20, SecondNumber = 21},
                    new SplitBet(){FirstNumber = 22, SecondNumber = 23},
                    new SplitBet(){FirstNumber = 23, SecondNumber = 24},
                    new SplitBet(){FirstNumber = 25, SecondNumber = 26},
                    new SplitBet(){FirstNumber = 26, SecondNumber = 27},
                    new SplitBet(){FirstNumber = 28, SecondNumber = 29},
                    new SplitBet(){FirstNumber = 29, SecondNumber = 30},
                    new SplitBet(){FirstNumber = 31, SecondNumber = 32},
                    new SplitBet(){FirstNumber = 32, SecondNumber = 33},
                    new SplitBet(){FirstNumber = 34, SecondNumber = 35},
                    new SplitBet(){FirstNumber = 35, SecondNumber = 36}
                };

                VerticalSplitBets = new ObservableCollection<SplitBet>()
                {
                    new SplitBet(){FirstNumber = 0, SecondNumber = 1},
                    new SplitBet(){FirstNumber = 0, SecondNumber = 2},
                    new SplitBet(){FirstNumber = 0, SecondNumber = 3},
                    new SplitBet(){FirstNumber = 1, SecondNumber = 4},
                    new SplitBet(){FirstNumber = 2, SecondNumber = 5},
                    new SplitBet(){FirstNumber = 3, SecondNumber = 6},
                    new SplitBet(){FirstNumber = 4, SecondNumber = 7},
                    new SplitBet(){FirstNumber = 5, SecondNumber = 8},
                    new SplitBet(){FirstNumber = 6, SecondNumber = 9},
                    new SplitBet(){FirstNumber = 7, SecondNumber = 10},
                    new SplitBet(){FirstNumber = 8, SecondNumber = 11},
                    new SplitBet(){FirstNumber = 9, SecondNumber = 12},
                    new SplitBet(){FirstNumber = 10, SecondNumber = 13},
                    new SplitBet(){FirstNumber = 11, SecondNumber = 14},
                    new SplitBet(){FirstNumber = 12, SecondNumber = 15},
                    new SplitBet(){FirstNumber = 13, SecondNumber = 16},
                    new SplitBet(){FirstNumber = 14, SecondNumber = 17},
                    new SplitBet(){FirstNumber = 15, SecondNumber = 18},
                    new SplitBet(){FirstNumber = 16, SecondNumber = 19},
                    new SplitBet(){FirstNumber = 17, SecondNumber = 20},
                    new SplitBet(){FirstNumber = 18, SecondNumber = 21},
                    new SplitBet(){FirstNumber = 19, SecondNumber = 22},
                    new SplitBet(){FirstNumber = 20, SecondNumber = 23},
                    new SplitBet(){FirstNumber = 21, SecondNumber = 24},
                    new SplitBet(){FirstNumber = 22, SecondNumber = 25},
                    new SplitBet(){FirstNumber = 23, SecondNumber = 26},
                    new SplitBet(){FirstNumber = 24, SecondNumber = 27},
                    new SplitBet(){FirstNumber = 25, SecondNumber = 28},
                    new SplitBet(){FirstNumber = 26, SecondNumber = 29},
                    new SplitBet(){FirstNumber = 27, SecondNumber = 30},
                    new SplitBet(){FirstNumber = 28, SecondNumber = 31},
                    new SplitBet(){FirstNumber = 29, SecondNumber = 32},
                    new SplitBet(){FirstNumber = 30, SecondNumber = 33},
                    new SplitBet(){FirstNumber = 31, SecondNumber = 34},
                    new SplitBet(){FirstNumber = 32, SecondNumber = 35},
                    new SplitBet(){FirstNumber = 33, SecondNumber = 36}
                };

                // TBD: Initialize Inside bets (straight, split, street, corner, double street, trio, first four).
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
        /// Gets or sets the first column bet.
        /// </summary>
        public ColumnBet FirstColumnBet { get; }

        /// <summary>
        /// Gets or sets the second column bet.
        /// </summary>
        public ColumnBet SecondColumnBet { get; }

        /// <summary>
        /// Gets or sets the third column bet.
        /// </summary>
        public ColumnBet ThirdColumnBet { get; }

        /// <summary>
        /// Gets or sets the first dozen bet.
        /// </summary>
        public DozenBet FirstDozenBet { get; }

        /// <summary>
        /// Gets or sets the second dozen bet.
        /// </summary>
        public DozenBet SecondDozenBet { get; }

        /// <summary>
        /// Gets or sets the third dozen bet.
        /// </summary>
        public DozenBet ThirdDozenBet { get; }

        /// <summary>
        /// Gets or sets the low bet.
        /// </summary>
        public LowHighBet LowBet { get; }

        /// <summary>
        /// Gets or sets the second high bet.
        /// </summary>
        public LowHighBet HighBet { get; }

        /// <summary>
        /// Gets or sets the even bet.
        /// </summary>
        public EvenOddBet EvenBet { get; }

        /// <summary>
        /// Gets or sets the second odd bet.
        /// </summary>
        public EvenOddBet OddBet { get; }

        /// <summary>
        /// Gets or sets the red bet.
        /// </summary>
        public RedBlackBet RedBet { get; }

        /// <summary>
        /// Gets or sets the second black bet.
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

        #endregion

        #region Methods
        #endregion
    }
}
