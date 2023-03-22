using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMobilePhone_DataAccess.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "399b34de-5b32-48b2-86b4-fb0881a2517c",
                column: "ConcurrencyStamp",
                value: "5ee8ecd8-d853-45ee-92d6-90768d02a288");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58cd381e-8683-4b42-b7b6-70b6274bfa84",
                column: "ConcurrencyStamp",
                value: "bb7f1604-4615-4783-a75a-6029daea0bce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97ddd633-2a4d-42b3-8f82-a5fe1d94173a",
                column: "ConcurrencyStamp",
                value: "ed7bf85c-3f65-4d22-8438-b63dddfb463b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08bc2fc1-5387-4033-b7d3-8208d29746ff",
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Hà Nội", "0f569885-a456-418c-bf07-e1b5cfe57c76", "AQAAAAEAACcQAAAAEG8J6gICX9FePnv/OzNrCvumuBQCbdg1IKOb1Nug4HakbGE8JT1Ifs9C2a6MIyak6A==", "7200423f-1d77-4531-ac52-436b6443dd72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fa0160f-c2c6-4124-8221-4f465e979807",
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Hà Nam", "4388f120-e92b-4b48-b434-3d74395574ec", "AQAAAAEAACcQAAAAELCgvVckJOBVA4V2gojZg03V40HoXceqSMXWXTlVhLIHLvaHdz9BKcJts7cFqt9ukg==", "d76b9404-7369-40ed-8db7-908bcb92af55" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2023, 3, 20, 22, 28, 24, 243, DateTimeKind.Local).AddTicks(2156));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

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
        }
    }
}
