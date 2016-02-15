using System.Windows;
using HQF.Tutorial.JsonFormater;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace HQF.Tutorial.Json
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ModuleAModule));
        }
    }
}