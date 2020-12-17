using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class SubjectGet
    {
        public string Description { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
