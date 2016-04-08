using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SOLID.Global.Enums.System;

namespace SOLID.IoC
{
    public class DependencyInjectionProvider
    {
        public void Initialize(HttpConfiguration configuration)
        {
            var container = BuildContainer(configuration);
            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
        private static Container BuildContainer(HttpConfiguration configuration)
        {
            var container = new Container();
            InstallerResolver.Initialize(container, IntergrationTypes.WebAPIRequest);
            container.RegisterWebApiControllers(configuration);
            container.Verify();
            return container;
        }
    }
}
