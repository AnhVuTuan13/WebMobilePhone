using Microsoft.EntityFrameworkCore;
using WebMobilePhone_DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMobilePhone_DataAccess.Data;

namespace WebMobilePhone_DataAccess.Infrastructures
{

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;
        private readonly DbSet<TEntity> DbSet;
        public BaseRepository(AppDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
                throw new ArgumentException($" Id ={id}  not exist in the {typeof(TEntity).Name} table");
            DbSet.Remove(entity);
        }

        public TEntity Find(params object[] keyValues)
        {
            var entity = DbSet.Find(keyValues);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
