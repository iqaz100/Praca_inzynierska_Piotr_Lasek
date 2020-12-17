using Brutus_RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Interfaces
{
    public interface IStudentManager 
    {
        public List<Student> GetAll();
    }
}
