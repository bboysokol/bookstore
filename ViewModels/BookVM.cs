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
        public virtual PublishingHouseVM PublishingHouse { get; set; }
        public string PublishmentYear { get; set; }
        public float Price { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
