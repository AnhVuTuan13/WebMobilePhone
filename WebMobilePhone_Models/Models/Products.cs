using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_Models.Models
{
    public class Products
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Categories")]
        public int CategoryID { get; set; }
        public Categories Categories { get; set; }
        public string Decription { get; set; }
        public string Content { get; set; }
        public int Hot { get; set; }
        public string? Photo { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public int Amount { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
