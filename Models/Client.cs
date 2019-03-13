using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Client :IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartamentNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
