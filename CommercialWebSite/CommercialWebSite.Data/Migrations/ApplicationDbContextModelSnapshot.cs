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
                            CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854127/cat-1_veobee.jpg"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Household",
                            CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-2_thblkg.jpg"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Electronic",
                            CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-3_dvyjbe.jpg"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Beauty",
                            CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-4_ymnplq.jpg"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Book",
                            CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-5_ijcxzw.jpg"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Pet",
                            CategoryPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-6_s3afnw.jpg"
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

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

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
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2399),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 2000.0,
                            ProductName = "Product 1",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-1_iyqgel.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2409)
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 4,
                            CreateDate = new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 2000.0,
                            ProductName = "Product 2",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-2_wds2xq.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2464),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 10000.0,
                            ProductName = "Product 3",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-3_ysbo6f.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2465)
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2483),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 10000.0,
                            ProductName = "Product 4",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-4_w2yb1f.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2484)
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2501),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 10000.0,
                            ProductName = "Product 5",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-5_nhbfgf.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2502)
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2521),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 10000.0,
                            ProductName = "Product 6",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-6_rsti5j.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2522)
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2538),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 10000.0,
                            ProductName = "Product 7",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-7_ykpjce.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2539)
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2554),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 2300.0,
                            ProductName = "Product 8",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-8_wu5jzf.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2555)
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2570),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 2300.0,
                            ProductName = "Product 9",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-9_pik3wm.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2571)
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2589),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 2300.0,
                            ProductName = "Product 10",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-10_buoi29.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2590)
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 3,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2607),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 2300.0,
                            ProductName = "Product 11",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-11_zpxzs7.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2608)
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 2,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2803),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 30000.0,
                            ProductName = "Product 12",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-12_s0abhz.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2804)
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 2,
                            CreateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2823),
                            Description = "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.",
                            Price = 30000.0,
                            ProductName = "Product 13",
                            ProductPicture = "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-13_p3fpxz.jpg",
                            UpdateDate = new DateTime(2022, 10, 31, 21, 13, 39, 895, DateTimeKind.Local).AddTicks(2824)
                        });
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.ProductReview", b =>
                {
                    b.Property<int>("ProductReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductReviewId"), 1L, 1);

                    b.Property<DateTime?>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductRating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAccountId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserAccountId");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.UserAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasData(
                        new
                        {
                            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            ConcurrencyStamp = "c509ac8c-6f1b-49b3-a9c7-38b3ee840070",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEOBorZMH0f8QwKR0RmR50p5+NrAHPjUN8m0MjOTwOLtzlGueYXUgsScGxczvTSPbCw==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "25df39e0-4849-49a7-b6dd-bc5e0b25b176",
                            TwoFactorEnabled = false,
                            UserAddress = "sdfasdfsadf",
                            UserName = "admin"
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

                    b.HasData(
                        new
                        {
                            Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                            ConcurrencyStamp = "2",
                            Name = "User",
                            NormalizedName = "User"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                            RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
                        });
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

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.ProductReview", b =>
                {
                    b.HasOne("CommercialWebSite.Data.DataModel.Product", "Product")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommercialWebSite.Data.DataModel.UserAccount", "UserAccount")
                        .WithMany("ProductReviews")
                        .HasForeignKey("UserAccountId");

                    b.Navigation("Product");

                    b.Navigation("UserAccount");
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
                    b.HasOne("CommercialWebSite.Data.DataModel.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CommercialWebSite.Data.DataModel.UserAccount", null)
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

                    b.HasOne("CommercialWebSite.Data.DataModel.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CommercialWebSite.Data.DataModel.UserAccount", null)
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

                    b.Navigation("ProductReviews");
                });

            modelBuilder.Entity("CommercialWebSite.Data.DataModel.UserAccount", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
