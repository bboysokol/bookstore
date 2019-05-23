using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Client :IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string ApartamentNumber { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        public string Token { get; set; }
        [Required]
        public bool IsAdmin { get; set; } = false;
        public ICollection<Order> Orders { get; set; }
    }
}
