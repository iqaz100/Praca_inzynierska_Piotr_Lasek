using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public string ClassTitle { get; set; }
        public int EndYear { get; set; }
        public int StartYear { get; set; }
        public int TeachersTeacherId { get; set; }
    }
}
