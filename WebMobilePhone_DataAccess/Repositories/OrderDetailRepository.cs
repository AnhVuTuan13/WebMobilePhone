using WebMobilePhone_DataAccess.Data;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_DataAccess.IRepository;
using WebMobilePhone_Models.Models;
using WebMobilePhone_Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Data.Common;

namespace WebMobilePhone_DataAccess.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext context) : base(context)
        {
        }

        public List<OrderDetail> GetOrdersByOrderID(int orderID)
        {
           return Context.Set<OrderDetail>().Where(tbl => tbl.OrderID == orderID).ToList();
        }
    }
}
