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
        public string ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual ClientVM Client { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int ShoppingCartId { get; set; }
        [ForeignKey("ShoppingCartId")]
        public virtual ShoppingCartVM ShoppingCart { get; set; }
    }
}
