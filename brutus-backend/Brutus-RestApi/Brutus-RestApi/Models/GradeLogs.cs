﻿using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class GradeLogs
    {
        public string ChangeType { get; set; }
        public DateTime? LogDate { get; set; }
        public string Who { get; set; }
    }
}
