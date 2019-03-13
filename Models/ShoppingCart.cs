using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Book> Books { get; set; }
        public float TotalPrice { get; set; }
    }
}
