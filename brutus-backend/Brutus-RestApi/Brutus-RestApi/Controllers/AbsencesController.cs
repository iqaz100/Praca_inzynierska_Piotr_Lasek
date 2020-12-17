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
    public class AbsencesController : ControllerBase
    {
        private readonly IAbsenceManager absenceManager;
        private readonly IMapper mapper;
        public AbsencesController(IAbsenceManager absenceManager, IMapper mapper)
        {
            this.absenceManager = absenceManager;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllAbsences")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<AbsenceGet> GetAllAbsences()
        {
            var absences = mapper.Map<IEnumerable<AbsenceGet>>(absenceManager.GetAllAbsences());
            return absences;
        }

        [HttpGet]
        [Route("GetAllStudentAbsences")]
        [EnableCors("AllowOrigin")]
        public IEnumerable<AbsenceGet> GetAllStudentAbsences([FromQuery] int idStudent)
        {
            var absences = mapper.Map<IEnumerable<AbsenceGet>>(absenceManager.GetAllStudentAbsences(idStudent));
            return absences;
        }

        [HttpPut]
        [Route("ExcuseAbsence")]
        [EnableCors("AllowOrigin")]
        public IActionResult ExcuseStudentAbsence([FromQuery] int idAbsence)
        {
            var excusedAbsence = absenceManager.ExcuseAbsence(idAbsence);
            if(excusedAbsence == null)
            {
                return BadRequest();
            }
            return Ok(excusedAbsence);
        }
    }
}