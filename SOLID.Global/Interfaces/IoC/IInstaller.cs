using SimpleInjector;
using SOLID.Global.Enums.System;

namespace SOLID.Global.Interfaces.IoC
{
    public interface IInstaller
    {
        int Priority { get; }
        IntergrationTypes Types { get; }
        void RegisterServices(Container container);
    }
}
