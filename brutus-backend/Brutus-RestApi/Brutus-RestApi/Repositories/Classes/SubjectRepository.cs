using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class SubjectRepository : ISubjectRepository
    {
        private mydbContext context;
        public SubjectRepository(mydbContext context)
        {
            this.context = context;
        }

        public void Add(Subject Contract)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Subject Contract)
        {
            throw new NotImplementedException();
        }

        public Subject Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> GetAll()
        {
            return context.Subject;
        }

        public void Update(Subject Contract)
        {
            throw new NotImplementedException();
        }
    }
}
