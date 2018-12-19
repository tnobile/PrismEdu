using Microsoft.Practices.Unity;
using NavigationSampleApp.Views;
using Prism.Unity;
using System.Linq;
using System.Windows;

namespace NavigationSampleApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            ((Window)this.Shell).Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Viewを全てobject型としてコンテナに登録しておく（RegionManagerで使うため）
            this.Container.RegisterTypes(
                AllClasses.FromLoadedAssemblies()
                    .Where(x => x.Namespace.EndsWith(".Views")),
                getFromTypes: _ => new[] { typeof(object) },
                getName: WithName.TypeName);

            // ViewModelLocatorでViewModelを生成する方法をUnityで行うようにする
            //ViewModelLocationProvider.SetDefaultViewModelFactory(t => this.Container.Resolve(t));
        }
    }
}
