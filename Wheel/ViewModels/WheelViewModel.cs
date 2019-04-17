using Prism.Commands;
using Prism.Mvvm;
using RouletteSimulator.Core.Models.WheelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel.ViewModels
{
    /// <summary>
    /// The WheelViewModel class represents the view model for the Wheel module.
    /// </summary>
    public class WheelViewModel : BindableBase
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public WheelViewModel()
        {
            RouletteWheel = new RouletteWheel();    // Models.
        }

        #endregion

        #region Events
        #endregion

        #region Properties

        /// <summary>
        /// Gets the roulette board.
        /// </summary>
        public RouletteWheel RouletteWheel { get; }

        #endregion

        #region Methods
        #endregion
    }
}
