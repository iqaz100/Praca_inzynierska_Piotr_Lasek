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
    public class BehaviorManager : IBehaviorManager
    {
        private readonly IBehaviorRepository behaviorRepository;
        private readonly IMapper mapper;

        public BehaviorManager(IBehaviorRepository behaviorRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.behaviorRepository = behaviorRepository;
        }
        public void AddBehavior(BehaviorAdd behavior)
        {
            var newEntity = mapper.Map<Behavior>(behavior);
            behaviorRepository.Add(newEntity);
        }

        public IEnumerable<BehaviorGet> GetAllStudentBehavior(int idStudent)
        {
            var behaviors = behaviorRepository.GetAll().Where(x => x.StudentsStudentId == idStudent);
            return mapper.Map<IEnumerable<BehaviorGet>>(behaviors);
        }
    }
}
