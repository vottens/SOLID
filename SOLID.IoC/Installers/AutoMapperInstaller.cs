using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimpleInjector;
using SOLID.BLL.System;
using SOLID.Global.DTOs;
using SOLID.Global.Enums.System;
using SOLID.Global.Interfaces.BLL;
using SOLID.Global.Interfaces.IoC;
using SOLID.Global.Models;

namespace SOLID.IoC
{
    public class AutoMapperInstaller : IInstaller
    {
        public int Priority => 1;

        public IntergrationTypes Types
            =>
                IntergrationTypes.ExecutionContextScope
                | IntergrationTypes.LifetimeScope
                | IntergrationTypes.WCFOperation
                | IntergrationTypes.WebAPIRequest
                | IntergrationTypes.WebRequest;

        public void RegisterServices(Container container)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(BLLAssemblyType));
            Type abstraction = typeof(IModelMapper);
            IEnumerable<Type> types = assembly.GetTypes().Where(t => abstraction.IsAssignableFrom(t) && t.IsClass);
            List<IModelMapper> mappers = types.Select(t => (IModelMapper)Activator.CreateInstance(t)).ToList();

            Action<IMapperConfiguration> action = (Action<IMapperConfiguration>)Delegate.Combine(mappers.Select(modelMapper => modelMapper.RegisterMappings()).ToArray());
            container.RegisterSingleton<IMapper>(() => new MapperConfiguration(action).CreateMapper());
        }
    }
}
