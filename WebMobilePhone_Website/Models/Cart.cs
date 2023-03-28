using WebMobilePhone_DataAccess.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebMobilePhone_Models.Models;
using WebMobilePhone_Website.Models;
//muon su dung thu vien jSon thi phai them dong duoi
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using Microsoft.Build.Evaluation;

namespace WebMobilePhone_Website.Models
{
    public class Cart
    {
        public readonly IUnitOfWork unitOfWork;
        public Cart(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //------        
        public static T GetObjectFromJson<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public Products GetProducts(int id)
        {
            return unitOfWork.ProductsRepository.Find(id);
        }
        //------
        //lay gio hang dang ton tai
        public List<Items> GetCart(ISession session)
        {
            //JsonConvert.DeserializeObject<T>("cart")
            List<Items> cart = Cart.GetObjectFromJson<List<Items>>(session, "cart");
            return cart;
        }
        //add item to cart
        public static bool ktra = true;
        public double GetMoney(Products ProductItem)
        {
            if (ProductItem.DiscountID == null)
            {
                return Convert.ToDouble(ProductItem.Price - (ProductItem.Price * 0) / 100);
            }
            else
            {
                Discount discount = unitOfWork.DiscountRepository.Find(ProductItem.DiscountID);
               
                if (discount.StartDate <= DateTime.Now && DateTime.Now <= discount.EndDate)
                {
                    return Convert.ToDouble( ProductItem.Price - (ProductItem.Price * discount.PercentDiscount) / 100);
                }
                return Convert.ToDouble( ProductItem.Price - (ProductItem.Price * 0) / 100);


            }
        }
        public void CartAdd(ISession session, int id)
        {


            Products record = GetProducts(id);

            if (record.Amount == 0)
            {
                ktra = false;
            }
            else
            {

                ktra = true;
                if (Cart.GetObjectFromJson<List<Items>>(session, "cart") == null)
                {
                    List<Items> cart = new List<Items>();
                    Products item = GetProducts(id);
                    cart.Add(new Items() { ProductItem = item, Quantity = 1,GiiaBan=GetMoney(item)  });
                    item.Amount = item.Amount - 1;
                    unitOfWork.SaveChanges();

                    session.SetString("cart", JsonConvert.SerializeObject(cart));
                }
                else
                {
                    List<Items> cart = Cart.GetObjectFromJson<List<Items>>(session, "cart");

                    int index = isExist(session, id);
                    if (index != -1)
                    {
                        cart[index].Quantity++;
                        //cart[index].ProductItem.Amount = cart[index].ProductItem.Amount - (cart[index].Quantity - 1);
                        Products product = unitOfWork.ProductsRepository.Find(cart[index].ProductItem.ID);
                        product.Amount = product.Amount - (cart[index].Quantity - 1);
                        unitOfWork.SaveChanges();

                    }
                    else
                    {
                        Products item = GetProducts(id);

                        cart.Add(new Items(){ ProductItem = item, Quantity = 1, GiiaBan = GetMoney(item) });
                        item.Amount = item.Amount - 1;
                        unitOfWork.SaveChanges();
                    }
                    session.SetString("cart", JsonConvert.SerializeObject(cart));
                }

            }
        }
        //remove item in cart
        public void CartRemove(ISession session, int id)
        {
            List<Items> cart = Cart.GetObjectFromJson<List<Items>>(session, "cart");
            int index = isExist(session, id);
            Products product = unitOfWork.ProductsRepository.Find(cart[index].ProductItem.ID);

            product.Amount = product.Amount + cart[index].Quantity;
            unitOfWork.SaveChanges();
            cart.RemoveAt(index);
            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        public void CartComplete(ISession session)
        {
            List<Items> cart = new List<Items>();
            //List<Items> cart1 = Cart.GetObjectFromJson<List<Items>>(session, "cart");

            //foreach (var item in cart1)
            //{
            //    ProductsRecord product = db.Products.Where(tbl => tbl.ID == item.ProductItem.ID).FirstOrDefault();
            //    product.Amount = product.Amount - item.Quantity;
            //    db.SaveChanges();
            //}
            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        //remove all item in cart
        public void CartDestroy(ISession session)
        {
            List<Items> cart = new List<Items>();
            List<Items> cart1 = Cart.GetObjectFromJson<List<Items>>(session, "cart");

            foreach (var item in cart1)
            {
                Products product = unitOfWork.ProductsRepository.Find(item.ProductItem.ID);

                product.Amount = product.Amount + item.Quantity;
                unitOfWork.SaveChanges();
            }
            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        public static int soluong;
        public void CartUpdate(ISession session, int id, int quantity)
        {
            List<Items> cart = Cart.GetObjectFromJson<List<Items>>(session, "cart");
            //---
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductItem.ID == id)
                {
                    int dochenh = quantity - cart[i].Quantity;
                    Products product = unitOfWork.ProductsRepository.Find(cart[i].ProductItem.ID);
                    if (dochenh < product.Amount)
                    {
                        product.Amount = product.Amount - dochenh;
                        unitOfWork.SaveChanges();
                        cart[i].Quantity = quantity;
                    }
                    else
                    {
                        soluong = product.Amount - dochenh;
                        cart[i].Quantity = cart[i].Quantity;
                    }


                }
            }
            //---
            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        private int isExist(ISession session, int id)
        {
            List<Items> cart = Cart.GetObjectFromJson<List<Items>>(session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductItem.ID == id)
                {

                    return i;
                }
            }
            return -1;
        }
    }
}
