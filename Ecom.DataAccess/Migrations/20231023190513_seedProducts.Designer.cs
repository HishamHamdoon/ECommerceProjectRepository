﻿// <auto-generated />
using ECommerceProject.Ecom.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceProject.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231023190513_seedProducts")]
    partial class seedProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceProject.Ecom.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Category of Clothes"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Category of Shooses"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Category of Mobiles"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Category of Accesories"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 4,
                            Name = "Category of Accesories"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 4,
                            Name = "Category of Accesories"
                        });
                });

            modelBuilder.Entity("Ecom.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Hisham",
                            CategoryId = 5,
                            Description = "this is a C# book",
                            ISBN = "ASDCV456",
                            ImageUrl = "",
                            ListPrice = 88.0,
                            Price = 100.0,
                            Price100 = 55.0,
                            Price50 = 90.0,
                            Title = "C# for beginners"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Hisham",
                            CategoryId = 6,
                            Description = "this is a C# book",
                            ISBN = "ASDCV456",
                            ImageUrl = "",
                            ListPrice = 88.0,
                            Price = 100.0,
                            Price100 = 55.0,
                            Price50 = 90.0,
                            Title = "C# for beginners"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Obai",
                            CategoryId = 5,
                            Description = "this is a Cdotnet book in pdf",
                            ISBN = "ASDCV4564566",
                            ImageUrl = "",
                            ListPrice = 88.0,
                            Price = 100.0,
                            Price100 = 55.0,
                            Price50 = 90.0,
                            Title = "dornet for beginners"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Ahmed",
                            CategoryId = 6,
                            Description = "this is a C++ book for beginners",
                            ISBN = "ASDCV456",
                            ImageUrl = "",
                            ListPrice = 88.0,
                            Price = 100.0,
                            Price100 = 55.0,
                            Price50 = 90.0,
                            Title = "C++ for beginners"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Ali",
                            CategoryId = 5,
                            Description = "this is a F# book for beginners",
                            ISBN = "ASDCV4asdf56",
                            ImageUrl = "",
                            ListPrice = 88.0,
                            Price = 100.0,
                            Price100 = 55.0,
                            Price50 = 90.0,
                            Title = "F# for beginners"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Musa",
                            CategoryId = 6,
                            Description = "this is a PHP book for beginners",
                            ISBN = "ASDCV456884513",
                            ImageUrl = "",
                            ListPrice = 88.0,
                            Price = 55.0,
                            Price100 = 150.0,
                            Price50 = 66.0,
                            Title = "PHP for beginners"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Ahmed Taha",
                            CategoryId = 5,
                            Description = "this is a Media book for beginners",
                            ISBN = "ASDCV4sd2356",
                            ImageUrl = "",
                            ListPrice = 50.0,
                            Price = 45.0,
                            Price100 = 22.0,
                            Price50 = 10.0,
                            Title = "Media for beginners"
                        });
                });

            modelBuilder.Entity("Ecom.Models.Models.Product", b =>
                {
                    b.HasOne("ECommerceProject.Ecom.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}