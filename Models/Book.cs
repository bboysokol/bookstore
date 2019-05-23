using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {   [Key]
        public int ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public PublishingHouse PublishingHouse { get; set; }
        [Required]
        public string PublishmentYear { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        [Required]
        public Category Category { get; set; }
        public string Img { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
