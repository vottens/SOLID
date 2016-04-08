using System.Collections.Generic;
using SOLID.Global.DTOs;

namespace SOLID.Global.Interfaces.BLL
{
    public interface IServiceTest
    {
        List<FirstDto> GetInfo();
        void AddFirst(FirstDto first);
    }
}
