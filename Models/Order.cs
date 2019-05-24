using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public string Date { get; set; } = String.Format("{0:g}", DateTime.Now);
        public bool IsDone { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public decimal Price { get; set; }

    }
}
