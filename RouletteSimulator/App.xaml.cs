using RouletteSimulator.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Dealer;
using Player;
using Board;
using Bank;
using Wheel;

namespace RouletteSimulator
{
    /// <summary>
    /// The App class represents the top level logic for the application.
    /// </summary>
    public partial class App
    {
        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// The CreateShell method is called to create the shell for this application.
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<RouletteSimulatorView>();
        }

        /// <summary>
        /// The RegisterTypes method is called to register pages for navigation.
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        /// <summary>
        /// The ConfigureModuleCatalog method is called to load the modules into the module catalog.
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<BankModule>();
            moduleCatalog.AddModule<WheelModule>();
            moduleCatalog.AddModule<BoardModule>();
            moduleCatalog.AddModule<PlayerModule>();
            moduleCatalog.AddModule<DealerModule>();
        }

        /// <summary>
        /// The InitializeModules method is called to initialise the module catalog.
        /// </summary>
        protected override void InitializeModules()
        {
            base.InitializeModules();
        }

        #endregion
    }
}
