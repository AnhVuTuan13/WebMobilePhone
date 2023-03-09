using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_Models.Models
{
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        public Orders Orders { get; set; }
        [ForeignKey("Products")]
        public int ProductID { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
