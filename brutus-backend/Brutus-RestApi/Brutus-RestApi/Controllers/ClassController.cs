using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brutus_RestApi.Contracts;
using Brutus_RestApi.Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Brutus_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassManager classManager;
        private readonly IMapper mapper;
        public ClassController(IClassManager classManager, IMapper mapper)
        {
            this.classManager = classManager;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllClasses")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<ClassGet> GetAllClasses()
        {
            var classes = mapper.Map<IEnumerable<ClassGet>>(classManager.GetAllClases());
            return classes;
        }
    }
}