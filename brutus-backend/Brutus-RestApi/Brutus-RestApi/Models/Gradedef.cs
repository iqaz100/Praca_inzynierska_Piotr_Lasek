using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Gradedef
    {
        public Gradedef()
        {
            GradeNavigation = new HashSet<Grade>();
        }

        public decimal Grade { get; set; }
        public int GradedefId { get; set; }

        public virtual ICollection<Grade> GradeNavigation { get; set; }
    }
}
