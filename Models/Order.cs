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
        [Required]
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        [ForeignKey("ShoppingCartId")]
        public virtual ShoppingCart ShoppingCart { get; set; }

    }
}
