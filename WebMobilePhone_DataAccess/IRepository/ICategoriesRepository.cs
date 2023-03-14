using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.IRepository
{
    public interface ICategoriesRepository : IBaseRepository<Categories>
    {
        public Categories GetByName(string name);
        public Categories GetByNameAndNotMapId(string name, int id);
        public List<Categories> GetByOrderByDescending();
        public List<Categories> ListSubCategories(int id);
    }
}
