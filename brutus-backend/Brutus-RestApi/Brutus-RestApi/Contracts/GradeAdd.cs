using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class GradeAdd
    {
        public int GradeScale { get; set; }
        public string GradeType { get; set; }
        public int StudentId { get; set; }
        public int GradedefId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
