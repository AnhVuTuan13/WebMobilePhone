using WebMobilePhone_DataAccess.Data;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_DataAccess.IRepository;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.Repositories
{
    public class CategoriesRepository : BaseRepository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(AppDbContext context) : base(context)
        {
        }

        public Categories GetByName(string name)
        {
            return Context.Set<Categories>().Where(tbl => tbl.Name == name).FirstOrDefault();
        }

        public Categories GetByNameAndNotMapId(string name, int id)
        {
            return Context.Set<Categories>().Where(tbl => tbl.Name == name && tbl.Id != id).FirstOrDefault();
        }

        public List<Categories> GetByOrderByDescending()
        {
            return Context.Set<Categories>().OrderByDescending(tbl => tbl.Id).ToList();
        }

        public List<Categories> ListSubCategories(int id)
        {
            return Context.Set<Categories>().Where(tbl => tbl.Id == id).OrderByDescending(tbl => tbl.Id).ToList();
        }
    }
}
