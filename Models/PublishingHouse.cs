using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class PublishingHouse
    {
        [Key]
        public int Id { get; set; }
        public string Ttile { get; set; }
    }
}
