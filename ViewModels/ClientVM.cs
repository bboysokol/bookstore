using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class ClientVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartamentNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
