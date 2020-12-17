using Brutus_RestApi.Managers.Interfaces;
using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Classes;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Classes
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository studentRepository;
        public StudentManager(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public List<Student> GetAll()
        {
            return studentRepository.GetAll().ToList();
        }
    }
}
