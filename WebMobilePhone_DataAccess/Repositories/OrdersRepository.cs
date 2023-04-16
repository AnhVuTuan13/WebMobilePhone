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
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(AppDbContext context) : base(context)
        {
        }

        public DataTable DataTableCreatePrice(DateTime fromDate, DateTime toDate)
        {
            var result = Context.Set<Orders>().AsEnumerable()
                .Where(c => c.Status == 1 && c.Create >= fromDate && c.Create <= toDate)
                .GroupBy(l => l.Create).Select(cl => new
                {
                    Create = cl.First().Create,
                    Price = cl.Sum(c => c.Price),
                });

            return result.LINQResultToDataTable();
        }

        public DataTable DataTableSelectTop1ASC(DateTime fromDate, DateTime toDate)
        {
            /* var result = (from o in Context.Set<Orders>().AsEnumerable()
                           join od in Context.Set<OrderDetail>().AsEnumerable()
                           on o.ID equals od.OrderID
                           join pd in Context.Set<Products>().AsEnumerable()
                           on od.ProductID equals pd.ID
                           join ds in Context.Set<Discount>().AsEnumerable()
                           on pd.DiscountID equals ds.Id
                           where o.Create >= fromDate && o.Create <= toDate
                           group new { od, pd, ds } by new { od.ProductID, pd.Name, pd.Price, ds.PercentDiscount,o.Create } into grp
                           select new
                           {
                               Name = grp.First().pd.Name,
                               Price = grp.First().pd.Price,
                               Discount = grp.First().ds.PercentDiscount,
                               soluongban = grp.Sum(k => k.od.Quantity)
                           }).OrderBy(x => x.soluongban).Take(1);*/


            var result = (from o in Context.Set<Orders>().AsEnumerable()
                          join od in Context.Set<OrderDetail>().AsEnumerable()
                          on o.ID equals od.OrderID
                          join pd in Context.Set<Products>().AsEnumerable()
                          on od.ProductID equals pd.ID
                          join ds in Context.Set<Discount>().AsEnumerable()
                          on pd.DiscountID equals ds.Id
                          where o.Create >= fromDate && o.Create <= toDate
                          group new { od, pd, ds } by new { od.ProductID, pd.Name, pd.Price, ds.PercentDiscount } into grp
                          select new
                          {
                              Name = grp.First().pd.Name,
                              Price = grp.First().pd.Price,
                              Discount = grp.First().ds.PercentDiscount,
                              soluongban = grp.Sum(k => k.od.Quantity),
                              Total = grp.Sum(k => k.od.Quantity) * grp.First().pd.Price
                          }).OrderByDescending(x => x.Total);

            return result.LINQResultToDataTable();
        }

        public DataTable DataTableSelectTop2(DateTime fromDate, DateTime toDate)
        {
            var result = (from o in Context.Set<Orders>().AsEnumerable()
                          join od in Context.Set<OrderDetail>().AsEnumerable()
                          on o.ID equals od.OrderID
                          join pd in Context.Set<Products>().AsEnumerable()
                          on od.ProductID equals pd.ID
                          join ds in Context.Set<Discount>().AsEnumerable()
                          on pd.DiscountID equals ds.Id
                          where o.Create >= fromDate && o.Create <= toDate
                          group new { od, pd, ds } by new { od.ProductID, pd.Name, pd.Price, ds.PercentDiscount, o.Create } into grp
                          select new
                          {
                              Name = grp.First().pd.Name,
                              Price = grp.First().pd.Price,
                              Discount = grp.First().ds.PercentDiscount,
                              soluongban = grp.Sum(k => k.od.Quantity)
                          }).OrderByDescending(x => x.soluongban).Take(2);

           

            return result.LINQResultToDataTable();
        }

        public List<Orders> GetByOrderByCustomer(string id)
        {
            return Context.Set<Orders>().Where(tbl => tbl.CustomerID == id).ToList();
        }

        public List<Orders> GetByOrderByDescending()
        {
            return Context.Set<Orders>().OrderByDescending(o => o.ID).ToList();
        }
    }
}
