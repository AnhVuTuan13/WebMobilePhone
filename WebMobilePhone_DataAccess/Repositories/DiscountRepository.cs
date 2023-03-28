using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMobilePhone_DataAccess.Data;

namespace WebMobilePhone_DataAccess.IRepository
{


    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext context) : base(context)
        {
        }

    }
}
