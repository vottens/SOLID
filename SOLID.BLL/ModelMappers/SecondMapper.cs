using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOLID.Global.DTOs;
using SOLID.Global.Interfaces.BLL;
using SOLID.Global.Models;

namespace SOLID.BLL.ModelMappers
{
    public class SecondMapper: IModelMapper
    {
        public Action<IMapperConfiguration> RegisterMappings()
        {
            Action<IMapperConfiguration> mapperConfigurationAction = cfg =>
            {
                // models -> dtos
                cfg.CreateMap<Second, SecondDto>()
                   .ForMember(m => m.Extra, opt => opt.MapFrom(src => "Vincent"));

                //dtos => models
                cfg.CreateMap<SecondDto, Second>();
            };

            return mapperConfigurationAction;
        }
    }
}
