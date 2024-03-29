﻿// <auto-generated />
using System;
using ComicProjectFinal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComicProjectFinal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComicProjectFinal.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            BrandName = "Marvel"
                        },
                        new
                        {
                            BrandId = 2,
                            BrandName = "DC"
                        },
                        new
                        {
                            BrandId = 3,
                            BrandName = "WOTC"
                        });
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CartItems")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.CartDetails", b =>
                {
                    b.Property<int>("CartDetrailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartDetrailsId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("CartDetrailsId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DropDown")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Books",
                            DropDown = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Toys",
                            DropDown = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Games",
                            DropDown = 3
                        });
                });

            modelBuilder.Entity("ComicProjectFinal.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailsId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double?>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderStatusId"));

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Orders", b =>
                {
                    b.Property<int>("OrdersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdersId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrdersId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Products", b =>
                {
                    b.Property<int>("ProductsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductsId"));

                    b.Property<int?>("BrandId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductsId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductsId = 1,
                            BrandId = 1,
                            BrandName = "Marvel",
                            CategoryId = 1,
                            Images = "storm.jpg",
                            Price = 10.0,
                            ProductName = "Storm 002"
                        },
                        new
                        {
                            ProductsId = 2,
                            BrandId = 1,
                            BrandName = "Marvel",
                            CategoryId = 1,
                            Images = "capbp.jpg",
                            Price = 4.0,
                            ProductName = "Flag Of Our Fathers"
                        },
                        new
                        {
                            ProductsId = 3,
                            BrandId = 1,
                            BrandName = "Marvel",
                            CategoryId = 1,
                            Images = "bp.jpg",
                            Price = 3.0,
                            ProductName = "Black Panter vs Luke Cage"
                        },
                        new
                        {
                            ProductsId = 4,
                            BrandId = 2,
                            BrandName = "Dc",
                            CategoryId = 1,
                            Images = "gl.jpg",
                            Price = 1.5,
                            ProductName = "Green Lantern"
                        },
                        new
                        {
                            ProductsId = 5,
                            BrandId = 2,
                            BrandName = "Dc",
                            CategoryId = 1,
                            Images = "flash.jpg",
                            Price = 1.0,
                            ProductName = "The Flash"
                        },
                        new
                        {
                            ProductsId = 6,
                            BrandId = 2,
                            BrandName = "Dc",
                            CategoryId = 1,
                            Images = "ww.jpg",
                            Price = 2.0,
                            ProductName = "Wonder Woman"
                        },
                        new
                        {
                            ProductsId = 7,
                            BrandId = 1,
                            BrandName = "Marvel",
                            CategoryId = 1,
                            Images = "xmen.jpg",
                            Price = 4.0,
                            ProductName = "The Uncanny DeadPool"
                        },
                        new
                        {
                            ProductsId = 8,
                            BrandId = 1,
                            BrandName = "Marvel",
                            CategoryId = 1,
                            Images = "dp.jpg",
                            Price = 4.0,
                            ProductName = "Marvel Zomvies: DeadPool"
                        },
                        new
                        {
                            ProductsId = 9,
                            BrandId = 2,
                            BrandName = "Dc",
                            CategoryId = 2,
                            Images = "joker.jpg",
                            Price = 20.0,
                            ProductName = "Joker"
                        },
                        new
                        {
                            ProductsId = 10,
                            BrandId = 2,
                            BrandName = "Dc",
                            CategoryId = 2,
                            Images = "joker_boss.jpg",
                            Price = 20.0,
                            ProductName = "Joker Boss"
                        },
                        new
                        {
                            ProductsId = 11,
                            BrandId = 2,
                            BrandName = "Dc",
                            CategoryId = 2,
                            Images = "harley.jpg",
                            Price = 20.0,
                            ProductName = "Harley Quinn"
                        },
                        new
                        {
                            ProductsId = 12,
                            BrandId = 3,
                            BrandName = "WOTC",
                            CategoryId = 3,
                            Images = "dndmtg.jpg",
                            Price = 100.0,
                            ProductName = "Mind Flayer Deck"
                        },
                        new
                        {
                            ProductsId = 13,
                            BrandId = 3,
                            BrandName = "WOTC",
                            CategoryId = 3,
                            Images = "faceless_menace.jpg",
                            Price = 100.0,
                            ProductName = "Faceless Menace Deck"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ComicProjectFinal.Models.CartDetails", b =>
                {
                    b.HasOne("ComicProjectFinal.Models.Cart", "Carts")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicProjectFinal.Models.Products", "Products")
                        .WithMany("CartDetails")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.OrderDetails", b =>
                {
                    b.HasOne("ComicProjectFinal.Models.Orders", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicProjectFinal.Models.Products", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Orders", b =>
                {
                    b.HasOne("ComicProjectFinal.Models.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Products", b =>
                {
                    b.HasOne("ComicProjectFinal.Models.Brand", "Brands")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicProjectFinal.Models.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brands");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ComicProjectFinal.Models.Products", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
