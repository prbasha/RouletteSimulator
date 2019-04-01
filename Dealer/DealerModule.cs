using Dealer.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Dealer
{
    public class DealerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public DealerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("DealerRegion", typeof(DealerView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}