using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WebMobilePhone_DataAccess.Infrastructures;
using Microsoft.Extensions.Configuration;
using WebMobilePhone_Models.Models;
using X.PagedList;
using System.Net.Mail;
using System.Net;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace WebMobilePhone_Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        public readonly IUnitOfWork unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            _fromEmail = config["Email:FromEmail"].ToString();
            _fromEmailDisplayName = config["Email:FromEmailDisplayName"].ToString();
            _fromEmailPassword = config["Email:FromEmailPassword"].ToString();
            _stmpHost = config["Email:SMTPHost"].ToString();
            _stmpPost = config["Email:SMTPPost"].ToString();
            _enabledSsl = bool.Parse(config["Email:EnabledSSL"].ToString());
        }
        private readonly string _toEmail;
        private readonly string _subject;
        private readonly string _context;
        private readonly string _fromEmail;
        private readonly string _fromEmailDisplayName;
        private readonly string _fromEmailPassword;
        private readonly string _stmpHost;
        private readonly string _stmpPost;
        private readonly bool _enabledSsl;
       
        public IActionResult Index(int? page)
        {
            int currentPage = page ?? 1;
            int perPage = 3;
            List<Orders> list = unitOfWork.OrdersRepository.GetByOrderByDescending();

            return View("Index", list.ToPagedList(currentPage, perPage));
        }
        public IActionResult Detail(int? id)
        {
            int _id = id ?? 0;
            ViewBag.orderID = _id;
            List<OrderDetail> listRecord = unitOfWork.OrderDetailRepository.GetOrdersByOrderID(_id);

            return View("Detail", listRecord);
        }
        public void SendEmail(string toEmail, string subject, string content)
        {

            var fromMail = _fromEmail;
            var fromEmailDisplayName = _fromEmailDisplayName;
            var fromEmailPassword = _fromEmailPassword;
            var stmpHost = _stmpHost;
            var stmpPost = _stmpPost;
            var enabledSsl = _enabledSsl;
            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromMail, fromEmailDisplayName), new MailAddress(toEmail));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromMail, fromEmailPassword);
            client.Host = stmpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !String.IsNullOrEmpty(stmpPost) ? Convert.ToInt32(stmpPost) : 0;
            client.Send(message);
        }
        public IActionResult Delivery(int? id)
        {
            int _id = id ?? 0;
            Orders record = unitOfWork.OrdersRepository.Find(_id);  
            record.Status = 1;
            unitOfWork.SaveChanges();
            ////gửi mail cho khách

            //    CustomersRecord customer = db.Customers.Where(tbl => tbl.ID == record.CustomerID).FirstOrDefault();
            //    String content = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/NewOrder.html"));
            //    content = content.Replace("{{CustomerName}}", customer.Name);
            //    content = content.Replace("{{Phone}}", customer.Phone);
            //    content = content.Replace("{{Email}}", customer.Email);
            //    content = content.Replace("{{Address}}", customer.Address);
            //    content = content.Replace("{{Total}}", record.Price.ToString());

            //    SendEmail(customer.Email, "Đơn hàng từ VTMobile", content);


            return RedirectToAction("Index", "Orders");
        }

        public IActionResult SendMail(int? id)
        {
            int _id = id ?? 0;
            Orders record = unitOfWork.OrdersRepository.Find(_id);
            record.Status = 1;
            unitOfWork.SaveChanges();
            List<OrderDetail> listOrder = unitOfWork.OrderDetailRepository.GetOrdersByOrderID(record.ID);
            //gửi mail cho khách
            unitOfWork.UserRepository.Find(record.CustomerID);
            User customer = unitOfWork.UserRepository.Find(record.CustomerID);
            String content = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/NewOrder.html"));
            content = content.Replace("{{CustomerName}}", customer.UserName);
            content = content.Replace("{{Phone}}", customer.PhoneNumber);
            content = content.Replace("{{Email}}", customer.Email);
            content = content.Replace("{{Address}}", customer.Address);
            content = content.Replace("{{Total}}", record.Price.ToString());
            //content = content.Replace("{{listOrder}}", listOrder.ToString());
            SendEmail(customer.Email, "Đơn hàng từ VTMobile", content);



            return RedirectToAction("Index", "Orders");
        }

        public IActionResult Delete(int? id)
        {
            Orders record = unitOfWork.OrdersRepository.Find(id);
            if (record == null)
                return RedirectToAction("Index", "Orders");
            else
            {
                List<OrderDetail> listOderDetail = new List<OrderDetail>();
                List<OrderDetail> list = (List<OrderDetail>)unitOfWork.OrderDetailRepository.GetAll();
                foreach (var item in list)
                {
                    if (item.OrderID == record.ID)
                    {
                        listOderDetail.Add(item);
                        continue;
                    }
                }

                foreach (var item in listOderDetail)
                {
                    Products product = unitOfWork.ProductsRepository.Find(item.ProductID);
                    product.Amount = product.Amount + item.Quantity;

                }
                unitOfWork.OrdersRepository.Delete(record);
              
                int i = 0;
                int soluong = listOderDetail.Count;
                while (i < soluong)
                {
                    unitOfWork.OrderDetailRepository.Delete(listOderDetail[i]);
                    i++;
                }
                unitOfWork.SaveChanges();
                return RedirectToAction("Index", "Orders");
            }


            return RedirectToAction("Index", "Orders");
        }
    }
}
