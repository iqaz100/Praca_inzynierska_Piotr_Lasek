using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class StudentRepository : IStudentRepository
    {
        private mydbContext context;
        public StudentRepository(mydbContext context)
        {
            this.context = context;
        }

        public void Add(Student Contract)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Student Contract)
        {
            throw new NotImplementedException();
        }

        public Student Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Student;
        }

        public void Update(Student Contract)
        {
            throw new NotImplementedException();
        }
    }
}
