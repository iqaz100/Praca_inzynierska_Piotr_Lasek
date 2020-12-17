using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class AccountGet
    {
        public int LoginId { get; set; }
        public int Login { get; set; }
        public string Password { get; set; }

    }
}
