using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class ClassRepository : IClassRepository
    {
        private mydbContext context;
        public ClassRepository(mydbContext context)
        {
            this.context = context;
        }
        public void Add(Class Contract)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Class Contract)
        {
            throw new NotImplementedException();
        }

        public Class Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetAll()
        {
            return context.Class;
        }

        public void Update(Class Contract)
        {
            throw new NotImplementedException();
        }
    }
}
