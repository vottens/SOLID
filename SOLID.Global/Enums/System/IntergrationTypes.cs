using System;

namespace SOLID.Global.Enums.System
{
    [Flags]
    public enum IntergrationTypes
    {
        WebRequest = 1,
        WebAPIRequest = 2,
        WCFOperation = 4,
        LifetimeScope = 8,
        ExecutionContextScope = 16,
    }
}
