using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.Infrastructures
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Find a object by ID
        /// </summary>
        /// <param name="keyValues"> is Id</param>
        /// <returns> A Entity</returns>
        TEntity Find(params object[] keyValues);
        /// <summary>
        ///  Add a Entity in Table
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// Edit Entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity"> is a entity</param>
        void Delete(TEntity entity);
        /// <summary>
        /// remove Entity by Id
        /// </summary>
        /// <param name="id">Id of entity</param>
        void Delete(int id);
        /// <summary>
        /// Get All Entity In table
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

    }
}
