using Microsoft.AspNetCore.Mvc;
using WebMobilePhone_DataAccess.Infrastructures;
using X.PagedList;
using WebMobilePhone_Models.Models;
using WebMobilePhone_Website.Models;

namespace WebMobilePhone_Website.Controllers
{
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
            //---
            List<News> listRecord = new List<News>();
            listRecord = unitOfWork.NewsRepository.GetAll().OrderByDescending(anhxa => anhxa.ID).ToList();
            //---
            //truyen gia tri ra view co phan trang
            return View("Index", listRecord.ToPagedList(_CurrentPage, _RecordPerPage));
        }
        //chi tiet san pham
        public IActionResult Detail(int? id)
        {
            int intID = id ?? 0;
            News record = unitOfWork.NewsRepository.Find(intID);
            return View("Detail", record);
        }
    }
}
