using WebMobilePhone_DataAccess.Data;
using WebMobilePhone_DataAccess.IRepository;
using WebMobilePhone_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMobilePhone_DataAccess.Infrastructures;

namespace WebMobilePhone_DataAccess.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

       
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        private     ICategoriesRepository _categoryRepository;
        public ICategoriesRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoriesRepository(_context);
                }
                return _categoryRepository;
            }

        }

        private IProductsRepository _productsRepository;
        public IProductsRepository ProductsRepository
        {
            get
            {
                if (_productsRepository == null)
                {
                    _productsRepository = new ProductsRepository(_context);
                }
                return _productsRepository;
            }

        }
        private INewsRepository _newsRepository;
        public INewsRepository NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_context);
                }
                return _newsRepository;
            }

        }
        private IOrdersRepository _ordersRepository;
        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                {
                    _ordersRepository = new OrdersRepository(_context);
                }
                return _ordersRepository;
            }

        }

        private IOrderDetailRepository _orderDetailRepository;
        public IOrderDetailRepository OrderDetailRepository
        {
            get
            {
                if (_orderDetailRepository == null)
                {
                    _orderDetailRepository = new OrderDetailRepository(_context);
                }
                return _orderDetailRepository;
            }

        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }

        }
        private IUserRoleRepository _userRoleRepository;
        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                {
                    _userRoleRepository = new UserRoleRepository(_context);
                }
                return _userRoleRepository;
            }
        }
        private IDiscountRepository _discountRepositorys;
        public IDiscountRepository DiscountRepository
        {
            get
            {
                if (_discountRepositorys == null)
                {
                    _discountRepositorys = new DiscountRepository(_context);
                }
                return _discountRepositorys;
            }
        }
        public AppDbContext AppDbContext => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }

}
