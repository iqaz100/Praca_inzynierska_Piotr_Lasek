using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class StudentGet
    {
        public int ClassesClassId { get; set; }
        public int ParentsParentId { get; set; }
        public int PersonsPersonId { get; set; }
        public int StudentId { get; set; }
    }
}
