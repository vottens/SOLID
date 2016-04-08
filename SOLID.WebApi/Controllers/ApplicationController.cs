using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SOLID.Global.DTOs;
using SOLID.Global.Interfaces.BLL;

namespace SOLID.WebApi.Controllers
{
    public class ApplicationController : ApiController
    {
        private readonly IServiceTest _service;

        public ApplicationController(IServiceTest service)
        {
            _service = service;
        }
        
        [HttpGet]
        public List<FirstDto> GetInfo()
        {
            return _service.GetInfo().ToList();
        }

        [HttpPost]
        public List<FirstDto> AddFirst(FirstDto first)
        {
            _service.AddFirst(first);

            return _service.GetInfo();
        }
    }
}
