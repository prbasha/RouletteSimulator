using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.EventsAggregator;
using RouletteSimulator.Core.Models.BoardModels;
using RouletteSimulator.Core.Models.ChipModels;
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

        private EventAggregator _eventAggregator;

        #endregion

        #region Constructors

        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="eventAggregator"></param>
        public BoardViewModel(EventAggregator eventAggregator)
        {
            RouletteBoard = new RouletteBoard();    // Models.
            
            // Events.
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SelectedChipEvent>().Subscribe(SelectedChipEventHandler);
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

        /// <summary>
        /// The SelectedChipEventHandler handles an incoming SelectedChipEvent event.
        /// </summary>
        /// <param name="selectedChip"></param>
        private void SelectedChipEventHandler(ChipType selectedChip)
        {
            Bet.SelectedChip = selectedChip;    // Update chip selection.
        }

        #endregion
    }
}
