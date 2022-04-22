using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewGenerationBlog.Data.Migrations
{
    public partial class CategoryApi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(7490), new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8630), new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8640), new DateTime(2022, 4, 17, 18, 33, 5, 662, DateTimeKind.Local).AddTicks(8640) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 575, DateTimeKind.Local).AddTicks(3860), new DateTime(2022, 4, 17, 18, 29, 57, 575, DateTimeKind.Local).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 575, DateTimeKind.Local).AddTicks(4830), new DateTime(2022, 4, 17, 18, 29, 57, 575, DateTimeKind.Local).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 575, DateTimeKind.Local).AddTicks(4840), new DateTime(2022, 4, 17, 18, 29, 57, 575, DateTimeKind.Local).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2370), new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(1110), new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2800), new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2800), new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2800) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2810), new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2810), new DateTime(2022, 4, 17, 18, 29, 57, 587, DateTimeKind.Local).AddTicks(2820) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 589, DateTimeKind.Local).AddTicks(610), new DateTime(2022, 4, 17, 18, 29, 57, 589, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 17, 18, 29, 57, 592, DateTimeKind.Local).AddTicks(2330), new DateTime(2022, 4, 17, 18, 29, 57, 592, DateTimeKind.Local).AddTicks(2350) });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
