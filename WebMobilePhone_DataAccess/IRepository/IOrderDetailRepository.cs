using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace WebMobilePhone_DataAccess.IRepository
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
       public List<OrderDetail> GetOrdersByOrderID(int orderID);
     
    }
}
