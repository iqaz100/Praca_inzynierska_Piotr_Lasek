using System;
using System.Collections.Generic;

namespace Brutus_RestApi.Models
{
    public partial class User
    {
        public DateTime? CreateTime { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
