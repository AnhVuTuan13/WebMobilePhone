using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMobilePhone_Models.Common;

namespace WebMobilePhone_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Master + "," + Roles.Admin )]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
