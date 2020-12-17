using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Login
    {
        public Login()
        {
            Person = new HashSet<Person>();
        }

        public string Login1 { get; set; }
        public int LoginId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
