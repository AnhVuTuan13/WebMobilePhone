using Microsoft.AspNetCore.Mvc;
using WebMobilePhone_DataAccess.Infrastructures;
using X.PagedList;
using WebMobilePhone_Models.Models;
using WebMobilePhone_Website.Models;
namespace WebMobilePhone_Website.Controllers
{
    public class ProductsController : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Category(int? id, int? page)
        {

            int categoryID = id ?? 0;
            ViewBag.intCategoryID = categoryID;
            int _currentPage = page ?? 1;
            //lấy tất cả bản ghi
            int sobanghitren1trang = 20;

            string _order = !string.IsNullOrEmpty(Request.Query["order"]) ? Request.Query["order"] : "";
            List<Products> listRecord = new List<Products>();
            switch (_order)
            {
                case "priceAsc":
                    listRecord = unitOfWork.ProductsRepository.GetByCategoriesId(categoryID).OrderBy(p => p.Price).ToList();
                    break;
                case "priceDesc":
                    listRecord = unitOfWork.ProductsRepository.GetByCategoriesId(categoryID).OrderByDescending(p => p.Price).ToList();
                    break;
                case "nameAsc":
                    listRecord = unitOfWork.ProductsRepository.GetByCategoriesId(categoryID).OrderBy(p => p.Name).ToList();
                    break;
                case "nameDesc":
                    listRecord = unitOfWork.ProductsRepository.GetByCategoriesId(categoryID).OrderByDescending(p => p.Name).ToList();
                    break;
                default:
                    listRecord = unitOfWork.ProductsRepository.GetByCategoriesId(categoryID).OrderByDescending(p => p.ID).ToList();
                    break;
            }
            return View("Category", listRecord.ToPagedList(_currentPage, sobanghitren1trang));
        }
        public IActionResult ProductsAll( int? page)
        {

            int _currentPage = page ?? 1;
            //lấy tất cả bản ghi
            int sobanghitren1trang = 20;

            string _order = !string.IsNullOrEmpty(Request.Query["order"]) ? Request.Query["order"] : "";
            List<Products> listRecord = new List<Products>();
            switch (_order)
            {
                case "priceAsc":
                    listRecord = unitOfWork.ProductsRepository.GetAll().OrderBy(p => p.Price).ToList();
                    break;
                case "priceDesc":
                    listRecord = unitOfWork.ProductsRepository.GetAll().OrderByDescending(p => p.Price).ToList();
                    break;
                case "nameAsc":
                    listRecord = unitOfWork.ProductsRepository.GetAll().OrderBy(p => p.Name).ToList();
                    break;
                case "nameDesc":
                    listRecord = unitOfWork.ProductsRepository.GetAll().OrderByDescending(p => p.Name).ToList();
                    break;
                default:
                    listRecord = unitOfWork.ProductsRepository.GetAll().OrderByDescending(p => p.ID).ToList();
                    break;
            }
            return View("ProductsAll", listRecord.ToPagedList(_currentPage, sobanghitren1trang));
        }
        //chi tiết sản phẩm
        public IActionResult Detail(int? id)
        {
            int _id = id ?? 0;
            Products record = unitOfWork.ProductsRepository.Find(_id);
            return View("Detail", record);
        }
        //đánh giá số sao
        public IActionResult Star(int? id)
        {
            int _id = id ?? 0;
            int intStar = !string.IsNullOrEmpty(Request.Query["star"]) ? Convert.ToInt32(Request.Query["star"]) : 0;
            Rating record = new Rating();
            record.ProductID = _id;
            record.Star = intStar;
            unitOfWork.RatingRepository.Add(record);
            unitOfWork.SaveChanges();
            return Redirect("/Products/Detail/" + _id);
        }

    }
}
