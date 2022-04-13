using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewGenerationBlog.Data.Migrations
{
    public partial class deleteIsPublicColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "TagPosts");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsPublic",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Users",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Tags",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "TagPosts",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Roles",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Categories",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1190), new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1580) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1970), new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1970) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1980), new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1980) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(3900), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(3070), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(3910) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4250), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4250), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 776, DateTimeKind.Local).AddTicks(8640), new DateTime(2022, 4, 4, 10, 36, 8, 776, DateTimeKind.Local).AddTicks(8650) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 4, 10, 36, 8, 779, DateTimeKind.Local).AddTicks(5420), new DateTime(2022, 4, 4, 10, 36, 8, 779, DateTimeKind.Local).AddTicks(5430) });
        }
    }
}
