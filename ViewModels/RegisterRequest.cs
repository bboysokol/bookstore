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

        [Required]
        public string ConfirmedPassword { get; set; }

        
    }
}
