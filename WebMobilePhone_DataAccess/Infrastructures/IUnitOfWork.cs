using WebMobilePhone_DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoriesRepository CategoryRepository { get; }
        public IProductsRepository ProductsRepository { get; }
        public INewsRepository NewsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IUserRepository UserRepository { get; }
        public IDiscountRepository DiscountRepository { get; }
        public IRatingRepository RatingRepository { get; }
        int SaveChanges();
    }
}
