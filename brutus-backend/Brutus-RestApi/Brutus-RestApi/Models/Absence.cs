using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Absence
    {
        public int AbsenceId { get; set; }
        public string Excused { get; set; }
        public int LessonsLessonId { get; set; }
        public int StudentsStudentId { get; set; }
    }
}
