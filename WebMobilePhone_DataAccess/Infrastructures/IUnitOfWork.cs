using WebMobilePhone_DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMobilePhone_DataAccess.IRepository;

namespace WebMobilePhone_DataAccess.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoriesRepository CategoryRepository { get; }
        public IProductsRepository ProductsRepository { get; }
        int SaveChanges();
    }
}
