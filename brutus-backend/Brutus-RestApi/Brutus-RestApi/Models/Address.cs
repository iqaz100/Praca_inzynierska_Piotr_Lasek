using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class Address
    {
        public Address()
        {
            Person = new HashSet<Person>();
        }

        public int AddressId { get; set; }
        public string ApartamentNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
