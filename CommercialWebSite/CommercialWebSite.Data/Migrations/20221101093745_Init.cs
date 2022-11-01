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
                    CategoryPicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    IsCheckedOut = table.Column<bool>(type: "bit", nullable: false),
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
                columns: new[] { "CategoryId", "CategoryName", "CategoryPicture" },
                values: new object[,]
                {
                    { 1, "Clothes", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854127/cat-1_veobee.jpg" },
                    { 2, "Household", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-2_thblkg.jpg" },
                    { 3, "Electronic", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-3_dvyjbe.jpg" },
                    { 4, "Beauty", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/cat-4_ymnplq.jpg" },
                    { 5, "Book", "https://res.cloudinary.com/dddvmxs3h/image/upload/w_150,h_150/v1666854128/cat-5_ijcxzw.jpg" },
                    { 6, "Pet", "https://res.cloudinary.com/dddvmxs3h/image/upload/w_150,h_150/v1666854128/cat-6_s3afnw.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserAddress", "UserName" },
                values: new object[,]
                {
                    { "190798a2-3bca-41ed-900b-5cbb5cf887fe", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "a93483a6-f69c-414a-8488-c2ba4ec306d5", "user10@gmail.com", false, "user", "10", false, null, "USER10@GMAIL.COM", "USER10", "AQAAAAEAACcQAAAAEEwEexHQGABFovo0YpY1wwYnBw8LIqkTnAEUBr2knGuUWZXUPfv6koJVqjkH6Hbcyw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "8be08fce-8553-4dbe-98ab-4a333f5d49b9", false, "sdfasdfsadf", "user10" },
                    { "3c694a27-7370-4d5c-b2ab-4691781a962e", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "90d6c87c-3914-4a8c-aa72-45defebcdf83", "user1@gmail.com", false, "user", "1", false, null, "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAECO7mwbg2G2zgePhufIkhB4ITzky5DoxWEIbEJC7ckK+TNE3vc1pPLn5ykwYIPlXcw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "4c943b5a-5ed3-4fed-bfdf-5d45ec4e63ed", false, "sdfasdfsadf", "user1" },
                    { "5280207b-f2a9-4213-9eb9-b04dea95382b", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "1012e64e-6cf5-4960-a73d-9fd26d5280ef", "user3@gmail.com", false, "user", "3", false, null, "USER3@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEAoV1jmLMU41UVk5XWHyL3J3XlomtKTbaNSoMBcFGfoJcWSvHffRtcwxrF1LW4cg4Q==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "0bab1488-866b-4c0f-9549-c6aa87b17c77", false, "sdfasdfsadf", "user3" },
                    { "8e4b75ab-66a5-4b07-bdb5-686c0c47a456", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "8f0e4408-ce01-4b7a-8799-049587aa11b0", "user8@gmail.com", false, "user", "8", false, null, "USER8@GMAIL.COM", "USER8", "AQAAAAEAACcQAAAAEJY+VuMhrNvr5ubSShfqrTUaPDDcCL0yus7N6sUp/EmxHPDMIiZAfJOgzDPsEwnWgg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "0e5b6fba-8c05-4f89-bd3a-0c0bdd7aa88e", false, "sdfasdfsadf", "user8" },
                    { "b2bee929-29cd-4daa-9c52-a80d41e619b1", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "26402a4b-1926-4073-ae9e-e4f22138b43a", "user7@gmail.com", false, "user", "7", false, null, "USER7@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAENwMqTXOYc8LDkAd94cu2666aUHDRw0rUDplg4irk0Kf6UuHenKuAXsZ7d/f4nj6qg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "ecf978c9-b121-489a-b0d7-3019dbb1c28a", false, "sdfasdfsadf", "user7" },
                    { "b4ce6b27-1a85-4ab4-8671-8d96e5a34237", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "81810d60-0eef-485d-a995-7e63901555a4", "user6@gmail.com", false, "user", "6", false, null, "USER6@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAEArrbjWoVMgF0HvAU9pnv0AtES7YwvcHnif+RuW7zzBgySde2bQBYfynVueOF78iQg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "31b6ffdb-1a5e-4686-b0c0-550897dc52c7", false, "sdfasdfsadf", "user6" },
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "58cda364-6699-4fec-8357-87d0b29d2fd3", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEMbML7E/bDpe8j71t+wl2nOcK4hNqurOgesyIV61YDKywla5Jhw3d6xadr67TCjTJg==", "1234567890", false, "fab4fac1-c546-41de-aebc-a14da6895711", "39786a22-27d0-469a-851b-5963fac7cf2b", false, "sdfasdfsadf", "admin" },
                    { "beddceb2-5f78-48dc-998b-0f35c417316c", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "dcf3bafe-0e65-43a7-8086-abd02f92a4a2", "user4@gmail.com", false, "user", "4", false, null, "USER4@GMAIL.COM", "USER4", "AQAAAAEAACcQAAAAEHl33hn1I9vL2T2h9k1AF2HosYEuaTrP0a0g0W3LhBn52IGVTLYImRXhxuzjv8QO1w==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "f3979c27-1069-4a47-a28c-0d8071d822f9", false, "sdfasdfsadf", "user4" },
                    { "dc4fb99a-1a48-4c47-bb32-23828aa9a6bf", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "1bda72e3-36a8-47a6-8051-b2d313b3d2c7", "user2@gmail.com", false, "user", "2", false, null, "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEDvj21PeUlrFanw0ots4X60oK+sWyeCYtvdkPzeGoYjyR6O1HNB8+jBJLZjVIUGZKA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "ca986cb9-4153-4848-ad39-46fa878d86f2", false, "sdfasdfsadf", "user2" },
                    { "f0d5c67a-90ff-4761-bd2b-82eae810492f", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "aa252801-d8e6-4d29-b53f-15f150301d0e", "user9@gmail.com", false, "user", "9", false, null, "USER9@GMAIL.COM", "USER9", "AQAAAAEAACcQAAAAEE2LosNGCd8HVlWlQ3V8IzCcIHUfvbxUuTs6snk6D8+AM07Eq8A7WJgRSMwnJ+cAPw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "44ddc8c3-681e-4ae6-97b6-1fd22d3d180f", false, "sdfasdfsadf", "user9" },
                    { "fbe9f6e0-2e70-4a58-a8e4-425aba2b8921", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "7e43085d-2638-4c1b-b767-d4c5c8db95b5", "user0@gmail.com", false, "user", "0", false, null, "USER0@GMAIL.COM", "USER0", "AQAAAAEAACcQAAAAEKtmXmbt9wVawhLObAq8eUNODrZE8KQZqgwboSpvj7wPsSRQpdVBqkwblMUCkvFl+g==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "827b49df-5ce8-4a8c-999f-beb2cb490353", false, "sdfasdfsadf", "user0" },
                    { "fe5dcf62-cf3f-4da0-986c-f7d4e060010e", 0, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "402da61b-5a14-4666-a8dc-3f829fa9235c", "user5@gmail.com", false, "user", "5", false, null, "USER5@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAEJbJ94j1jHCafYWf6E+c6yNKQbNY4tOQlloO3Rz+W17A0x924AhO3IZ0XGGKHt9ZUg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "943b5e1c-a432-4e06-b08f-cd860f741430", false, "sdfasdfsadf", "user5" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateDate", "Description", "Price", "ProductName", "ProductPicture", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4546), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 2000.0, "Product 1", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-1_iyqgel.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4557) },
                    { 2, 4, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 2000.0, "Product 2", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-2_wds2xq.jpg", new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 1, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4589), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 10000.0, "Product 3", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-3_ysbo6f.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4589) },
                    { 4, 1, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4598), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 10000.0, "Product 4", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-4_w2yb1f.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4599) },
                    { 5, 1, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4608), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 10000.0, "Product 5", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-5_nhbfgf.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4609) },
                    { 6, 1, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4619), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 10000.0, "Product 6", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-6_rsti5j.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4620) },
                    { 7, 1, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4629), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 10000.0, "Product 7", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-7_ykpjce.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4630) },
                    { 8, 3, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4639), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 2300.0, "Product 8", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-8_wu5jzf.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4639) },
                    { 9, 3, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4650), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 2300.0, "Product 9", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-9_pik3wm.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4650) },
                    { 10, 3, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4661), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 2300.0, "Product 10", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-10_buoi29.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4661) },
                    { 11, 3, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4672), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 2300.0, "Product 11", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-11_zpxzs7.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4672) },
                    { 12, 2, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4681), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 30000.0, "Product 12", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-12_s0abhz.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4682) },
                    { 13, 2, new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4692), "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", 30000.0, "Product 13", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-13_p3fpxz.jpg", new DateTime(2022, 11, 1, 16, 37, 45, 168, DateTimeKind.Local).AddTicks(4692) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

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
