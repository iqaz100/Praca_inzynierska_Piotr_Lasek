using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class PersonRepository : IPersonRepository
    {
        private mydbContext context;

        public PersonRepository(mydbContext context)
        {
            this.context = context;
        }
        public void Add(Person Contract)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Person Contract)
        {
            throw new NotImplementedException();
        }

        public Person Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            return context.Person;
        }

        public void Update(Person Contract)
        {
            throw new NotImplementedException();
        }
    }
}
