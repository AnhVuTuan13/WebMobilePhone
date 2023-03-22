using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebMobilePhone_Models.Models
{
    public class User: IdentityUser
    {
        public string? Avata { get; set; }
        public int? Status { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
    