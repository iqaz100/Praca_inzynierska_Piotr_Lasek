﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class GradeGroupedGet
    {
        public string key { get; set; }
        public List<GradeGet> grades { get; set; }
    }
}
