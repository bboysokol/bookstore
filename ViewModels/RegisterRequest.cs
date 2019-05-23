using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.ViewModels
{
    public class RegisterRequest : LoginRequest
    {

        public string Surname { get; set; }
        public string Name { get; set; }
        [Required]
        public string ConfirmedPassword { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartamentNumber { get; set; }

    }
}
