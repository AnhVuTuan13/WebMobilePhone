using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMobilePhone_DataAccess.IRepository
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
        public int GetStar(int productID, int intStar);
    }
}
