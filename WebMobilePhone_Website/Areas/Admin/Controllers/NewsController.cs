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
    public class NewsController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public NewsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index(int? page)
        {
            //lay trang hien tai
            //page ?? 1
            //neu page khac null thi _CurrentPage = page
            //neu page =  null thi _CurrentPage = 1
            int _CurrentPage = page ?? 1;
            //quy dinh so ban ghi tren mot trang
            int _RecordPerPage = 20;
            //lay tat ca cac ban ghi trong bang Users
            //(anhxa=>anhxa.ID) -> sap xep cot ID giam dan (tu gia tri cao nhat den thap nhat)
            List<News> listRecord = unitOfWork.NewsRepository.GetByOrderByDescending();
            //truyen gia tri ra view co phan trang
            return View("Index", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        //mac dinh trang thai cua trang la GET -> khong can dinh nghia trang thai trang
        //bang lenh [HttpGet]
        public IActionResult Update(int? id)
        {
            /*
             int? id: neu id co giatri thi id=giatri, neu id khong co giatri truyen vao thi 
                id = null
             */
            int _id = id ?? 0;
            //lay mot ban ghi
            News record = unitOfWork.NewsRepository.Find(_id);
            //goi view, truyen du lieu ra view
            return View("CreateUpdate", record);
        }
        [HttpPost]
        public IActionResult Update(IFormCollection fc, int? id)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;
            //---
            //lay ban ghi tuong ung voi id truyen vao
            var record = unitOfWork.NewsRepository.Find(id);
            //update ban ghi
            record.Name = _Name;
            record.Description = _Description;
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
                if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo)))
                {
                    //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
                    //xoa anh
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo));
                }
                //upload anh moi
                //string _FileName = _file.FileName;
                //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
                var timestamp = DateTime.Now.ToFileTime();
                _FileName = timestamp + "_" + _FileName;
                //lay duong dan cua file
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/News", _FileName);
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
            //---
            return Redirect("/Admin/News");
        }
        //create
        public IActionResult Create()
        {
            return View("CreateUpdate");
        }
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            string _Name = fc["Name"].ToString().Trim();
            string _Description = fc["Description"].ToString().Trim();
            string _Content = fc["Content"].ToString().Trim();
            int _Hot = fc["Hot"] != "" && fc["Hot"] == "on" ? 1 : 0;
            //---
            //lay ban ghi tuong ung voi id truyen vao
            var record = new News();
            //update ban ghi
            record.Name = _Name;
            record.Description = _Description;
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
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/News", _FileName);
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
            unitOfWork.NewsRepository.Add(record);
            //cap nhat ban ghi
             unitOfWork.SaveChanges();
            //---
            return Redirect("/Admin/News");
        }
        //xoa ban ghi
        public IActionResult Delete(int? id)
        {
            //lay ban ghi tuong ung voi id truyen vao
            var record = unitOfWork.NewsRepository.Find(id);
            //xoa anh cu
            if (record.Photo != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo)))
            {
                //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
                //xoa anh
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "News", record.Photo));
            }
            //xoa ban ghi
            unitOfWork.NewsRepository.Delete(record);
            //cap nhat csdl
            unitOfWork.SaveChanges();
            return Redirect("/Admin/News");
        }
    }
}
