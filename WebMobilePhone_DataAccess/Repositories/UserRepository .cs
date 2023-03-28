using WebMobilePhone_DataAccess.Data;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_DataAccess.IRepository;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebMobilePhone_DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public User GetByEmail(string email)
        {
            return Context.Set<User>().Where(x => x.Email.Equals(email)).FirstOrDefault();
        }

        public List<User> GetByOrderByDescending()
        {
           return Context.Set<User>().OrderByDescending(anhxa => anhxa.Id).ToList();
        }
    }
}
