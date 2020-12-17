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
    public class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;
        private readonly IMapper mapper;

        public ClassManager(IClassRepository classRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.classRepository = classRepository;
        }
        public IEnumerable<ClassGet> GetAllClases()
        {
            return mapper.Map<IEnumerable<ClassGet>>(classRepository.GetAll());
        }
    }
}
