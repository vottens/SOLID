using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SOLID.Global.DTOs;
using SOLID.Global.Interfaces.BLL;
using SOLID.Global.Interfaces.DAL;
using SOLID.Global.Models;

namespace SOLID.BLL
{
    public class ServicesTest : IServiceTest, IService
    {
        private readonly IRepository<First> _repository;
        private readonly IMapper _mapper;

        public ServicesTest(IRepository<First> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<FirstDto> GetInfo()
        {
            var models = _repository.All().ToList();
            var dtos = _mapper.Map<List<First>, List<FirstDto>>(models);
            return dtos;
        }

        public void AddFirst(FirstDto first)
        {
            var model = _mapper.Map<FirstDto, First>(first);
            model.Description = model.Description + _repository.All().Count();
            _repository.InsertOrUpdate(model);
            _repository.Save();
        }
    }
}
