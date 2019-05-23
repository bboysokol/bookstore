using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class ShoppingCart
    {
        public int ISBN { get; set; }
        public Book Book { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
