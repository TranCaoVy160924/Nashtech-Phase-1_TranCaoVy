using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.DataModel
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() { }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=LAPTOP-32SIU4JK;Initial Catalog=ECommerc_Website;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(p => p.AgregateUserRate)
                .HasDefaultValue(0);
            builder.Entity<Product>()
                .Property(p => p.NumberInStorage)
                .HasDefaultValue(0);

            SeedCategory(builder);
            SeedProduct(builder);
        }

        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Clothes"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Household"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Electronic"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Beauty"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Book"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Pet"
                });
        }

        private void SeedProduct(ModelBuilder builder)
        {
            for (int i = 1; i <= 2; i++)
            {
                builder.Entity<Product>().HasData(
                new
                {
                    ProductId = i,
                    ProductName = "Product " + i,
                    Description = "Product " + i,
                    ProductPicture = $"product-{i}.jpg",
                    Price = (Double)2000,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CategoryId = 4
                });
            }

            for (int i = 3; i <= 7; i++)
            {
                builder.Entity<Product>().HasData(
                new
                {
                    ProductId = i,
                    ProductName = "Product " + i,
                    Description = "Product " + i,
                    ProductPicture = $"product-{i}.jpg",
                    Price = (Double)10000,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CategoryId = 1
                });
            }

            for (int i = 8; i <= 11; i++)
            {
                builder.Entity<Product>().HasData(
                new
                {
                    ProductId = i,
                    ProductName = "Product " + i,
                    Description = "Product " + i,
                    ProductPicture = $"product-{i}.jpg",
                    Price = (Double)2300,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CategoryId = 3
                });
            }

            for (int i = 12; i <= 13; i++)
            {
                builder.Entity<Product>().HasData(
                new
                {
                    ProductId = i,
                    ProductName = "Product " + i,
                    Description = "Product " + i,
                    ProductPicture = $"product-{i}.jpg",
                    Price = (Double)30000,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CategoryId = 2
                });
            }
        }
    }
}
