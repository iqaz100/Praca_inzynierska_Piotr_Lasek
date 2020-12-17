using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brutus_RestApi.Contracts;
using Brutus_RestApi.Managers.Classes;
using Brutus_RestApi.Managers.Interfaces;
using Brutus_RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brutus_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentManager studentManager;
        private readonly IMapper mapper;
        public StudentsController(IStudentManager studentManager, IMapper mapper)
        {
            this.studentManager = studentManager;
            this.mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<StudentGet> GetAll()
        {
            return mapper.Map<IEnumerable<StudentGet>>(studentManager.GetAll());
        }
    }
} 
