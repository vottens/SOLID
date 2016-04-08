using System;
using AutoMapper;

namespace SOLID.Global.Interfaces.BLL
{
    public interface IModelMapper
    {
        Action<IMapperConfiguration> RegisterMappings();
    }
}