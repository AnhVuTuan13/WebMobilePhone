using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebMobilePhone_DataAccess.IRepository
{
    public interface IUserRoleRepository : IBaseRepository<IdentityUserRole<string>>
    {
        public IdentityUserRole<string> GetRoleByUserID(string id);
    }
}
