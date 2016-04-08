using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SOLID.Global.Enums.System;
using SOLID.Global.Interfaces.IoC;

namespace SOLID.IoC
{
    public class InstallerResolver
    {
        private static List<IInstaller> Installers { get; set; }

        private static IntergrationTypes Types { get; set; }

        private static Container Container { get; set; }

        public static void Initialize(Container container, IntergrationTypes types)
        {
            Types = types;
            Container = container;
            Container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            CreateInstallersForIntergartionType();
            Register();
        }

        private static void CreateInstallersForIntergartionType()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(InstallerResolver));

            Type abstraction = typeof(IInstaller);

            IEnumerable<Type> types = assembly.GetTypes().Where(t => abstraction.IsAssignableFrom(t) && t.IsClass);

            Installers = types.Select(t => (IInstaller)Activator.CreateInstance(t)).ToList();
        }

        private static void Register()
        {
            Installers
                .Where(i => i.Types.HasFlag(Types))
                .OrderBy(i => i.Priority)
                .ToList()
                .ForEach(installer => installer.RegisterServices(Container));
        }
    }
}
