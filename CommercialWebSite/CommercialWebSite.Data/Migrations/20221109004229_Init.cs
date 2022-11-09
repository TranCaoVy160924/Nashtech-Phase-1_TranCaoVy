using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommercialWebSite.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberInStorage = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOfGood = table.Column<int>(type: "int", nullable: false),
                    IsCheckedOut = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    ProductReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductRating = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.ProductReviewId);
                    table.ForeignKey(
                        name: "FK_ProductReviews_AspNetUsers_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "User", "User" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CategoryPicture", "IsActive" },
                values: new object[,]
                {
                    { 1, "Clothes", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854127/cat-1_veobee.jpg", true },
                    { 2, "Household", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-2_thblkg.jpg", true },
                    { 3, "Electronic", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-3_dvyjbe.jpg", true },
                    { 4, "Beauty", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-4_ymnplq.jpg", true },
                    { 5, "Book", "https://res.cloudinary.com/dddvmxs3h/image/upload/w_150,h_150/v1666854128/cat-5_ijcxzw.jpg", true },
                    { 6, "Pet", "https://res.cloudinary.com/dddvmxs3h/image/upload/w_150,h_150/v1666854128/cat-6_s3afnw.jpg", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserAddress", "UserName" },
                values: new object[,]
                {
                    { "1457c866-7bc6-4583-8f31-fc02b2035116", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "da1bfbf7-77b0-4464-948f-2d50e6f08906", "user3@gmail.com", false, "user", "3", false, null, "USER3@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEBQopfeX5azhf+MOCpyGKZpUpXgO6qixazqMUjkugK8xOU4zjJt9AFaBt03l32hMYQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "7c7771c5-603a-4177-a85c-5cd45ec94518", false, "sdfasdfsadf", "user3" },
                    { "417815be-ada0-43c8-b2cc-8c9c2385d58d", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "669fb66d-f30c-42ae-af66-013f8cd82c4f", "user7@gmail.com", false, "user", "7", false, null, "USER7@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAEB2vlI/fLg/W0eIu+Skhouw7CvJqU+nRccr6mZlCea6WouAoMycM7RIy+DV17UxmGg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "de7fa41a-bf10-4a10-88e5-01ab83c68367", false, "sdfasdfsadf", "user7" },
                    { "5f5fb979-4b23-410e-a51a-bafa11b289ca", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "e76c5bae-6b84-402a-8174-e6a558be3e03", "user2@gmail.com", false, "user", "2", false, null, "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEGx7GlaCMyxqopM9jwTp5xpv6xPy2RkYT4fvqR++z0tKu6Jyax04/cVwadbt8FUWSw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "15cc6828-a68a-41ef-a5de-21217f37fac9", false, "sdfasdfsadf", "user2" },
                    { "a4a90be0-6a54-4225-9a90-ab441827d521", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "32082482-f6a4-4360-b47a-49e23909ccd4", "user4@gmail.com", false, "user", "4", false, null, "USER4@GMAIL.COM", "USER4", "AQAAAAEAACcQAAAAEE8Zl0WiWJ8HIAMVIwJFeIAfjjU2Y7JfcoLT6WEeUyK0mBmFrprrgq4hAE/keLXB4g==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "e87eaf76-9180-4750-8c8e-734a0297f715", false, "sdfasdfsadf", "user4" },
                    { "a7cf8cdd-d1ac-4b96-9921-9b36f91aba4a", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "18ada692-7fef-4112-b7f3-78aa2075227c", "user8@gmail.com", false, "user", "8", false, null, "USER8@GMAIL.COM", "USER8", "AQAAAAEAACcQAAAAEHrLCYl99QQeYvnL+V9Cl1quKAvkIM7jDIy0pGEyLwQWEJyxlFnpVdTqcS+UyKgkxw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "5daf95a5-ffdf-4b4e-8303-5c93b7709102", false, "sdfasdfsadf", "user8" },
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "3b227f73-edce-4a0a-8247-2e9d54dfd5dc", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEDH50/zaNUKxuNAGp8AkSJofhcUAnnoSpU5Stdtt/8J5CScvFeiWgFILuzQ5WpblAg==", "1234567890", false, "fab4fac1-c546-41de-aebc-a14da6895711", "05e49380-8744-4c17-907b-e41101a45472", false, "sdfasdfsadf", "admin" },
                    { "ba402e2b-807c-4b18-b4e2-c660165195a0", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "eecf1ffb-45df-4598-a2fb-4e766076bd3e", "user10@gmail.com", false, "user", "10", false, null, "USER10@GMAIL.COM", "USER10", "AQAAAAEAACcQAAAAEFl+N4UlXa8CPtHcHxPTx0Xud5/VO7LnyLpmxK9Ku8q9yKh/McdA5Lio5JumGsEmVg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "6c0a0df2-9e62-4655-bfcf-fcb2349e3eab", false, "sdfasdfsadf", "user10" },
                    { "bcbe06e4-ee60-41d4-8097-229ac73495fc", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "0e65ea53-61f4-48e6-8f32-77a7c33f45a9", "user6@gmail.com", false, "user", "6", false, null, "USER6@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAEDEl5Irtxk/fMiLwmWv0catC9pE7JBIHeJqnRWca2XKiJecvIcXhUyOSIjHkKcf7vQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "a2e212cc-48f6-4529-952c-aeaeaef057d5", false, "sdfasdfsadf", "user6" },
                    { "cfe21517-b8ff-46b5-9619-9a9e96141f07", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "f83288e2-28e1-4067-ada0-8f5a2d288a32", "user9@gmail.com", false, "user", "9", false, null, "USER9@GMAIL.COM", "USER9", "AQAAAAEAACcQAAAAEBPkCFcrYLU8RbIgvEdi/EOVg4jLkpg6TyAfw3/l2OMldvCTp9meUOc8PBG9u3xVbQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "e2a030aa-6008-41e4-acac-b52f30a5ea9d", false, "sdfasdfsadf", "user9" },
                    { "d0b2f204-eb21-4c87-9e10-1eb47b8e659a", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "0bf764a9-ac21-4ff3-b3b2-d96cef8f02cc", "user5@gmail.com", false, "user", "5", false, null, "USER5@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAEIDo1AJmLrogJlE+lTbdt36McrSrR/pULqp8+fNoGB/RQM6gjqV544IKjgFCt6sL6g==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "a7af0eac-8863-4bad-a21a-7d7f11c48932", false, "sdfasdfsadf", "user5" },
                    { "e51bab40-550a-4cf8-8d3a-9c8fb28921f0", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "e0a87fcf-6efc-4e20-ad8a-f44600768715", "user1@gmail.com", false, "user", "1", false, null, "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEL/gwmqM1Cu40xjHjRrD8V4SRSNaHFsgkjVpLibDylQWdjLDweXm1C9sZgBafPPInA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "45092b16-066f-48c9-bf5d-6e88e76a3d54", false, "sdfasdfsadf", "user1" },
                    { "fb72903f-7432-4f54-a2a3-867627f727ab", 0, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Local), "5badee7e-43f6-45c2-889f-31ae63556167", "user0@gmail.com", false, "user", "0", false, null, "USER0@GMAIL.COM", "USER0", "AQAAAAEAACcQAAAAENKngItaQidFbQcfRdVEVJ5cG1UTnopHhp7XKUAwTfhPhOTaRvBCUiKs1kDoQmSN5Q==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "cf9b066a-604e-4759-bac2-c95dfa5d73fb", false, "sdfasdfsadf", "user0" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "ProductPicture", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 4, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 1", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-1_iyqgel.jpg", "11/09/2022 7:42 AM" },
                    { 2, 4, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 2", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-2_wds2xq.jpg", "11/09/2022 7:42 AM" },
                    { 3, 1, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 3", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-3_ysbo6f.jpg", "11/09/2022 7:42 AM" },
                    { 4, 1, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 4", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-4_w2yb1f.jpg", "11/09/2022 7:42 AM" },
                    { 5, 1, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 5", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-5_nhbfgf.jpg", "11/09/2022 7:42 AM" },
                    { 6, 1, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 6", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-6_rsti5j.jpg", "11/09/2022 7:42 AM" },
                    { 7, 1, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 7", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-7_ykpjce.jpg", "11/09/2022 7:42 AM" },
                    { 8, 3, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 8", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-8_wu5jzf.jpg", "11/09/2022 7:42 AM" },
                    { 9, 3, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 9", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-9_pik3wm.jpg", "11/09/2022 7:42 AM" },
                    { 10, 3, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 10", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-10_buoi29.jpg", "11/09/2022 7:42 AM" },
                    { 11, 3, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 11", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-11_zpxzs7.jpg", "11/09/2022 7:42 AM" },
                    { 12, 2, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 12", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-12_s0abhz.jpg", "11/09/2022 7:42 AM" },
                    { 13, 2, "11/09/2022 7:42 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 13", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-13_p3fpxz.jpg", "11/09/2022 7:42 AM" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "BuyerId", "IsActive", "IsCheckedOut", "NumOfGood", "ProductId" },
                values: new object[,]
                {
                    { 1, "b74ddd14-6340-4840-95c2-db12554843e5", true, false, 2, 1 },
                    { 2, "b74ddd14-6340-4840-95c2-db12554843e5", true, true, 2, 2 },
                    { 3, "b74ddd14-6340-4840-95c2-db12554843e5", true, false, 2, 3 },
                    { 4, "b74ddd14-6340-4840-95c2-db12554843e5", true, true, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_UserAccountId",
                table: "ProductReviews",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
