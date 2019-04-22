using Board.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using RouletteSimulator.Core;

namespace Board
{
    /// <summary>
    /// The BoardModule class represents the Board module.
    /// </summary>
    public class BoardModule : IModule
    {
        #region Fields

        private readonly IRegionManager _regionManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="regionManager"></param>
        public BoardModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// The OnInitialized method is called when the module is initialized.
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.BoardRegion, typeof(BoardView));
        }

        /// <summary>
        /// The RegisterTypes method is called to register pages for navigation.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        #endregion

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Methods
        #endregion
    }
}