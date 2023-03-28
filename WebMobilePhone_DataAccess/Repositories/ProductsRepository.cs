using WebMobilePhone_DataAccess.Data;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_DataAccess.IRepository;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebMobilePhone_DataAccess.Repositories
{
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        public ProductsRepository(AppDbContext context) : base(context)
        {
        }

        public List<Products> GetByCategoriesId(int id)
        {
            return Context.Set<Products>().Where(s => s.CategoryID == id).ToList();
        }

        public List<Products> GetByDiscountId(int id)
        {
            return Context.Set<Products>().Where(x=>x.DiscountID== id).ToList();
        }

        public Products GetByName(string name)
        {
            return Context.Set<Products>().Where(tbl => tbl.Name == name).FirstOrDefault();
        }

        public List<Products> GetByOrderByDescending()
        {
            return Context.Set<Products>().OrderByDescending(tbl => tbl.ID).ToList();

        }

        public List<Products> HotProduct()
        {
            return Context.Set<Products>().Where(tbl => tbl.Hot == 1).ToList();
        }
    }
}
