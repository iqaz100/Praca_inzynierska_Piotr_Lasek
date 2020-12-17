using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class ClassGet
    {
        public int ClassId { get; set; }
        public string ClassTitle { get; set; }
        public int EndYear { get; set; }
        public int StartYear { get; set; }
        public int TeachersTeacherId { get; set; }
    }
}
