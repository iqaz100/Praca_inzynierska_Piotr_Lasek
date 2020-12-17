using AutoMapper;
using Brutus_RestApi.Contracts;
using Brutus_RestApi.Managers.Interfaces;
using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Classes
{
    public class AbsenceManager : IAbsenceManager
    {
        private readonly IAbsenceRepository absenceRepository;
        private readonly IMapper mapper;

        public AbsenceManager(IAbsenceRepository absenceRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.absenceRepository = absenceRepository;
        }

        public AbsenceGet ExcuseAbsence(int idAbsence)
        {
            return mapper.Map<AbsenceGet>(absenceRepository.ExcuseAbsence(idAbsence));
        }

        public IEnumerable<Absence> GetAllAbsences()
        {
            return absenceRepository.GetAll();
        }

        public IEnumerable<Absence> GetAllStudentAbsences(int idStudent)
        {
            return absenceRepository.GetAllStudentAbsences(idStudent);
        }
    }
}
