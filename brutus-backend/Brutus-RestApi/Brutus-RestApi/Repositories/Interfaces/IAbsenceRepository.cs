using Brutus_RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Interfaces
{
    public interface IAbsenceRepository : IBaseRepository<Absence>
    {
        IEnumerable<Absence> GetAllStudentAbsences(int studentId);
        Absence ExcuseAbsence(int absenceId);
    }
}
