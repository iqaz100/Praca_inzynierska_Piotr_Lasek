using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Timetable2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LessonDatetime { get; set; }
        public string Room { get; set; }
        public string SubjectName { get; set; }
    }
}
