using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewGenerationBlog.Data.Migrations
{
    public partial class CategoryApi3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 323, DateTimeKind.Local).AddTicks(8910), new DateTime(2022, 4, 17, 18, 35, 20, 323, DateTimeKind.Local).AddTicks(9360), 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(110), new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(110), 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(120), new DateTime(2022, 4, 17, 18, 35, 20, 324, DateTimeKind.Local).AddTicks(120), 1 });

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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 333, DateTimeKind.Local).AddTicks(9670), new DateTime(2022, 4, 17, 18, 35, 20, 333, DateTimeKind.Local).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 35, 20, 337, DateTimeKind.Local).AddTicks(2920), new DateTime(2022, 4, 17, 18, 35, 20, 337, DateTimeKind.Local).AddTicks(2930) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(7490), new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8080), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8630), new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8630), 0 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8640), new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8640), 0 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(6470), new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(4280), new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(7020), new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(7020), new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(7040), new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(7040), new DateTime(2022, 4, 17, 18, 33, 5, 673, DateTimeKind.Local).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 676, DateTimeKind.Local).AddTicks(1520), new DateTime(2022, 4, 17, 18, 33, 5, 676, DateTimeKind.Local).AddTicks(1530) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 679, DateTimeKind.Local).AddTicks(8160), new DateTime(2022, 4, 17, 18, 33, 5, 679, DateTimeKind.Local).AddTicks(8180) });
        }
    }
}
