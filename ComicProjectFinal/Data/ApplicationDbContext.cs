using ComicProjectFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicProjectFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call base method to configure Identity-related model
           

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Orders)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetails>()
             .HasOne(p => p.Products)
    .WithMany(b => b.OrderDetails)
    .HasForeignKey(p => p.ProductsId);

            modelBuilder.Entity<Products>().HasData(
                new Products { ProductsId = 1, BrandId = 1, BrandName = "Marvel", CategoryId = 1, ProductName = "Storm 002", Price = 10.00, Images = "storm.jpg" },
                new Products { ProductsId = 2, BrandId = 1, BrandName = "Marvel", CategoryId = 1, ProductName = "Flag Of Our Fathers", Price = 4.00, Images = "capbp.jpg" },
                new Products { ProductsId = 3, BrandId = 1, BrandName = "Marvel", CategoryId = 1, ProductName = "Black Panter vs Luke Cage", Price = 3.00, Images = "bp.jpg" },
                new Products { ProductsId = 4, BrandId = 2, BrandName = "Dc", CategoryId = 1, ProductName = "Green Lantern", Price = 1.5, Images = "gl.jpg" },
                new Products { ProductsId = 5, BrandId = 2, BrandName = "Dc", CategoryId = 1, ProductName = "The Flash", Price = 1.00, Images = "flash.jpg" },
                new Products { ProductsId = 6, BrandId = 2, BrandName = "Dc", CategoryId = 1, ProductName = "Wonder Woman", Price = 2.00, Images = "ww.jpg" },
                new Products { ProductsId = 7, BrandId = 1, BrandName = "Marvel", CategoryId = 1, ProductName = "The Uncanny DeadPool", Price = 4.00, Images = "xmen.jpg" },
                new Products { ProductsId = 8, BrandId = 1, BrandName = "Marvel", CategoryId = 1, ProductName = "Marvel Zomvies: DeadPool", Price = 4.00, Images = "dp.jpg" },
                new Products { ProductsId = 9, BrandId = 2, BrandName = "Dc", CategoryId = 2, ProductName = "Joker", Price = 20.00, Images = "joker.jpg" },
                new Products { ProductsId = 10, BrandId = 2, BrandName = "Dc", CategoryId = 2, ProductName = "Joker Boss", Price = 20.00, Images = "joker_boss.jpg" },
                new Products { ProductsId = 11, BrandId = 2, BrandName = "Dc", CategoryId = 2, ProductName = "Harley Quinn", Price = 20.00, Images = "harley.jpg" },
                new Products { ProductsId = 12, BrandId = 3, BrandName = "WOTC", CategoryId = 3, ProductName = "Mind Flayer Deck", Price = 100.00, Images = "dndmtg.jpg" },
                new Products { ProductsId = 13, BrandId = 3, BrandName = "WOTC", CategoryId = 3, ProductName = "Faceless Menace Deck", Price = 100.00, Images = "faceless_menace.jpg" }
            );
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, BrandName = "Marvel" },
    new Brand { BrandId = 2, BrandName = "DC" },
    new Brand { BrandId = 3, BrandName = "WOTC" });
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Books" ,DropDown=1},
    new Category { CategoryId = 2, CategoryName = "Toys",DropDown=2 },
    new Category { CategoryId = 3, CategoryName = "Games" , DropDown = 3 });

        }
    }
}
