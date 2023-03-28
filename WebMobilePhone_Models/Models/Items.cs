using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebMobilePhone_Models.Models
{
    public class Items
    {
        //thuong tin san pham
        public Products ProductItem { get; set; }
        //so luong
        public double GiiaBan { get; set; }
        public int Quantity { get; set; }
        public double ThanhTien
        {
            get
            {
                return GiiaBan * Quantity;
            }
        }

    }
}
