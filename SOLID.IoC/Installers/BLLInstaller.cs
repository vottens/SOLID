using System;
using System.Collections.Generic;
using System.Linq;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using SOLID.Global.Enums.System;
using SOLID.Global.Interfaces.BLL;
using SOLID.Global.Interfaces.IoC;

namespace SOLID.IoC
{
    public class BLLInstaller
    {
        public class PerWebRequestInstaller : IInstaller
        {
            public int Priority => 4;
            public IntergrationTypes Types => IntergrationTypes.WebRequest;

            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
                RegisterAll(container);
            }
        }
        public class PerWebAPIRequestInstaller : IInstaller
        {
            public int Priority => 4;
            public IntergrationTypes Types => IntergrationTypes.WebAPIRequest;
            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
                RegisterAll(container);
            }
        }
        public class PerWCFRequestInstaller : IInstaller
        {
            public int Priority => 4;
            public IntergrationTypes Types => IntergrationTypes.WCFOperation;
            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();
                RegisterAll(container);
            }
        }
        public class PerLifetimeRequestInstaller : IInstaller
        {
            public int Priority => 4;
            public IntergrationTypes Types => IntergrationTypes.LifetimeScope;
            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
                RegisterAll(container);
            }
        }
        public class PerExecutionContextScopeInstaller : IInstaller
        {
            public int Priority => 4;
            public IntergrationTypes Types => IntergrationTypes.ExecutionContextScope;
            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
                RegisterAll(container);
            }
        }
        private static void RegisterAll(Container container)
        {
            var interfaceType = typeof(IService);

            List<Type> types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(t => interfaceType.IsAssignableFrom(t) && !t.Name.Equals(interfaceType.Name)).ToList();

            foreach (var type in types)
            {
                var abstraction = type.GetInterfaces().FirstOrDefault(i => !Equals(i.Name, interfaceType.Name));

                container.Register(abstraction, type, Lifestyle.Scoped);
            }
        }
    }
}
