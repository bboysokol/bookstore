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
        public string Title { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public string PublishmentYear { get; set; }
        public float Price { get; set; }
        public Authorship Authorship { get; set; }
        public ICollection<Category> Category { get; set; }
    }
}
