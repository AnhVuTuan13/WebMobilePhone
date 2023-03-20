using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMobilePhone_DataAccess.Migrations
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399b34de-5b32-48b2-86b4-fb0881a2517c",
                column: "ConcurrencyStamp",
                value: "764b7317-a5a8-4799-813c-5d00d1bb9155");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58cd381e-8683-4b42-b7b6-70b6274bfa84",
                column: "ConcurrencyStamp",
                value: "05b0521f-638f-46ed-b323-b131367fed9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ddd633-2a4d-42b3-8f82-a5fe1d94173a",
                column: "ConcurrencyStamp",
                value: "83dc61d1-d100-4fec-8a0a-bd2396886159");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08bc2fc1-5387-4033-b7d3-8208d29746ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa0a82d3-2978-4302-be9a-2a0e7a17ff58", "AQAAAAEAACcQAAAAEFrgB8ixqd0Q2uW8vjDCPYeChMTVwjM/4k1BqzYEq/jS8DjOHWcepvgjjI+jYgHqXQ==", "9ca89313-018d-41db-8c9d-61a50f273000" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fa0160f-c2c6-4124-8221-4f465e979807",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebe0503e-1f35-4e81-83f4-cfdd718fe9cf", "AQAAAAEAACcQAAAAENv3FgdisoJCRQWYhNVqsPQyTLJTLpB+oJXns5XG9Q9mCerUH7fyPPT4XKtnvg+etA==", "d11876fc-ac02-4827-9c4f-36cea9f9e013" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2023, 3, 19, 22, 56, 44, 163, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Price",
                value: 13000000.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399b34de-5b32-48b2-86b4-fb0881a2517c",
                column: "ConcurrencyStamp",
                value: "2bbb0fb6-4de5-467f-bdda-3d789fe78b59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58cd381e-8683-4b42-b7b6-70b6274bfa84",
                column: "ConcurrencyStamp",
                value: "b1fd2617-15cc-419e-a105-6cdd36e7c3ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ddd633-2a4d-42b3-8f82-a5fe1d94173a",
                column: "ConcurrencyStamp",
                value: "122779e0-e388-47df-aa50-fb5d00bc9f1b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08bc2fc1-5387-4033-b7d3-8208d29746ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1006d67b-620f-4d98-812a-77e61cd22709", "AQAAAAEAACcQAAAAEAyWm0yTfmP2j8j7usAjALMMLHqmZ11mq0zlrWdtxpIUFfg/XlCRovGIDKsZeeYDYg==", "656cd126-70a0-4c2e-9586-4ee103a1b292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fa0160f-c2c6-4124-8221-4f465e979807",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5da0e8a-7f4a-40d1-abc4-9af57ecc891f", "AQAAAAEAACcQAAAAECtt3QM5Z3vfsg7Vlyqvwe1I4o2i012YTADz3Mvew7n4Gmk5u351dymQbl/PAC46dg==", "06af3452-207e-48b2-b4c7-dcacfb4686e7" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2023, 3, 19, 21, 55, 3, 597, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Price",
                value: 15000000.0);
        }
    }
}
