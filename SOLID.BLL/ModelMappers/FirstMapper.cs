using System;
using AutoMapper;
using SOLID.Global.DTOs;
using SOLID.Global.Interfaces.BLL;
using SOLID.Global.Models;

namespace SOLID.BLL.ModelMappers
{
    public class FirstMapper : IModelMapper
    {
        public Action<IMapperConfiguration> RegisterMappings()
        {
            Action<IMapperConfiguration> mapperConfigurationAction = cfg =>
               {
                // models -> dtos
                cfg.CreateMap<First, FirstDto>()
                   .ForMember(m => m.Extra, opt => opt.MapFrom(src => "Vincent"));

                //dtos => models
                cfg.CreateMap<FirstDto, First>();
               };

            return mapperConfigurationAction;
        }
    }
}
