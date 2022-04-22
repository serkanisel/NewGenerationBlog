using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewGenerationBlog.Data.Migrations
{
    public partial class CategoryApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 450, DateTimeKind.Local).AddTicks(9510), new DateTime(2022, 4, 4, 17, 32, 23, 450, DateTimeKind.Local).AddTicks(9950) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 451, DateTimeKind.Local).AddTicks(350), new DateTime(2022, 4, 4, 17, 32, 23, 451, DateTimeKind.Local).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 451, DateTimeKind.Local).AddTicks(360), new DateTime(2022, 4, 4, 17, 32, 23, 451, DateTimeKind.Local).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5360), new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(4310), new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5920), new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5920), new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5930), new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5930), new DateTime(2022, 4, 4, 17, 32, 23, 462, DateTimeKind.Local).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 463, DateTimeKind.Local).AddTicks(9850), new DateTime(2022, 4, 4, 17, 32, 23, 463, DateTimeKind.Local).AddTicks(9860) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 17, 32, 23, 466, DateTimeKind.Local).AddTicks(4650), new DateTime(2022, 4, 4, 17, 32, 23, 466, DateTimeKind.Local).AddTicks(4660) });
        }
    }
}
