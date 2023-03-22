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
using Microsoft.AspNetCore.Identity;

namespace WebMobilePhone_DataAccess.Repositories
{
    public class UserRoleRepository : BaseRepository<IdentityUserRole<string>>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }

        public IdentityUserRole<string> GetRoleByUserID(string id)
        {
            return Context.Set<IdentityUserRole<string>>().Where(x=>x.UserId.Equals(id)).FirstOrDefault(); 
        }
    }
}
