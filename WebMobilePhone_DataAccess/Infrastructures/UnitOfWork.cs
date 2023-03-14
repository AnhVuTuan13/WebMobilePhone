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
