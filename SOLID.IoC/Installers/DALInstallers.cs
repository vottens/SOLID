using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using SOLID.DAL;
using SOLID.Global.Enums.System;
using SOLID.Global.Interfaces.DAL;
using SOLID.Global.Interfaces.IoC;

namespace SOLID.IoC
{
    public class DALInstallers
    {
        public class PerWebRequestInstaller : IInstaller
        {
            public int Priority => 3;
            public IntergrationTypes Types => IntergrationTypes.WebRequest;

            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
                RegisterRepositories(container);
                RegisterCommands(container);
            }
        }

        public class PerWebAPIRequestInstaller : IInstaller
        {
            public int Priority => 3;
            public IntergrationTypes Types => IntergrationTypes.WebAPIRequest;

            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
                RegisterRepositories(container);
                RegisterCommands(container);
            }
        }

        public class PerWCFRequestInstaller : IInstaller
        {
            public int Priority => 3;
            public IntergrationTypes Types => IntergrationTypes.WCFOperation;

            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();
                RegisterRepositories(container);
                RegisterCommands(container);
            }
        }

        public class PerLifetimeRequestInstaller : IInstaller
        {
            public int Priority => 3;
            public IntergrationTypes Types => IntergrationTypes.LifetimeScope;

            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();
                RegisterRepositories(container);
                RegisterCommands(container);
            }
        }

        public class PerExecutionContextScopeInstaller : IInstaller
        {
            public int Priority => 3;
            public IntergrationTypes Types => IntergrationTypes.ExecutionContextScope;

            public void RegisterServices(Container container)
            {
                if (container.Options.DefaultScopedLifestyle == null)
                    container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
                RegisterRepositories(container);
                RegisterCommands(container);
            }
        }

        private static void RegisterCommands(Container container)
        {
            var interfaceType = typeof(ICommand);

            List<Type> types = Assembly.GetAssembly(typeof(GenericRepository<>)).GetTypes()
                .Where(t => interfaceType.IsAssignableFrom(t) && !t.Name.Equals(interfaceType.Name)).ToList();

            foreach (var type in types)
            {
                var abstraction = type.GetInterfaces().FirstOrDefault(i => !Equals(i.Name, interfaceType.Name));
                container.Register(abstraction, type, Lifestyle.Scoped);
            }
        }

        private static void RegisterRepositories(Container container)
        {
            var implementationType = typeof(GenericRepository<>);

            var interfaceType = typeof(IRepository<>);

            var entityType = typeof(IEntity);

            List<Type> entities = Assembly.GetAssembly(entityType).GetTypes()
                .Where(t => entityType.IsAssignableFrom(t) && t.IsClass).ToList();

            foreach (var entity in entities)
            {
                Type specificInterfaceType = interfaceType.MakeGenericType(entity);
                Type specificImplementationType = implementationType.MakeGenericType(entity);

                container.Register(specificInterfaceType, specificImplementationType, Lifestyle.Scoped);
            }
        }
    }
}
