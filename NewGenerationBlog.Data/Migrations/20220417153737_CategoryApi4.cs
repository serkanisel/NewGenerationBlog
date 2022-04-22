using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewGenerationBlog.Data.Migrations
{
    public partial class CategoryApi4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(760), new DateTime(2022, 4, 17, 18, 37, 36, 641, DateTimeKind.Local).AddTicks(8390), new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2290), new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2280), new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2300), new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2300), new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2300) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2520), new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(1310), new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2550) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2940), new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2940), new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2950), new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2950), new DateTime(2022, 4, 17, 18, 35, 20, 332, DateTimeKind.Local).AddTicks(2950) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "Description", "IsDeleted", "ModifiedDate", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 17, 18, 35, 20, 333, DateTimeKind.Local).AddTicks(9670), "Super User, Have all rights", false, new DateTime(2022, 4, 17, 18, 35, 20, 333, DateTimeKind.Local).AddTicks(9690), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedById", "CreatedDate", "Description", "Email", "FirstName", "IsDeleted", "LastName", "Mobile", "ModifiedDate", "PasswordHash", "Picture", "RoleId", "Username" },
                values: new object[] { 1, new DateTime(1980, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 4, 17, 18, 35, 20, 337, DateTimeKind.Local).AddTicks(2920), "Owner Of the system", "serkanisel@gmail.com", "Serkan", false, "İşel", "532 586 6292", new DateTime(2022, 4, 17, 18, 35, 20, 337, DateTimeKind.Local).AddTicks(2930), new byte[] { 49, 48, 50, 52, 98, 51, 52, 56, 54, 102, 97, 97, 101, 100, 101, 56, 57, 48, 52, 101, 52, 102, 101, 53, 54, 97, 102, 102, 50, 102, 102, 49 }, "", 1, "sisel" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "Description", "IsDeleted", "ModifiedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 17, 18, 35, 20, 323, DateTimeKind.Local).AddTicks(8910), "C# ile ilgili en güncel bilgiler", false, new DateTime(2022, 4, 17, 18, 35, 20, 323, DateTimeKind.Local).AddTicks(9360), "C#", 1 },
                    { 2, 1, new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(110), "C++ ile ilgili en güncel bilgiler", false, new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(110), "C++", 1 },
                    { 3, 1, new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(120), "Javascript ile ilgili en güncel bilgiler", false, new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(120), "Javascript", 1 }
                });
        }
    }
}
