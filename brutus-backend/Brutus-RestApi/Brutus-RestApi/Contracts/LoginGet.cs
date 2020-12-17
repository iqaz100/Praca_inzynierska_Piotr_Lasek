using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Contracts
{
    public class LoginGet
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
