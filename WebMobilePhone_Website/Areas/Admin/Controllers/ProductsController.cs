using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Common;
using WebMobilePhone_Models.Models;
using X.PagedList;

namespace WebMobilePhone_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Master + "," + Roles.Admin)]
    public class ProductsController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? page)
        {
            int currentPage = page ?? 1;
            int recordPerpage = 7;
            List<Products> list = unitOfWork.ProductsRepository.GetByOrderByDescending();
            return View("Index", list.ToPagedList(currentPage, recordPerpage));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Price = fc["Price"].ToString().Trim();
            string _Amount = fc["Amount"].ToString().Trim();
            string _CategoryID = fc["CategoryID"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
           
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;

            if (fc["Name"].ToString() == "")
            {
                ViewBag.Failure = -1;
                return View();
            }
            else if (fc["Price"].ToString() == "")
            {
                ViewBag.Failure = -2;
                return View();
            }
            else if (fc["Amount"].ToString() == "")
            {
                ViewBag.Failure = -3;
                return View();
            }
            else
            {
                var product = unitOfWork.ProductsRepository.GetByName(_Name);
                if (product != null)
                {
                    product.Amount += Convert.ToInt32(_Amount);
                }
                else
                {

                    //---
                    //lay ban ghi tuong ung voi id truyen vao
                    var record = new Products();
                    //update ban ghi
                    record.Name = _Name;
                    record.Price = Convert.ToDouble(_Price);
                    record.CategoryID = Convert.ToInt32(_CategoryID);
                    record.Amount = Convert.ToInt32(_Amount);
                    record.Decription = _Description;
                    record.Content = _Content;
                    record.Hot = _Hot;
                    //---
                    //lay thong tin o the file type="file"
                    string _FileName = "";
                    try
                    {
                        _FileName = Request.Form.Files[0].FileName;
                    }
                    catch {; }
                    if (!String.IsNullOrEmpty(_FileName))
                    {
                        //upload anh moi
                        //string _FileName = _file.FileName;
                        //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
                        var timestamp = DateTime.Now.ToFileTime();
                        _FileName = timestamp + "_" + _FileName;
                        //lay duong dan cua file
                        string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/Products", _FileName);
                        //upload file
                        using (var stream = new FileStream(_Path, FileMode.Create))
                        {
                            Request.Form.Files[0].CopyTo(stream);
                        }
                        //update gia tri vao cot Photo trong csdl
                        record.Photo = _FileName;
                    }
                    //---
                    //them ban ghi vao csdl
                    unitOfWork.ProductsRepository.Add(record);
                    //cap nhat ban ghi
                    unitOfWork.SaveChanges();
                    //---

                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            /*
             int? id: neu id co giatri thi id=giatri, neu id khong co giatri truyen vao thi 
                id = null
             */
            int _id = id ?? 0;
            //lay mot ban ghi
            Products record = unitOfWork.ProductsRepository.Find(_id);
            //goi view, truyen du lieu ra view
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(IFormCollection fc, int? id)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Price = fc["Price"].ToString().Trim();
            string _Amount = fc["Amount"].ToString().Trim();
            string _CategoryID = fc["CategoryID"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
            string _Discount = fc["Discount"].ToString().Trim();
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;

            //---
            //lay ban ghi tuong ung voi id truyen vao
            if (fc["Name"].ToString() == "")
            {
                ViewBag.Failure = -1;
                var record = new Products();
                record.Price = Convert.ToDouble(_Price);
                record.Amount = Convert.ToInt32(_Amount);
               
                record.CategoryID = Convert.ToInt32(_CategoryID);
                record.Decription = _Description;
                record.Content = _Content;
                record.Hot = _Hot;
                return View(record);
            }
            else if (fc["Price"].ToString() == "")
            {
                ViewBag.Failure = -2;
                var record = new Products();
                record.Name = _Name;

                record.Amount = Convert.ToInt32(_Amount);
               
                record.CategoryID = Convert.ToInt32(_CategoryID);
                record.Decription = _Description;
                record.Content = _Content;
                record.Hot = _Hot;
                return View(record);
            }
            else if (fc["Amount"].ToString() == "")
            {
                ViewBag.Failure = -3;
                var record = new Products();
                record.Name = _Name;
                record.Price = Convert.ToDouble(_Price);

               
                record.CategoryID = Convert.ToInt32(_CategoryID);
                record.Decription = _Description;
                record.Content = _Content;
                record.Hot = _Hot;
                return View(record);
            }
            else
            {


                var record = unitOfWork.ProductsRepository.Find(id);
                //update ban ghi
                record.Name = _Name;
                record.Price = Convert.ToDouble(_Price);
                record.Amount = Convert.ToInt32(_Amount);
              
                record.CategoryID = Convert.ToInt32(_CategoryID);
                record.Decription = _Description;
                record.Content = _Content;
                record.Hot = _Hot;
                //---
                //lay thong tin o the file type="file"
                string _FileName = "";
                try
                {
                    _FileName = Request.Form.Files[0].FileName;
                }
                catch {; }
                if (!String.IsNullOrEmpty(_FileName))
                {
                    //xoa anh cu
                    if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo)))
                    {
                        //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
                        //xoa anh
                        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo));
                    }
                    //upload anh moi
                    //string _FileName = _file.FileName;
                    //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
                    var timestamp = DateTime.Now.ToFileTime();
                    _FileName = timestamp + "_" + _FileName;
                    //lay duong dan cua file
                    string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", _FileName);
                    //upload file
                    using (var stream = new FileStream(_Path, FileMode.Create))
                    {
                        Request.Form.Files[0].CopyTo(stream);
                    }
                    //update gia tri vao cot Photo trong csdl
                    record.Photo = _FileName;
                }
                //---
                //cap nhat ban ghi
                unitOfWork.SaveChanges();
            }
            //---
            return Redirect("/Admin/Products");
        }
        public IActionResult Delete(int? id)
        {
            //lay ban ghi tuong ung voi id truyen vao
            var record = unitOfWork.ProductsRepository.Find(id);
            //xoa anh cu
            if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo)))
            {
                //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
                //xoa anh
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Photo));
            }
            //xoa ban ghi
            unitOfWork.ProductsRepository.Delete(record);
            //cap nhat csdl
            unitOfWork.SaveChanges();
            return Redirect("/Admin/Products");
        }
        [HttpGet]
        public IActionResult UpdateAmount(int? id)
        {
            int _id = id ?? 0;
            //lay mot ban ghi
            Products record = unitOfWork.ProductsRepository.Find(_id);
            //goi view, truyen du lieu ra view
            return View(record);
        }
        [HttpPost]
        public IActionResult UpdateAmount(int? id, IFormCollection fc)
        {
            string _Amount = fc["Amount"].ToString().Trim();
            var record = unitOfWork.ProductsRepository.Find(id);
            record.Amount = record.Amount + Convert.ToInt32(_Amount);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}

