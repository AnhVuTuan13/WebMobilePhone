using Microsoft.AspNetCore.Mvc;
using WebMobilePhone_DataAccess.Data;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;

namespace WebMobilePhone_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public DiscountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(unitOfWork.DiscountRepository.GetAll());
        }
        public IActionResult Create()
        {
            Discount record = new Discount();
            return View(record);
        }
        [HttpPost]
        public IActionResult Create(Discount model)
        {
            ViewBag.PercentDiscount = "";
            ViewBag.Date = "";
            if (ModelState.IsValid)
            {
                if (model.StartDate >= model.EndDate)
                {
                    ViewBag.Date = "StartDate < EndDate";
                    return View(model);
                }
                unitOfWork.DiscountRepository.Add(model);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            if (model.PercentDiscount == null)
                ViewBag.PercentDiscount = "PercentDiscount is not null";
            return View(model);
        }
        public IActionResult Update(int id)
        {
            Discount record = unitOfWork.DiscountRepository.Find(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult update(Discount model)
        {
            ViewBag.PercentDiscount = "";
            ViewBag.Date = "";
            if (ModelState.IsValid)
            {
                if (model.StartDate >= model.EndDate)
                {
                    ViewBag.Date = "StartDate < EndDate";
                    return View(model);
                }
                unitOfWork.DiscountRepository.Update(model);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            if (model.PercentDiscount == null)
                ViewBag.PercentDiscount = "PercentDiscount is not null";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            List<Products> listProduct = unitOfWork.ProductsRepository.GetByDiscountId(id);
            if (listProduct.Count == 0)
            {
                Discount record = unitOfWork.DiscountRepository.Find(id);
                unitOfWork.DiscountRepository.Delete(record);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (Products product in listProduct)
                {
                    product.DiscountID = null;
                }
                unitOfWork.SaveChanges();
                Discount record = unitOfWork.DiscountRepository.Find(id);
                unitOfWork.DiscountRepository.Delete(record);
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult SetUpDiscount()
        {
            List<Products> listProduct = (List<Products>)unitOfWork.ProductsRepository.GetAll();
            return View(listProduct);
        }
        [HttpPost]
        public IActionResult ChangeDiscount(string discountID,  string[] products)
        {
            var discount = int.Parse(discountID);
            foreach(var it in products)
            {
                Products product = unitOfWork.ProductsRepository.Find(int.Parse(it));
                product.DiscountID = discount;
            }
            unitOfWork.SaveChanges();
            return Json(new { success = true });
        }
    }
}

