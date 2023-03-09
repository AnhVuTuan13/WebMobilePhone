using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_Models.Models
{
    public class Categories
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
