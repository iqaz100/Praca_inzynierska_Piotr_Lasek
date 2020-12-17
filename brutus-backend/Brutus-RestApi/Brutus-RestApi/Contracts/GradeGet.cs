using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class GradeGet
    {
        public int GradeId { get; set; }
        public int GradeScale { get; set; }
        public string GradeType { get; set; }
        public decimal GradeValue { get; set; }
        public string SubjectName { get; set; }
        public DateTime GradeDatetime { get; set; }
    }
}
