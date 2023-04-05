using Microsoft.AspNetCore.Mvc;
using WebMobilePhone_DataAccess.Infrastructures;
using X.PagedList;
using WebMobilePhone_Models.Models;
using WebMobilePhone_Website.Models;
namespace WebMobilePhone_Website.Controllers
{
    public class SearchController : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public double getMoney(Products products)
        {
            if (products.DiscountID == null)
            {

                return Convert.ToDouble((products.Price * 0) / 100);
            }
            else
            {
                Discount discount = unitOfWork.DiscountRepository.Find(products.DiscountID);
                if (discount is not null)
                {
                    if (discount.StartDate <= DateTime.Now && DateTime.Now <= discount.EndDate)
                    {
                        return Convert.ToDouble((products.Price * discount.PercentDiscount) / 100);

                    }
                }
                return Convert.ToDouble((products.Price * 0) / 100);

            }
        }
        public IActionResult SearchPrice(int? page)
        {
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //---
            double fromPrice = !String.IsNullOrEmpty(Request.Query["fromPrice"]) ? Convert.ToDouble(Request.Query["fromPrice"]) : 0;
            double toPrice = !String.IsNullOrEmpty(Request.Query["toPrice"]) ? Convert.ToDouble(Request.Query["toPrice"]) : 0;
            //return Content(toPrice.ToString());
            List<Products> listRecord = unitOfWork.ProductsRepository.GetAll().Where(tbl => (tbl.Price - getMoney(tbl)) >= fromPrice && (tbl.Price - getMoney(tbl)) <= toPrice).OrderByDescending(tbl => tbl.ID).ToList();
            return View("SearchPrice", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        public IActionResult SearchProducts(int? page)
        {
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //---
            string key = !String.IsNullOrEmpty(Request.Query["key"]) ? Request.Query["key"] : "";
            List<Products> listRecord = unitOfWork.ProductsRepository.GetAll().Where(tbl => tbl.Name.Contains(key)).ToList();
            return View("SearchProducts", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        public string AJax()
        {
            string key = !String.IsNullOrEmpty(Request.Query["key"]) ? Request.Query["key"] : "";
            List<Products> listRecord = unitOfWork.ProductsRepository.GetAll().Where(tbl => tbl.Name.Contains(key)).ToList();
            string str = "";
            foreach (var item in listRecord)
            {
                str = str + "<li><a href='/Products/Detail/" + item.ID + "'><img src='/Upload/Products/" + item.Photo + "'/> " + item.Name + "</a></li>";
            }
            return str;
        }
    }
}
