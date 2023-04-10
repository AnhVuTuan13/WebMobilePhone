using Microsoft.AspNetCore.Mvc;
using PayPal.Core;
using WebMobilePhone_DataAccess.Infrastructures;
using WebMobilePhone_Models.Models;
using WebMobilePhone_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PayPal.v1.Payments;
using BraintreeHttp;
using Microsoft.AspNetCore.Authorization;
using WebMobilePhone_Models.Common;
using Microsoft.Build.Evaluation;

namespace WebMobilePhone_Website.Controllers
{
    public class CartController : Controller
    {
        private double TyGiaUSD = 23000;
        public readonly IUnitOfWork unitOfWork;
        private readonly string _clientId;
        private readonly string _secretkey;
        private Cart cart;
        public CartController(IUnitOfWork unitOfWork, IConfiguration config, Cart cart)
        {
            this.unitOfWork = unitOfWork;
            this.cart = cart;
            _clientId = config["PayPalSetting:ClientID"];
            _secretkey = config["PayPalSetting:SecretKey"];
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
        public IActionResult Index()
        {
            //lấy sản phẩm trong giỏ hàng
            List<Items> _cart = cart.GetCart(HttpContext.Session);
            if (_cart != null)
            {
                ViewBag._cart = _cart;

                ViewBag._total = _cart.Sum(tbl => (tbl.ProductItem.Price - getMoney(tbl.ProductItem)) * tbl.Quantity);
            }
            return View();
        }
        //thêm sản phẩm vào cart
        public IActionResult Buy(int id)
        {


            cart.CartAdd(HttpContext.Session, id);
            if (Cart.ktra == true)
            {
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                ViewBag.hethang = "hiện tại sản phẩm đã hết";
                return RedirectToAction("Index", "Home");
            }


        }
        //xóa sản phẩm khỏi giỏ hàng
        public IActionResult Remove(int id)
        {
            cart.CartRemove(HttpContext.Session, id);
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Destroy()
        {
            cart.CartDestroy(HttpContext.Session);
            return RedirectToAction("Index", "Cart");
        }
        //cập nhật
        public IActionResult Update()
        {
            List<Items> _cart = cart.GetCart(HttpContext.Session);
            foreach (var item in _cart)
            {
                int quantity = Convert.ToInt32(Request.Form["product_" + item.ProductItem.ID]);



                cart.CartUpdate(HttpContext.Session, item.ProductItem.ID, quantity);
                ViewBag.soluong = Cart.soluong;

            }
            return RedirectToAction("Index", "Cart");
        }

        //thanh toan
        [Authorize(Roles = Roles.Master + "," + Roles.Admin + "," + Roles.User)]
        public IActionResult Checkout()
        {

            List<Items> _cart = cart.GetCart(HttpContext.Session);
            //lấy id của customer
            string customer_id = HttpContext.Session.GetString("customer_id");
            ViewBag.idkh = customer_id;
            //insert vào bảng order
            Orders recordOrder = new Orders();
            recordOrder.CustomerID = customer_id;
            recordOrder.Create = DateTime.Now;
            recordOrder.Payment = 0;

            recordOrder.Price = _cart.Sum(tbl => (double.Parse(((tbl.ProductItem.Price - getMoney(tbl.ProductItem)) * tbl.Quantity).ToString())));

            unitOfWork.OrdersRepository.Add(recordOrder);
            unitOfWork.SaveChanges();
            //lấy id vừa insert
            int order_id = recordOrder.ID;
            foreach (var item in _cart)
            {
                OrderDetail recordOrderDetail = new OrderDetail();
                recordOrderDetail.OrderID = order_id;
                recordOrderDetail.ProductID = item.ProductItem.ID;
                recordOrderDetail.Price = double.Parse((item.ProductItem.Price - getMoney(item.ProductItem)).ToString());
                recordOrderDetail.Quantity = item.Quantity;
                unitOfWork.OrderDetailRepository.Add(recordOrderDetail);
                unitOfWork.SaveChanges();

            }
            //xóa tất cả item trong cart
            cart.CartComplete(HttpContext.Session);

            HttpContext.Session.SetString("customer_id", customer_id);

            return Redirect("/Cart/DetailBill");
        }

        //checkOut Paypal
        [Authorize(Roles = Roles.Master + "," + Roles.Admin + "," + Roles.User)]

        public IActionResult CheckoutPaypal()
        {

            List<Items> _cart = cart.GetCart(HttpContext.Session);
            //lấy id của customer
            string customer_id = HttpContext.Session.GetString("customer_id");
            //insert vào bảng order
            Orders recordOrder = new Orders();
            recordOrder.CustomerID = customer_id;
            recordOrder.Create = DateTime.Now;
            recordOrder.Payment = 1;

            recordOrder.Price = _cart.Sum(tbl => (double.Parse(((tbl.ProductItem.Price - getMoney(tbl.ProductItem)) * tbl.Quantity).ToString())));

            unitOfWork.OrdersRepository.Add(recordOrder);
            //lấy id vừa insert
            int order_id = recordOrder.ID;
            foreach (var item in _cart)
            {
                OrderDetail recordOrderDetail = new OrderDetail();
                recordOrderDetail.OrderID = order_id;
                recordOrderDetail.ProductID = item.ProductItem.ID;
                recordOrderDetail.Price = double.Parse((item.ProductItem.Price - getMoney(item.ProductItem)).ToString());
                recordOrderDetail.Quantity = item.Quantity;
                unitOfWork.OrderDetailRepository.Add(recordOrderDetail);
                unitOfWork.SaveChanges();
            }


            //xóa tất cả item trong cart
            cart.CartDestroy(HttpContext.Session);
            HttpContext.Session.SetString("customer_id", customer_id);
            return Redirect("/Cart/DetailBill");

        }
        //thanh toán bằng paypal

        public async Task<IActionResult> PaypanlCheckoutAsync()
        {

            if (HttpContext.Session.GetString("email") == null)
            {
                return Redirect("/Account/Login");
            }
            else
            {
                var environment = new SandboxEnvironment(_clientId, _secretkey);
                var client = new PayPalHttpClient(environment);

                #region Create Paypal Order
                var itemList = new ItemList()
                {
                    Items = new List<Item>()
                };
                List<Items> _cart = cart.GetCart(HttpContext.Session);

                var total = Math.Round(_cart.Sum(tbl => tbl.ThanhTien) / TyGiaUSD, 2);

                foreach (var item in _cart)
                {
                    itemList.Items.Add(new Item()
                    {
                        Name = item.ProductItem.Name,
                        Currency = "USD",
                        Price = Math.Round((Convert.ToDouble(item.ProductItem.Price - getMoney(item.ProductItem))) / TyGiaUSD, 2).ToString(),
                        Quantity = item.Quantity.ToString(),
                        Sku = "sku",
                        Tax = "0"
                    });
                }
                #endregion

                var paypalOrderId = DateTime.Now.Ticks;
                var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
                var payment = new Payment()
                {
                    Intent = "sale",
                    Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = (total).ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = $"Invoice #{paypalOrderId}",
                        InvoiceNumber = paypalOrderId.ToString()
                    }
                },
                    RedirectUrls = new RedirectUrls()
                    {
                        CancelUrl = $"{hostname}/Cart/checkoutfail",
                        ReturnUrl = $"{hostname}/Cart/CheckoutPaypal"
                    },
                    Payer = new Payer()
                    {
                        PaymentMethod = "paypal"
                    }
                };

                PaymentCreateRequest request = new PaymentCreateRequest();
                request.RequestBody(payment);

                try
                {
                    var response = await client.Execute(request);
                    //var statusCode = response.StatusCode;
                    Payment result = response.Result<Payment>();

                    var links = result.Links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        LinkDescriptionObject lnk = links.Current;
                        if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.Href;
                        }
                    }

                    return Redirect(paypalRedirectUrl);
                }
                catch (HttpException httpException)
                {
                    var statusCode = httpException.StatusCode;
                    var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                    //Process when Checkout with Paypal fails
                    return Redirect("/Cart/checkoutfail");
                }
            }
        }

        public IActionResult checkoutfail()
        {
            return View();
        }
        public IActionResult DetailBill()
        {
            //lấy id của customer
            string customer_id = HttpContext.Session.GetString("customer_id");
            ViewBag.idkh = customer_id;

            List<Orders> list = unitOfWork.OrdersRepository.GetByOrderByCustomer(customer_id).Where(x => x.Status == 0).ToList();
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            foreach (var item in list)
            {
                List<OrderDetail> listAll = unitOfWork.OrderDetailRepository.GetAll().ToList();
                foreach (var item2 in listAll)
                {
                    if (item2.OrderID == item.ID)
                    {
                        listOrderDetail.Add(item2);
                    }
                }


            }

            return View("InformationBill", listOrderDetail);
        }

        public IActionResult HistoryBill()
        {
            //lấy id của customer
            string customer_id = HttpContext.Session.GetString("customer_id");
            ViewBag.idkh = customer_id;

            List<Orders> list = unitOfWork.OrdersRepository.GetByOrderByCustomer(customer_id).Where(x => x.Status == 1).ToList();

            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            foreach (var item in list)
            {
                List<OrderDetail> listAll = (List<OrderDetail>)unitOfWork.OrderDetailRepository.GetAll();
                foreach (var item2 in listAll)
                {
                    if (item2.OrderID == item.ID)
                    {
                        listOrderDetail.Add(item2);
                    }
                }
            }

            return View("HistoryBill", listOrderDetail);
        }
        public IActionResult deleteBill(int id)
        {
            string customer_id = HttpContext.Session.GetString("customer_id");
            ViewBag.idkh = customer_id;

            OrderDetail record = unitOfWork.OrderDetailRepository.Find(id);
            Products product = unitOfWork.ProductsRepository.Find(record.ProductID);
            product.Amount = product.Amount + record.Quantity;
            unitOfWork.OrderDetailRepository.Delete(record);
            Orders order2 = unitOfWork.OrdersRepository.Find(record.OrderID);
            order2.Price = order2.Price - record.Price;
            unitOfWork.SaveChanges();

            List<Orders> order1 = (List<Orders>)unitOfWork.OrdersRepository.GetAll();
            List<OrderDetail> od = (List<OrderDetail>)unitOfWork.OrderDetailRepository.GetAll();
            var orderdetail1 = from d in od select d.OrderID;
            foreach (var item in order1)
            {
                if (!(orderdetail1.ToList().Contains(item.ID)))
                {
                    unitOfWork.OrdersRepository.Delete(item);
                    unitOfWork.SaveChanges();
                }
            }

            //hiển thị lại toàn bộ đơn hàng
            List<Orders> list = unitOfWork.OrdersRepository.GetByOrderByCustomer(customer_id).Where(x => x.Status == 0).ToList(); ;
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            foreach (var item in list)
            {
                List<OrderDetail> listAll = (List<OrderDetail>)unitOfWork.OrderDetailRepository.GetAll();
                foreach (var item2 in listAll)
                {
                    if (item2.OrderID == item.ID)
                    {
                        listOrderDetail.Add(item2);
                    }
                }


            }
            return View("InformationBill", listOrderDetail);
        }

        public JsonResult GetList()
        {
            List<Items> _cart = cart.GetCart(HttpContext.Session);
            if (_cart != null)
            {
                ViewBag._cart = _cart;
                ViewBag._total = _cart.Sum(tbl => (tbl.ProductItem.Price - getMoney(tbl.ProductItem)) * tbl.Quantity);
            }
            return Json(_cart, new Newtonsoft.Json.JsonSerializerSettings());
        }

        public JsonResult UpdateAmount()
        {
            List<Items> _cart = cart.GetCart(HttpContext.Session);
            foreach (var item in _cart)
            {
                int quantity = Convert.ToInt32(Request.Form["product_" + item.ProductItem.ID]);
                cart.CartUpdate(HttpContext.Session, item.ProductItem.ID, quantity);
            }
            return Json(_cart, new Newtonsoft.Json.JsonSerializerSettings());
        }

    }
}

