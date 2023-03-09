using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_Models.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Products")]
        public int ProductID { get; set; }
        public Products Products { get; set; }
        public int Star { get; set; }
    }
}
