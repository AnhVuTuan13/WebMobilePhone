using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Common;
using WebMobilePhone_Models.Models;
using X.PagedList;
using BC = BCrypt.Net.BCrypt;
namespace WebMobilePhone_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class UserController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
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
            int _RecordPerPage = 4;
            //lay tat ca cac ban ghi trong bang Users
            //(anhxa=>anhxa.ID) -> sap xep cot ID giam dan (tu gia tri cao nhat den thap nhat)
            List<User> listRecord = unitOfWork.UserRepository.GetByOrderByDescending();
            //truyen gia tri ra view co phan trang
            return View("Index", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        //mac dinh trang thai cua trang la GET -> khong can dinh nghia trang thai trang
        //bang lenh [HttpGet]
        public IActionResult Update(string? id)
        {
            /*
             int? id: neu id co giatri thi id=giatri, neu id khong co giatri truyen vao thi 
                id = null
             */
            string _id = id ?? new Guid().ToString();
            //lay mot ban ghi
            User record = unitOfWork.UserRepository.Find(_id);
            //goi view, truyen du lieu ra view
            return View("CreateUpdate", record);
        }
        //do khi an nut submit thi trang o trang thai POST-> phai khai bao [HttpPost]
        [HttpPost]
        public IActionResult Update(IFormCollection fc, string? id)
        {
            string _id = id ?? new Guid().ToString();
            //su dung Request.Form["email"] de lay gia tri cua the form
            //Trim(): cat khoang trang ben trai, ben phai cua gia tri
            string _UserName = fc["UserName"].ToString().Trim();
            //co the dung doi tuong fc de lay gia tri cua the form
            string _Password = fc["password"].ToString().Trim();
            //lay mot ban ghi tuong ung voi id
            User record = unitOfWork.UserRepository.Find(_id);
            record.UserName = _UserName;
            //neu password khong rong thi update password
            /*
             !String.IsNullOrEmpty(_Password) <=> String.IsNullOrEmpty(_Password) == false
             String.IsNullOrEmpty(_Password) <=> String.IsNullOrEmpty(_Password) == true
             */
            if (!String.IsNullOrEmpty(_Password))
            {
                //ma hoa password
                _Password = BC.HashPassword(_Password);
                record.PasswordHash = _Password;
            }
            string _FileName = "";
            try
            {
                _FileName = Request.Form.Files[0].FileName;
            }
            catch {; }
            if (!String.IsNullOrEmpty(_FileName))
            {
                //xoa anh cu
                if (record.Avata != null && System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Avata", record.Avata)))
                {
                    //Path.Combine -> ghep cac tham so ben trong no thanh mot chuoi
                    //xoa anh
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Products", record.Avata));
                }
                //upload anh moi
                //string _FileName = _file.FileName;
                //lay thoi gian gan vao ten file -> tranh cac file trung ten se upload de nhau
                var timestamp = DateTime.Now.ToFileTime();
                _FileName = timestamp + "_" + _FileName;
                //lay duong dan cua file
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/Avata", _FileName);
                //upload file
                using (var stream = new FileStream(_Path, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(stream);
                }
                //update gia tri vao cot Photo trong csdl
                record.Avata = _FileName;
            }

            //cap nhat lai table
            unitOfWork.SaveChanges();
            //di chuyen den url
            return Redirect("/Admin/User");
        }
        //Create
        public IActionResult Create()
        {
            return View("CreateUpdate");
        }
        //khi an nut submit -> trang thai trang se la POST
        [HttpPost]
        public IActionResult Create(IFormCollection fc)
        {
            string _UserName = fc["UserName"].ToString().Trim();
            string _Email = fc["email"].ToString().Trim();
            string _Password = fc["password"].ToString().Trim();
            string _Address = fc["Address"].ToString().Trim();
            string _PhoneNumber = fc["PhoneNumber"].ToString().Trim();
            bool checkMessage = false;

            if ("".Equals(_UserName))
            {
                ViewBag.UserName = "UserName Not Emty !";
                checkMessage= true;
            }
            if ("".Equals(_Email))
            {
                ViewBag.Email = "Email Not Emty !";
                checkMessage = true;
            }
            if ("".Equals(_Password))
            {
                ViewBag.Password = "Password Not Emty !";
                checkMessage = true;
            }
            if ("".Equals(_Address))
            {
                ViewBag.Address = "Address Not Emty !";
                checkMessage = true;
            }
            if ("".Equals(_PhoneNumber))
            {
                ViewBag.PhoneNumber = "PhoneNumber Not Emty !";
                checkMessage = true;
            }

            if(checkMessage)
                return View("CreateUpdate");


            //ma hoa password
            _Password = BC.HashPassword(_Password);
            //---
            User record = new User();
            record.UserName = _UserName;
            record.Email = _Email;
            record.PasswordHash = _Password;
            record.Address = _Address; 
            record.PhoneNumber = _PhoneNumber;
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
                string _Path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Upload/Avata", _FileName);
                //upload file
                using (var stream = new FileStream(_Path, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(stream);
                }
                //update gia tri vao cot Photo trong csdl
                record.Avata = _FileName;
            }
            string userid = record.Id;
            //them ban ghi vao table
            unitOfWork.UserRepository.Add(record);
            //cap nhat lai cac ban ghi
            // unitOfWork.SaveChanges();
            unitOfWork.SaveChanges();
            //toa ban ghi role
            IdentityUserRole<string> role = new IdentityUserRole<string>();
            role.UserId = userid;
            role.RoleId = "97ddd633-2a4d-42b3-8f82-a5fe1d94173a";
            unitOfWork.UserRoleRepository.Add(role);
            unitOfWork.SaveChanges();
            //---
            return Redirect("/Admin/User");
        }
        //xoa ban ghi
        public IActionResult Delete(string? id)
        {
            /*
             int? id: neu id co giatri thi id=giatri, neu id khong co giatri truyen vao thi 
                id = null
             */
            string _id = id ?? new Guid().ToString();
            //lay mot ban ghi
            User record = unitOfWork.UserRepository.Find(_id);
            //xoa ban ghi khoi csdl
            unitOfWork.UserRepository.Delete(record);

            IdentityUserRole<string> role = unitOfWork.UserRoleRepository.GetRoleByUserID(_id);
            if (role != null)
            {
                unitOfWork.UserRoleRepository.Delete(role);
            }

            //cap nhat lai cac ban ghi
            unitOfWork.SaveChanges();
            //goi view, truyen du lieu ra view
            return Redirect("/Admin/User");
        }
    }
}
