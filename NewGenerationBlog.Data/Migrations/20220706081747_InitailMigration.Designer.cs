﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewGenerationBlog.Data.Concrete.EntityFramework.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NewGenerationBlog.Data.Migrations
{
    [DbContext(typeof(NewGenerationBlogContext))]
    [Migration("20220706081747_InitailMigration")]
    partial class InitailMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("citext")
                .HasAnnotation("Npgsql:CollationDefinition:case_insensitive_collation", "en-u-ks-primary,en-u-ks-primary,icu,False")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BOOLEAN");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.FavoritePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BOOLEAN");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("DATE");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("FavoritePosts");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("CommentCount")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FavoritePostId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BOOLEAN");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("BOOLEAN");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("DATE");

                    b.Property<string>("SeoAuthor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("SeoDecription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("SeoTags")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("citext");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Title")
                        .UseCollation(new[] { "case_insensitive_collation" });

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.TagPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BOOLEAN");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("DATE");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("TagPosts");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BOOLEAN");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BYTEA");

                    b.Property<string>("Picture")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.UserRefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATE");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("BOOLEAN");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("DATE");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRefreshTokens");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Category", b =>
                {
                    b.HasOne("NewGenerationBlog.Entities.Concrete.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Post_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.FavoritePost", b =>
                {
                    b.HasOne("NewGenerationBlog.Entities.Concrete.Post", "Post")
                        .WithOne("FavoritePost")
                        .HasForeignKey("NewGenerationBlog.Entities.Concrete.FavoritePost", "PostId")
                        .HasConstraintName("FK_Post_FavoritePost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewGenerationBlog.Entities.Concrete.User", "User")
                        .WithMany("FavoritePosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Post", b =>
                {
                    b.HasOne("NewGenerationBlog.Entities.Concrete.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("NewGenerationBlog.Entities.Concrete.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Post_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Tag", b =>
                {
                    b.HasOne("NewGenerationBlog.Entities.Concrete.User", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Tag_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.TagPost", b =>
                {
                    b.HasOne("NewGenerationBlog.Entities.Concrete.Post", "Post")
                        .WithMany("TagPosts")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewGenerationBlog.Entities.Concrete.Tag", "Tag")
                        .WithMany("TagPosts")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.UserRefreshToken", b =>
                {
                    b.HasOne("NewGenerationBlog.Entities.Concrete.User", "User")
                        .WithOne("UserRefreshToken")
                        .HasForeignKey("NewGenerationBlog.Entities.Concrete.UserRefreshToken", "UserId")
                        .HasConstraintName("FK_RefreshToken_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Post", b =>
                {
                    b.Navigation("FavoritePost");

                    b.Navigation("TagPosts");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.Tag", b =>
                {
                    b.Navigation("TagPosts");
                });

            modelBuilder.Entity("NewGenerationBlog.Entities.Concrete.User", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("FavoritePosts");

                    b.Navigation("Posts");

                    b.Navigation("Tags");

                    b.Navigation("UserRefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}