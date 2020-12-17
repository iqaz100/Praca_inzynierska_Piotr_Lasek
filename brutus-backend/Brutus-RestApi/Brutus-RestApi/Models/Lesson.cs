using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Lesson
    {
        public int ClassesClassId { get; set; }
        public DateTime LessonDatetime { get; set; }
        public TimeSpan LessonEnd { get; set; }
        public int LessonId { get; set; }
        public string Room { get; set; }
        public int SubjectsSubjectId { get; set; }
        public int TeachersTeacherId { get; set; }
        public string Topic { get; set; }

        public virtual Subject SubjectsSubject { get; set; }
    }
}
