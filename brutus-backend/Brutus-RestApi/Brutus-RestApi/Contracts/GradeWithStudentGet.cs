using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class GradeWithStudentGet
    {
        public int GradeId { get; set; }
        public int GradeScale { get; set; }
        public string GradeType { get; set; }
        public decimal GradeValue { get; set; }
        public string SubjectName { get; set; }
        public DateTime GradeDatetime { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
