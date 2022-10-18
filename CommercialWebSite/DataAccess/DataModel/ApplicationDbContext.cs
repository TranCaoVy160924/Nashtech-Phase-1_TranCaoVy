using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
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

            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Clothes"
                });


            for (int i = 1; i < 9; i++)
            {
                builder.Entity<Product>().HasData(
                new
                {
                    ProductId = i,
                    ProductName = "Product " + i,
                    Description = "Product " + i,
                    ProductPicture = $"./images/product-{i}.png",
                    Price = (Double)10000,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CategoryId = 1
                });
            }
        }
    }
}
