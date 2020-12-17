using AutoMapper;
using Brutus_RestApi.Contracts;
using Brutus_RestApi.Managers.Interfaces;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Classes
{
    public class SubjectManager : ISubjectManager
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IMapper mapper;

        public SubjectManager(ISubjectRepository subjectRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.subjectRepository = subjectRepository;
        }
        public IEnumerable<SubjectGet> GetAllSubjects()
        {
            return mapper.Map<IEnumerable<SubjectGet>>(subjectRepository.GetAll()); 
        }
    }
}
