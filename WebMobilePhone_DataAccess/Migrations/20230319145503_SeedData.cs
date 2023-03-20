using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMobilePhone_DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "399b34de-5b32-48b2-86b4-fb0881a2517c", "2bbb0fb6-4de5-467f-bdda-3d789fe78b59", "Admin", "ADMIN" },
                    { "58cd381e-8683-4b42-b7b6-70b6274bfa84", "b1fd2617-15cc-419e-a105-6cdd36e7c3ae", "Master", "MASTER" },
                    { "97ddd633-2a4d-42b3-8f82-a5fe1d94173a", "122779e0-e388-47df-aa50-fb5d00bc9f1b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avata", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "08bc2fc1-5387-4033-b7d3-8208d29746ff", 0, null, "1006d67b-620f-4d98-812a-77e61cd22709", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEAyWm0yTfmP2j8j7usAjALMMLHqmZ11mq0zlrWdtxpIUFfg/XlCRovGIDKsZeeYDYg==", null, false, "656cd126-70a0-4c2e-9586-4ee103a1b292", null, false, "user@localhost.com" },
                    { "9fa0160f-c2c6-4124-8221-4f465e979807", 0, null, "e5da0e8a-7f4a-40d1-abc4-9af57ecc891f", "Admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "BLOGOWNER@LOCALHOST.COM", "AQAAAAEAACcQAAAAECtt3QM5Z3vfsg7Vlyqvwe1I4o2i012YTADz3Mvew7n4Gmk5u351dymQbl/PAC46dg==", null, false, "06af3452-207e-48b2-b4c7-dcacfb4686e7", null, false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Iphone" },
                    { 2, "Samsung" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "97ddd633-2a4d-42b3-8f82-a5fe1d94173a", "08bc2fc1-5387-4033-b7d3-8208d29746ff" },
                    { "399b34de-5b32-48b2-86b4-fb0881a2517c", "9fa0160f-c2c6-4124-8221-4f465e979807" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Create", "CustomerID", "Payment", "Price", "Status" },
                values: new object[] { 1, new DateTime(2023, 3, 19, 21, 55, 3, 597, DateTimeKind.Local).AddTicks(3019), "08bc2fc1-5387-4033-b7d3-8208d29746ff", 0, 13000000.0, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Amount", "CategoryID", "Content", "Decription", "Discount", "Hot", "Name", "Photo", "Price" },
                values: new object[] { 1, 10, 1, " ", " ", 5.0, 1, "Iphone 13 Hồng", "133237103276543983_IP13Hong.jpg", 15000000.0 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "ID", "OrderID", "Price", "ProductID", "Quantity" },
                values: new object[] { 1, 1, 13000000.0, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58cd381e-8683-4b42-b7b6-70b6274bfa84");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "97ddd633-2a4d-42b3-8f82-a5fe1d94173a", "08bc2fc1-5387-4033-b7d3-8208d29746ff" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "399b34de-5b32-48b2-86b4-fb0881a2517c", "9fa0160f-c2c6-4124-8221-4f465e979807" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399b34de-5b32-48b2-86b4-fb0881a2517c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ddd633-2a4d-42b3-8f82-a5fe1d94173a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fa0160f-c2c6-4124-8221-4f465e979807");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08bc2fc1-5387-4033-b7d3-8208d29746ff");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
