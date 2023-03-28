using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.IRepository
{
    public interface IProductsRepository : IBaseRepository<Products>
    {
        public List<Products> GetByCategoriesId(int id);
        public List<Products> GetByDiscountId(int id);
        public List<Products> GetByOrderByDescending();
        public Products GetByName(string name);
        public List<Products> HotProduct();
    }
}
