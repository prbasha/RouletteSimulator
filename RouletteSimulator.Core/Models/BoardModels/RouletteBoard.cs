using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using System;
using System.Collections.Generic;
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

        #endregion

        #region Methods
        #endregion
    }
}
