using Prism.Commands;
using Prism.Mvvm;
using RouletteSimulator.Core.Models.BoardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Board.ViewModels
{
    /// <summary>
    /// The BoardViewModel class represents the view model for the Board module.
    /// </summary>
    public class BoardViewModel : BindableBase
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BoardViewModel()
        {
            // Models.
            RouletteBoard = new RouletteBoard();

            // Testing chips.
            Bet.SelectedChip = RouletteSimulator.Core.Enumerations.ChipType.One;
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the roulette board.
        /// </summary>
        public RouletteBoard RouletteBoard { get; }
        
        #endregion

        #region Methods
        #endregion
    }
}
