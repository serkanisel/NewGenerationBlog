using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewGenerationBlog.Data.Migrations
{
    public partial class ContentTextAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "ContentText",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ContentText",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedById", "CreatedDate", "Date", "IsDeleted", "IsPublic", "ModifiedDate", "SeoAuthor", "SeoDecription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", 1, new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(760), new DateTime(2022, 4, 17, 18, 37, 36, 641, DateTimeKind.Local).AddTicks(8390), false, false, new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(1290), "Serkan İşel", "C# 9.0 ve .net 5 yenilikleri", "C#,C# 9, .NET5, .NET Framework, .NET Core", "Default.jpg", "C# 9.0 ve .net 5 yenilikleri", 1, 100 },
                    { 2, 2, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", 1, new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2290), new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2280), false, false, new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2290), "Serkan İşel", "C++ nedir?", "C++,,C", "Default.jpg", "C++ nedir?", 1, 90 },
                    { 3, 3, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", 1, new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2300), new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2300), false, false, new DateTime(2022, 4, 17, 18, 37, 36, 642, DateTimeKind.Local).AddTicks(2300), "Serkan İşel", "Javascript Nedir?", "Javascript", "Default.jpg", "Javascript Nedir?", 1, 110 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
