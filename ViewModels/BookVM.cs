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
        public PublishingHouseVM PublishingHouse { get; set; }
        public string PublishmentYear { get; set; }
        public float Price { get; set; }
        public AuthorshipVM Authorship { get; set; }
        public ICollection<CategoryVM> Category { get; set; }
    }
}
