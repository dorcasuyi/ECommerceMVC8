using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Models;

namespace ECommerceMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ItemCart> ItemCarts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            //modelBuilder.Entity<ItemCart>()
            //    .HasOne(ic => ic.Product)
            //    .WithMany()
            //    .HasForeignKey(ic => ic.ProductId);

            //seed data first
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 1000,
                    Description = "Description for Product 1",
                    ImageUrl = "https://example.com/product1.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 20000,
                    Description = "Description for Product 2",
                    ImageUrl = "https://example.com/product2.jpg"
                });

            modelBuilder.Entity<ItemCart>().HasData(
                new ItemCart
                {
                    Id = 1,
                    Quantity = 3,
                    ProductId = 1,
                    UserId = 1,
                    ProductName = "Product 1"
                },
                new ItemCart
                {
                    Id = 2,
                    Quantity = 1,
                    ProductId = 2,
                    UserId = 2,
                    ProductName = "Product 2"
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "test1@mail.com",
                    Password = "password"
                },
                new User
                {
                    Id = 2,
                    Email = "test2@mail.com",
                    Password = "password"
                });

        }
    }
}
