using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class AbsenceGet
    {
        public int AbsenceId { get; set; }
        public string Excused { get; set; }
        public int LessonsLessonId { get; set; }
        public int StudentsStudentId { get; set; }
        public string SubjectName { get; set; }
        public string TopicName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LessonDatetime { get; set; }
    }
}
