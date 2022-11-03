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
    public class ApplicationDbContext : IdentityDbContext<UserAccount>
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
        public DbSet<ProductReview> ProductReviews { get; set; }

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
                .Property(p => p.NumberInStorage)
                .HasDefaultValue(0);

            SeedCategory(builder);
            SeedProduct(builder);
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
        }

        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Clothes",
                    CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854127/cat-1_veobee.jpg"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Household",
                    CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-2_thblkg.jpg"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Electronic",
                    CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-3_dvyjbe.jpg",
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Beauty",
                    CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-4_ymnplq.jpg"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Book",
                    CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/w_150,h_150/v1666854128/cat-5_ijcxzw.jpg"
                });
            builder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Pet",
                    CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/w_150,h_150/v1666854128/cat-6_s3afnw.jpg"
                });
        }

        private void SeedProduct(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 1,
                    ProductName = "Product " + 1,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-1_iyqgel.jpg",
                    Price = (Double)2000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 4,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 2,
                    ProductName = "Product " + 2,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-2_wds2xq.jpg",
                    Price = (Double)2000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 4,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 3,
                    ProductName = "Product " + 3,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-3_ysbo6f.jpg",
                    Price = (Double)10000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 1,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 4,
                    ProductName = "Product " + 4,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-4_w2yb1f.jpg",
                    Price = (Double)10000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 1,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 5,
                    ProductName = "Product " + 5,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-5_nhbfgf.jpg",
                    Price = (Double)10000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 1,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 6,
                    ProductName = "Product " + 6,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-6_rsti5j.jpg",
                    Price = (Double)10000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 1,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 7,
                    ProductName = "Product " + 7,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-7_ykpjce.jpg",
                    Price = (Double)10000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 1,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 8,
                    ProductName = "Product " + 8,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-8_wu5jzf.jpg",
                    Price = (Double)2300,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 3,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 9,
                    ProductName = "Product " + 9,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-9_pik3wm.jpg",
                    Price = (Double)2300,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 3,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 10,
                    ProductName = "Product " + 10,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-10_buoi29.jpg",
                    Price = (Double)2300,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 3,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 11,
                    ProductName = "Product " + 11,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-11_zpxzs7.jpg",
                    Price = (Double)2300,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 3,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 12,
                    ProductName = "Product " + 12,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-12_s0abhz.jpg",
                    Price = (Double)30000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 2,
                    IsActive = true
                });
            builder.Entity<Product>().HasData(
                new
                {
                    ProductId = 13,
                    ProductName = "Product " + 13,
                    Description = "Open your door to the world " +
                        "of grilling with the sleek Spirit II E-210 gas grill." +
                        " This two burner grill is built to fit small spaces, and packed " +
                        "with features such as the powerful GS4 grilling system, iGrill " +
                        "capability, and convenient side tables for placing serving trays." +
                        " Welcome to the Weber family.",
                    ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-13_p3fpxz.jpg",
                    Price = (Double)30000,
                    CreateDate = GetFormattedDate(),
                    UpdateDate = GetFormattedDate(),
                    CategoryId = 2,
                    IsActive = true
                });
        }

        private void SeedUsers(ModelBuilder builder)
        {
            Guid g = Guid.NewGuid();

            // Admin
            UserAccount admin = new UserAccount()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                FirstName = "admin",
                LastName = "admin",
                UserAddress = "sdfasdfsadf",
                Birthday = DateTime.Today,
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
            };
            PasswordHasher<UserAccount> passwordHasher = new PasswordHasher<UserAccount>();
            string passwordAdmin = passwordHasher.HashPassword(admin, "M0untw3as3l@");
            admin.PasswordHash = passwordAdmin;
            builder.Entity<UserAccount>().HasData(admin);

            for(int i = 0; i <= 10; i++)
            {
                UserAccount user = new UserAccount()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user" + i,
                    Email = "user" + i + "@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",
                    FirstName = "user",
                    LastName = i.ToString(),
                    UserAddress = "sdfasdfsadf",
                    Birthday = DateTime.Today,
                    NormalizedUserName = "USER" + i,
                    NormalizedEmail = "USER" + i + "@GMAIL.COM",
                    RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330"
                };
                string password = passwordHasher.HashPassword(user, "M0untw3as3l@");
                user.PasswordHash = password;
                builder.Entity<UserAccount>().HasData(user);
            }
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
        }

        private string GetFormattedDate() => DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
    }
}
