using RouletteSimulator.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Dealer;
using Player;
using Board;
using Wheel;
using Bank;

namespace RouletteSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<RouletteSimulatorView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<DealerModule>();
            moduleCatalog.AddModule<BankModule>();
            moduleCatalog.AddModule<WheelModule>();
            moduleCatalog.AddModule<BoardModule>();
            moduleCatalog.AddModule<PlayerModule>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }
    }
}
