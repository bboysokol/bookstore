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
        public float Price { get; set; }
        [Required]
        public Authorship Authorship { get; set; }
        [Required]
        public ICollection<Category> Category { get; set; }
    }
}
