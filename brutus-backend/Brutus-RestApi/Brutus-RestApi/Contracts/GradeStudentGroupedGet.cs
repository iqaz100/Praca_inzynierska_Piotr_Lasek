using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class GradeStudentGroupedGet
    {
        public int studentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<GradeWithStudentGet> grades { get; set; }
    }
}
