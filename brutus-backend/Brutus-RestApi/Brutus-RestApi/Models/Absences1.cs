using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Absences1
    {
        public string Excused { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LessonDatetime { get; set; }
    }
}
