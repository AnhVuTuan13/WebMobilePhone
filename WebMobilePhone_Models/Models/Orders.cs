using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_Models.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public string CustomerID { get; set; }
        public User User { get; set; }
        public DateTime Create { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public int? Payment { get; set; }
    }
}
