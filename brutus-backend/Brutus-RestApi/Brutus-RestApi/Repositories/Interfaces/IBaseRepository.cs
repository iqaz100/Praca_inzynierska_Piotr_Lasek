using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Get();
        IEnumerable<T> GetAll();
        void Add(T Contract);
        void Update(T Contract);
        void Delete(T Contract);
        void Commit();

    }
}
