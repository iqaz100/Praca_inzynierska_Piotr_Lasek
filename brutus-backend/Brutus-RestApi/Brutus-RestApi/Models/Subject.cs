using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Grade = new HashSet<Grade>();
            Lesson = new HashSet<Lesson>();
        }

        public string Description { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
