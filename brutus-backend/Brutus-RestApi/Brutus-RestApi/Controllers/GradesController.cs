using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brutus_RestApi.Contracts;
using Brutus_RestApi.Managers.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brutus_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradesManager gradesManager;
        private readonly IMapper mapper;
        public GradesController(IGradesManager gradesManager, IMapper mapper)
        {
            this.gradesManager = gradesManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("AddGrade")]
        [EnableCors("AllowOrigin")]
        public IActionResult AddGrade([FromBody] GradeAdd grade)
        {
            this.gradesManager.AddGrade(grade);
            return Ok(grade);
        }

        [HttpGet]
        [Route("GetStudentGrades")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<GradeGroupedGet> GetStudentGrades([FromQuery] int studentId)
        {
            var response = this.gradesManager.GetAllStudentGrades(studentId);
            Response.Headers.Add("Access-Control-itd", "*");
            return response;
        }

        [HttpGet]
        [Route("GetAverageGrade")]
        [EnableCors("AllowOrigin")]
        public decimal GetAverageGrade([FromQuery] int studentId, [FromQuery] int subjectId)
        {
            return this.gradesManager.GetAverageGrade(studentId, subjectId);
        }

        [HttpGet]
        [Route("GetSubjectGrades")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<GradeGet> GetSubjectGrades([FromQuery] int subjectId)
        {
            return this.gradesManager.GetAllSubjectGrades(subjectId);
        }
        [HttpGet]
        [Route("GetClassGrades")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<GradeStudentGroupedGet> GetClassGrades([FromQuery] int classId, [FromQuery] int subjectId)
        {
            return this.gradesManager.GetAllFromClass(classId, subjectId);
        }
        [HttpDelete]
        [Route("DeleteGrade")]
        [EnableCors("AllowOrigin")]
        public IActionResult DeleteGrade([FromQuery] int gradeId)
        {
            this.gradesManager.DeleteGrade(new GradeDelete { GradeId = gradeId });
            return Ok();
        }
    }
}