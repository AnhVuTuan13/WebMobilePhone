using Microsoft.AspNetCore.Mvc;
using WebMobilePhone_DataAccess.Data;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;

namespace WebMobilePhone_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(unitOfWork.CategoryRepository.GetAll());
        }
        public IActionResult Create()
        {
            Categories record = new Categories();
            return View(record);
        }
        [HttpPost]
        public IActionResult Create(Categories model)
        {

            if (ModelState.IsValid)
            {
                var record = unitOfWork.CategoryRepository.GetByName(model.Name);
               
                if (record != null)
                {
                    ViewBag.Failure = -1;
                    return View(model);
                }
                else if (model.Name == null)
                {
                    ViewBag.Failure = 0;
                    return View(model);
                }
                else
                {
                    ViewBag.Failure = 1;
                    Categories cate = new Categories();
                    cate.Name = model.Name;
                    unitOfWork.CategoryRepository.Add(cate);
                    unitOfWork.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Categories record = unitOfWork.CategoryRepository.Find(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult update(Categories model)
        {
            if (ModelState.IsValid)
            {
                var record = unitOfWork.CategoryRepository.GetByNameAndNotMapId(model.Name, model.Id);
                if (record != null)
                {
                    ViewBag.Failure = -1;
                    return View(model);
                }
                else if (model.Name == null)
                {
                    ViewBag.Failure = 0;
                    return View(model);
                }
                else
                {
                    ViewBag.Failure = 1;
                    unitOfWork.CategoryRepository.Update(model);
                    unitOfWork.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            List<Products> listProduct = unitOfWork.ProductsRepository.GetByCategoriesId(id);
            if (listProduct.Count == 0)
            {
                Categories record = unitOfWork.CategoryRepository.Find(id);
                unitOfWork.CategoryRepository.Delete(record);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
