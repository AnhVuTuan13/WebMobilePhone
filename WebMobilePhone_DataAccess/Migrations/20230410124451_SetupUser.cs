using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMobilePhone_DataAccess.Migrations
{
    public partial class SetupUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399b34de-5b32-48b2-86b4-fb0881a2517c",
                column: "ConcurrencyStamp",
                value: "8a0a45b4-2344-4d54-8d2c-05a7ac85fbc1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58cd381e-8683-4b42-b7b6-70b6274bfa84",
                column: "ConcurrencyStamp",
                value: "94ea1dff-c344-4e36-8aa3-c26645d6b43f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ddd633-2a4d-42b3-8f82-a5fe1d94173a",
                column: "ConcurrencyStamp",
                value: "39fedd57-99a4-4529-a243-558890ec1eda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08bc2fc1-5387-4033-b7d3-8208d29746ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "922bb513-36c0-4367-bbb3-03c1f0c121d3", "AQAAAAEAACcQAAAAEKIFZBpi26KQRLH0tVzvEzDuKyLybZdgye/0vx5x3Ga0nHYpf/kjaRCiGTYqOMYGbQ==", "c0345428-10af-4879-9458-8e89daa27ede" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fa0160f-c2c6-4124-8221-4f465e979807",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "152acfa9-7b8a-41e6-824f-82472564346a", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEKLCwYNtORpnZhbvPJBQzezkasFTwPf8slHIETOpc0pK94uOYOshZaOyUeomf2byaQ==", "79a6e63b-1371-4729-980e-6c8c31d4f1da" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avata", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3fa0160f-c2c6-4124-8221-4f465e979807", 0, "Hà Nam", null, "8649db95-d00d-4e87-bbd7-7bccb112398b", "Master@localhost.com", true, false, null, "MASTER@LOCALHOST.COM", "MASTER@LOCALHOST.COM", "AQAAAAEAACcQAAAAENV46r44NUYh8KPMA6HumED1rruma1aHPeWlyS9wM317/aFMZmGZye+HYME/0hklJw==", null, false, "3c57cc8a-9f48-4a03-8e54-7c5289e55dee", null, false, "master@localhost.com" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2023, 4, 10, 19, 44, 50, 421, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "58cd381e-8683-4b42-b7b6-70b6274bfa84", "3fa0160f-c2c6-4124-8221-4f465e979807" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58cd381e-8683-4b42-b7b6-70b6274bfa84", "3fa0160f-c2c6-4124-8221-4f465e979807" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa0160f-c2c6-4124-8221-4f465e979807");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399b34de-5b32-48b2-86b4-fb0881a2517c",
                column: "ConcurrencyStamp",
                value: "d844cb7b-e1b6-4f0d-9f58-8d9b869abf14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58cd381e-8683-4b42-b7b6-70b6274bfa84",
                column: "ConcurrencyStamp",
                value: "160c5d1c-0f3e-4330-8ced-6fca10b04761");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ddd633-2a4d-42b3-8f82-a5fe1d94173a",
                column: "ConcurrencyStamp",
                value: "fde86c79-7a68-4887-99c5-5ca9352ffacb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08bc2fc1-5387-4033-b7d3-8208d29746ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f01e9224-9dfa-43c1-bc16-c95c87dcfdfb", "AQAAAAEAACcQAAAAENoFfcS16mPMCV59VfxMLWnGg3EDCBezvpBLonRWa960SviDcCPpvwlAwqpTc7FFgw==", "6ac1a44f-c457-49dc-b83f-04f750f6a2d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fa0160f-c2c6-4124-8221-4f465e979807",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46140aa7-e436-4b95-bf41-28cb10082965", "BLOGOWNER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEHkj8J3oR60M4wUIS2lnAvVDf1MJ3PYImvA4k95tM8GyNxnJ6VVrbFokLv0twI0ZkQ==", "e05fc77a-72c9-4ecd-b60a-a21633fcdd46" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2023, 3, 27, 21, 55, 14, 411, DateTimeKind.Local).AddTicks(5662));
        }
    }
}
