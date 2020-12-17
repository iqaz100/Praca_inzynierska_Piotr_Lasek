using Brutus_RestApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Managers.Interfaces
{
    public interface IClassManager
    {
        IEnumerable<ClassGet> GetAllClases();
    }
}
