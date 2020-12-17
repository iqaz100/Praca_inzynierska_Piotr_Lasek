using Brutus_RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Interfaces
{
    public interface IGradeRepository : IBaseRepository<Grade>
    {
        IEnumerable<Grade> GetAllFromSubject(int subjectId);
        IEnumerable<Grade> GetAllFromClass(int classId);
    }
}
