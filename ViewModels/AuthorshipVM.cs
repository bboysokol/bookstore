using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class AuthorshipVM
    {
        [Key]
        public int Id { get; set; }
        public ICollection<AuthorVM> Authors { get; set; }
    }
}
