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
    public interface IOrdersRepository : IBaseRepository<Orders>
    {
        public DataTable DataTableCreatePrice(DateTime fromDate,  DateTime toDate );
        public DataTable DataTableSelectTop2(DateTime fromDate, DateTime toDate);
        public DataTable DataTableSelectTop1ASC(DateTime fromDate, DateTime toDate);

    }
}
