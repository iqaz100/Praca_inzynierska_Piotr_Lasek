using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class BehaviorAdd
    {
        public string BehaviorDescription { get; set; }
        public string BehaviorType { get; set; }
        public int StudentId { get; set; }
    }
}
