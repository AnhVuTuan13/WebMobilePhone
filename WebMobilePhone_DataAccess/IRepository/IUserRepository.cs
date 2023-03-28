using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public List<User> GetByOrderByDescending();
        public User GetByEmail(string email);
    }
}
