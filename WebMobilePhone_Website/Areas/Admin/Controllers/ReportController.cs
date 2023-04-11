using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using WebMobilePhone_DataAccess.Infrastructures;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using WebMobilePhone_Models.Common;

namespace WebMobilePhone_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Master + "," + Roles.Admin)]
    public class ReportController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public ReportController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var nowDate = DateTime.Now;
            var fromDate = new DateTime(nowDate.Year, nowDate.Month, 1);
            var toDate = fromDate.AddMonths(+1).AddDays(-1);
            ViewBag.StartDate = fromDate.ToString("yyyy-MM-dd");
            ViewBag.EndDate = toDate.ToString("yyyy-MM-dd");
            DataTable dt = unitOfWork.OrdersRepository.DataTableCreatePrice(fromDate, toDate);
            if (dt is not null)
            { return View(dt); }
            DataTable dt2 = new DataTable();
            return View(dt2);
        }
        [HttpPost]
        public IActionResult Index(string startDate, string endDate)
        {
            var nowDate = DateTime.Now;
            var fromDate = new DateTime(nowDate.Year, nowDate.Month, 1);
            var toDate = fromDate.AddMonths(+1).AddDays(-1);
            if (!string.IsNullOrEmpty(startDate))
            {
                fromDate = Convert.ToDateTime(startDate.Trim());
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                toDate = Convert.ToDateTime(endDate.Trim());
            }
            ViewBag.StartDate = fromDate.ToString("yyyy-MM-dd");
            ViewBag.EndDate = toDate.ToString("yyyy-MM-dd");

            DataTable dt =  new DataTable(); 
            dt=unitOfWork.OrdersRepository.DataTableCreatePrice(fromDate, toDate);
           
            if (dt is not null  )
            { return View("Index", dt); }
            DataTable dt2 = new DataTable();
            return View("Index",dt2);

        }
        [HttpGet]
        public FileContentResult ExportToExcel(string startDate, string endDate)
        {
            var nowDate = DateTime.Now;
            var fromDate = new DateTime(nowDate.Year, nowDate.Month, 1);
            var toDate = fromDate.AddMonths(+1).AddDays(-1);
            if (!string.IsNullOrEmpty(startDate))
            {
                fromDate = Convert.ToDateTime(startDate.Trim());
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                toDate = Convert.ToDateTime(endDate.Trim());
            }
            ViewBag.StartDate = fromDate.ToString("yyyy-MM-dd");
            ViewBag.EndDate = toDate.ToString("yyyy-MM-dd");
            //DateTime fromDate = DateTime.Parse(startDate);
            //DateTime toDate = DateTime.Parse(endDate);

            string strTemplateFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/baocao.xlsx");
            XLWorkbook wb = new XLWorkbook(strTemplateFile);
            IXLWorksheet ws = wb.Worksheet("Sheet1");
            int startRow = 7;
            int iCount = 1;
            int iCount2 = 1;
            int iCount3 = 1;

            //tao data
            DataTable dt = new DataTable(); 
            DataTable dt2 = new DataTable(); 
            DataTable dt3 = new DataTable();

            dt = unitOfWork.OrdersRepository.DataTableCreatePrice(fromDate, toDate);
            dt2 = unitOfWork.OrdersRepository.DataTableSelectTop2(fromDate, toDate);
            dt3 = unitOfWork.OrdersRepository.DataTableSelectTop1ASC(fromDate, toDate);
            //doanh số

            //top san phẩm bán chạy

            //top san phẩm bán được ít nhất 

            ws.Cell("D4").Value = "Từ ngày " + fromDate.ToString("dd/MM/yyyy") + " đến ngày " + toDate.ToString("dd/MM/yyyy");
            if (dt is not null)
            {
                
                foreach (DataRow item in dt.Rows)
                {
                    ws.Cell("A" + (startRow + iCount)).Value = iCount;
                    ws.Cell("B" + (startRow + iCount)).Value = (XLCellValue)item["Create"].ToString();
                    ws.Cell("C" + (startRow + iCount)).Value = (XLCellValue)item["Price"].ToString();
                    if (iCount < dt.Rows.Count)
                    {
                        ws.Row(startRow + iCount).InsertRowsBelow(1);
                        iCount++;
                    }
                }
               
               
                foreach (DataRow item in dt2.Rows)
                {
                    ws.Cell("D" + (startRow + iCount2)).Value = (XLCellValue)item["Name"].ToString();
                    ws.Cell("E" + (startRow + iCount2)).Value = (XLCellValue)item["Price"].ToString(); ;
                    ws.Cell("F" + (startRow + iCount2)).Value = (XLCellValue)item["Discount"].ToString(); ;
                    ws.Cell("G" + (startRow + iCount2)).Value = (XLCellValue)item["soluongban"].ToString(); ;
                    if (iCount2 < dt2.Rows.Count)
                    {
                        ws.Row(startRow + iCount2).InsertRowsBelow(1);
                        iCount2++;
                    }
                }
                
                
                foreach (DataRow item in dt3.Rows)
                {
                    ws.Cell("H" + (startRow + iCount3)).Value = (XLCellValue)item["Name"].ToString(); ;
                    ws.Cell("I" + (startRow + iCount3)).Value = (XLCellValue)item["Price"].ToString(); 
                    ws.Cell("J" + (startRow + iCount3)).Value = (XLCellValue)item["Discount"].ToString(); ;
                    ws.Cell("K" + (startRow + iCount3)).Value = (XLCellValue)item["soluongban"].ToString(); ;
                    if (iCount3 < dt3.Rows.Count)
                    {
                        ws.Row(startRow + iCount3).InsertRowsBelow(1);
                        iCount3++;
                    }
                }
                dt3.Clear();
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "baocao" + DateTime.Now.ToString("yyyy/MM/dd") + ".xlsx");
                }
            }
           
            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "baocao" + DateTime.Now.ToString("yyyy/MM/dd") + ".xlsx");
            }
        }

    }
}
