using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BookVM
    {   [Key]
        public int ISBN { get; set; }
        public string Title { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public string PublishmentYear { get; set; }
        public decimal Price { get; set; }
        public ICollection<Author> Authors { get; set; }
        public Category Category { get; set; }
        public string Img { get; set; }
    }
}
