using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NewGenerationBlog.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsDeleted = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsDeleted = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Mobile = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BYTEA", nullable: false),
                    Picture = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsDeleted = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Thumbnail = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ViewsCount = table.Column<int>(type: "integer", nullable: false),
                    CommentCount = table.Column<int>(type: "integer", nullable: false),
                    SeoAuthor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SeoDecription = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsDeleted = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsDeleted = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagPosts_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "Description", "IsDeleted", "IsPublic", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1190), "C# ile ilgili en güncel bilgiler", false, false, new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1580), "C#" },
                    { 2, 1, new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1970), "C++ ile ilgili en güncel bilgiler", false, false, new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1970), "C++" },
                    { 3, 1, new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1980), "Javascript ile ilgili en güncel bilgiler", false, false, new DateTime(2022, 4, 4, 10, 36, 8, 765, DateTimeKind.Local).AddTicks(1980), "Javascript" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "Description", "IsDeleted", "IsPublic", "ModifiedDate", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 4, 4, 10, 36, 8, 776, DateTimeKind.Local).AddTicks(8640), "Super User, Have all rights", false, false, new DateTime(2022, 4, 4, 10, 36, 8, 776, DateTimeKind.Local).AddTicks(8650), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedById", "CreatedDate", "Description", "Email", "FirstName", "IsDeleted", "IsPublic", "LastName", "Mobile", "ModifiedDate", "PasswordHash", "Picture", "RoleId", "Username" },
                values: new object[] { 1, new DateTime(1980, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 4, 4, 10, 36, 8, 779, DateTimeKind.Local).AddTicks(5420), "Owner Of the system", "serkanisel@gmail.com", "Serkan", false, false, "İşel", "532 586 6292", new DateTime(2022, 4, 4, 10, 36, 8, 779, DateTimeKind.Local).AddTicks(5430), new byte[] { 49, 48, 50, 52, 98, 51, 52, 56, 54, 102, 97, 97, 101, 100, 101, 56, 57, 48, 52, 101, 52, 102, 101, 53, 54, 97, 102, 102, 50, 102, 102, 49 }, "", 1, "sisel" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedById", "CreatedDate", "Date", "IsDeleted", "IsPublic", "ModifiedDate", "SeoAuthor", "SeoDecription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", 1, new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(3900), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(3070), false, false, new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(3910), "Serkan İşel", "C# 9.0 ve .net 5 yenilikleri", "C#,C# 9, .NET5, .NET Framework, .NET Core", "Default.jpg", "C# 9.0 ve .net 5 yenilikleri", 1, 100 },
                    { 2, 2, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", 1, new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4250), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4250), false, false, new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260), "Serkan İşel", "C++ nedir?", "C++,,C", "Default.jpg", "C++ nedir?", 1, 90 },
                    { 3, 3, 0, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", 1, new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260), new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260), false, false, new DateTime(2022, 4, 4, 10, 36, 8, 775, DateTimeKind.Local).AddTicks(4260), "Serkan İşel", "Javascript Nedir?", "Javascript", "Default.jpg", "Javascript Nedir?", 1, 110 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_PostId",
                table: "TagPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_TagId",
                table: "TagPosts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagPosts");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
