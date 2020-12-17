using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Family
    {
        public int ParentsParentId { get; set; }
        public int StudentsStudentId { get; set; }
    }
}
