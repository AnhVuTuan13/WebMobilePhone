using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMobilePhone_Models.Models;

namespace WebMobilePhone_DataAccess.Configurations
{
    public static class ApplicationInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id=1, Name= "Iphone"},
                new Categories { Id=2 , Name="Samsung"}
                );
            modelBuilder.Entity<Products>().HasData(
                new Products { ID= 1, Name="Iphone 13 Hồng", CategoryID=1, Decription=" ", Content= " ", Hot=1, Photo = "133237103276543983_IP13Hong.jpg", Price=13000000, Discount=5, Amount=10}
                );
           
            modelBuilder.Entity<Orders>().HasData(
                new Orders { ID=1, CustomerID= "08bc2fc1-5387-4033-b7d3-8208d29746ff", Create= DateTime.Now, Price=13000000 , Status=1, Payment=0 }
               );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { ID = 1, OrderID = 1, ProductID = 1, Quantity = 1, Price = 13000000 }
               );
        }
    }
}
