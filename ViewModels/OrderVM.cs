using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class OrderVM
    {
        [Key]
        public int Id { get; set; }
        public ClientVM Client { get; set; }
        public string Date { get; set; }
        public bool IsDone { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public decimal Price { get; set; }
    }
}
