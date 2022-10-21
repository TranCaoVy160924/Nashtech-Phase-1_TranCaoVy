﻿// <auto-generated />
using System;
using CommercialWebSite.Data.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommercialWebSite.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Clothes",
                            CategoryPicture = "cat-1.jpg"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Household",
                            CategoryPicture = "cat-2.jpg"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Electronic",
                            CategoryPicture = "cat-3.jpg"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Beauty",
                            CategoryPicture = "cat-4.jpg"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Book",
                            CategoryPicture = "cat-5.jpg"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Pet",
                            CategoryPicture = "cat-6.jpg"
                        });
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsCheckedOut")
                        .HasColumnType("bit");

                    b.Property<int>("NumOfGood")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserRating")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("AgregateUserRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberInStorage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(1901),
                            Description = "Product 1",
                            Price = 2000.0,
                            ProductName = "Product 1",
                            ProductPicture = "product-1.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(1909)
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 4,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(1958),
                            Description = "Product 2",
                            Price = 2000.0,
                            ProductName = "Product 2",
                            ProductPicture = "product-2.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(1960)
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(1990),
                            Description = "Product 3",
                            Price = 10000.0,
                            ProductName = "Product 3",
                            ProductPicture = "product-3.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(1991)
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2010),
                            Description = "Product 4",
                            Price = 10000.0,
                            ProductName = "Product 4",
                            ProductPicture = "product-4.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2011)
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2029),
                            Description = "Product 5",
                            Price = 10000.0,
                            ProductName = "Product 5",
                            ProductPicture = "product-5.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2030)
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2050),
                            Description = "Product 6",
                            Price = 10000.0,
                            ProductName = "Product 6",
                            ProductPicture = "product-6.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2051)
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2069),
                            Description = "Product 7",
                            Price = 10000.0,
                            ProductName = "Product 7",
                            ProductPicture = "product-7.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2069)
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2089),
                            Description = "Product 8",
                            Price = 2300.0,
                            ProductName = "Product 8",
                            ProductPicture = "product-8.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2090)
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2286),
                            Description = "Product 9",
                            Price = 2300.0,
                            ProductName = "Product 9",
                            ProductPicture = "product-9.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2287)
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2313),
                            Description = "Product 10",
                            Price = 2300.0,
                            ProductName = "Product 10",
                            ProductPicture = "product-10.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2314)
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2331),
                            Description = "Product 11",
                            Price = 2300.0,
                            ProductName = "Product 11",
                            ProductPicture = "product-11.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2332)
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 2,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2351),
                            Description = "Product 12",
                            Price = 30000.0,
                            ProductName = "Product 12",
                            ProductPicture = "product-12.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2351)
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 2,
                            CreateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2369),
                            Description = "Product 13",
                            Price = 30000.0,
                            ProductName = "Product 13",
                            ProductPicture = "product-13.jpg",
                            UpdateDate = new DateTime(2022, 10, 21, 11, 54, 16, 353, DateTimeKind.Local).AddTicks(2370)
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.UserAccount", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("UserAccount");
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.Order", b =>
                {
                    b.HasOne("CommercialWebSite.Data.DataModel.UserAccount", "Buyer")
                        .WithMany("Orders")
                        .HasForeignKey("BuyerId");

                    b.HasOne("CommercialWebSite.Data.DataModel.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.Product", b =>
                {
                    b.HasOne("CommercialWebSite.Data.DataModel.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
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

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.UserAccount", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
