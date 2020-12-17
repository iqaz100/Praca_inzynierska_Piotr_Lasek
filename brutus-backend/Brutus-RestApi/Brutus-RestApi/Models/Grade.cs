using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Grade
    {
        public DateTime GradeDatetime { get; set; }
        public int GradeId { get; set; }
        public string GradeScale { get; set; }
        public string GradeType { get; set; }
        public int GradedefGradedefId { get; set; }
        public int StudentsStudentId { get; set; }
        public int SubjectsSubjectId { get; set; }
        public int TeachersTeacherId { get; set; }

        public virtual Gradedef GradedefGradedef { get; set; }
        public virtual Subject SubjectsSubject { get; set; }
    }
}
