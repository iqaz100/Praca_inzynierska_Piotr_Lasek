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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectManager subjectManager;
        private readonly IMapper mapper;
        public SubjectController(ISubjectManager subjectManager, IMapper mapper)
        {
            this.subjectManager = subjectManager;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllCourses")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<SubjectGet> GetAllCourses()
        {
            var subjects = mapper.Map<IEnumerable<SubjectGet>>(subjectManager.GetAllSubjects());
            return subjects;
        }
    }
}