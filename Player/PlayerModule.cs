using Player.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Player
{
    /// <summary>
    /// The PlayerModule class represents the Player module.
    /// </summary>
    public class PlayerModule : IModule
    {
        #region Fields

        private readonly IRegionManager _regionManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="regionManager"></param>
        public PlayerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        #endregion

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// The OnInitialized method is called when the module is initialized.
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("PlayerRegion", typeof(PlayerView));
        }

        /// <summary>
        /// The RegisterTypes method is called to register pages for navigation.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        #endregion
    }
}