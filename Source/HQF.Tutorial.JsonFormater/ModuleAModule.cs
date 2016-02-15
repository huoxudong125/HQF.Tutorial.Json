using HQF.Tutorial.JsonFormater.Views;
using Prism.Modularity;
using Prism.Regions;

namespace HQF.Tutorial.JsonFormater
{
    public class ModuleAModule : IModule
    {
        private IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(ViewA));
        }
    }
}