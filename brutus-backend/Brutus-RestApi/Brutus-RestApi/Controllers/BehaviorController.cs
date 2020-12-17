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
    public class BehaviorController : ControllerBase
    {
        private readonly IBehaviorManager behaviorManager;
        private readonly IMapper mapper;
        public BehaviorController(IBehaviorManager behaviorManager, IMapper mapper)
        {
            this.behaviorManager = behaviorManager;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("AddBehavior")]
        [EnableCors("AllowOrigin")]
        public IActionResult AddGrade([FromBody] BehaviorAdd behavior)
        {
            this.behaviorManager.AddBehavior(behavior);
            return Ok(behavior);
        }
        [HttpGet]
        [Route("GetStudentBehavior")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<BehaviorGet> GetAllStudentBehavior([FromQuery] int idStudent)
        {
            return this.behaviorManager.GetAllStudentBehavior(idStudent);
        }
    }
}