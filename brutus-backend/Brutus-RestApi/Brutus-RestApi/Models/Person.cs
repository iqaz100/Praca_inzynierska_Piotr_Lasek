using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Person
    {
        public int AddressAddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LoginLoginId { get; set; }
        public int PersonId { get; set; }
        public int Pesel { get; set; }

        public virtual Address AddressAddress { get; set; }
        public virtual Login LoginLogin { get; set; }
    }
}
