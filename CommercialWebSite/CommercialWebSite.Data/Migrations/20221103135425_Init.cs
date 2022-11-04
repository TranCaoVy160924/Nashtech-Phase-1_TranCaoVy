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
                    { "00f6ad9a-ce4d-4164-aacb-357b31f6d9c6", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "5cabc6a3-77db-4fe6-8a85-8c6de98a78c1", "user7@gmail.com", false, "user", "7", false, null, "USER7@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAEDD0pU4KYABH66B2QG1wisCjW4VpAwkOGXdAvE+MRkTx7jkAubdXqr25drNK6/tYUw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "0d5d9774-622f-4cec-8e8b-8dde86760aed", false, "sdfasdfsadf", "user7" },
                    { "47115085-57a7-4529-98ac-d12ac91a3f4e", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "18a3a1d3-8852-4a01-b259-15a0ffe5a58e", "user5@gmail.com", false, "user", "5", false, null, "USER5@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAEMYZJW8HI7950aaMX40E3xJJ5zHqHAPCjIq3o4a6Yrka7d9d/jbIIgY8fYEpcaPDfA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "7cc7fc4c-ef28-478a-9ede-e16cab1f7706", false, "sdfasdfsadf", "user5" },
                    { "5379f1eb-3a07-4d1d-95d7-dec1e6e3b5d9", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "2f496feb-cd26-4f98-b7fe-33475a6d35ea", "user4@gmail.com", false, "user", "4", false, null, "USER4@GMAIL.COM", "USER4", "AQAAAAEAACcQAAAAEAuiOF+WkvQGURMbs207zfaqDhIv/d7F3N5p2ReI0CN67xKywh3Xj9Zj9hfEY6tGWw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "30c6bb32-c74c-425b-b284-20f57441b55f", false, "sdfasdfsadf", "user4" },
                    { "75cd2603-9f70-416c-b8d6-0b7dd1c235bd", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "777eeebf-3b6d-480d-9fdf-494552fbd428", "user0@gmail.com", false, "user", "0", false, null, "USER0@GMAIL.COM", "USER0", "AQAAAAEAACcQAAAAEMIXHsD9vGs8sNVdfeGHrp35rVckXi50HvMIYcq7uQ7UcB0kxL4s0uygvoqpCJTa5A==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "5c5e8913-5742-48b7-9626-487f1ebe13ec", false, "sdfasdfsadf", "user0" },
                    { "8c344b68-70ec-4ef6-b8f1-b2d523ecc110", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "4431b15c-de6c-4388-888f-6c0ab26fb091", "user6@gmail.com", false, "user", "6", false, null, "USER6@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAEEGrVVcs6JybZRGuR2Pl2hY5ZOsh3httfZV2vA25l5+7stytaNssV+sqpIwER0WONA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "3725cbe9-a651-4fb2-943d-31801eb025e1", false, "sdfasdfsadf", "user6" },
                    { "a59ee87f-20b9-4479-8494-be63ee1993e1", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "c00ce3c0-9798-438a-810c-3fb4d9bb0c9b", "user9@gmail.com", false, "user", "9", false, null, "USER9@GMAIL.COM", "USER9", "AQAAAAEAACcQAAAAEK0MAsfZv/B0WeP7EafZwQakQiJwmGT/LbX+97Zmmf3hWoM1A0M+v68aVw2tbwixIA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "9549ac28-3437-48c6-b6ca-88a09768c291", false, "sdfasdfsadf", "user9" },
                    { "a8bab3d0-b952-498a-bb19-d808eaec10d5", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "95b4807a-984a-4b53-81c8-ef4230c07502", "user2@gmail.com", false, "user", "2", false, null, "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEPNzZhr/zMCdTgXLxTRSHrfo71Lt3VRU+tj6T98CP3xP19Go7Jy9ty0dA42vbGNHfw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "4e103a48-9309-4c55-81ef-1bc8d491cd6d", false, "sdfasdfsadf", "user2" },
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "70e96617-5992-469d-a7cc-64638fc0d4f1", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEC48cfN4SufDwDFTF0kbfqEcwjH4eRz7nKQ/8nCDLDp5P4fCOvUQPfWNX9IOp7oOyQ==", "1234567890", false, "fab4fac1-c546-41de-aebc-a14da6895711", "1731a4bb-094b-4333-8937-790ed2e9c8bc", false, "sdfasdfsadf", "admin" },
                    { "be4b86d9-359c-447d-b408-c7c76593850e", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "18a48adf-48d8-4d26-831b-3e9fc4fc38d8", "user3@gmail.com", false, "user", "3", false, null, "USER3@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEJyHV+jL1foc4csCjFkL5TYdSzvOQ+djSDwP/HyO2sqXeES2dfdH9i+Sh3PDZShxLQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "46bd50b1-009d-4c74-92f6-d744b8007633", false, "sdfasdfsadf", "user3" },
                    { "c79934ff-f4f1-4443-bd29-ed893a283c11", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "11771d21-c303-4719-8896-3d25b2fadec1", "user1@gmail.com", false, "user", "1", false, null, "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEMhPAM7LcgmQE0Krz0np4nl5rUQt4LwFnChsH262nBjuasW3nKGIKEMmIS1dYIJnsA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "21b4c2b2-64a1-4777-9740-5667d60da60d", false, "sdfasdfsadf", "user1" },
                    { "c7a92238-0ed6-4bc6-ad27-93354628697a", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "6119b271-96a8-473a-9a6b-d10bde5853da", "user10@gmail.com", false, "user", "10", false, null, "USER10@GMAIL.COM", "USER10", "AQAAAAEAACcQAAAAEDQsRiExvLPrrctCPNX6CBS1AzSFOIpy6H5ageYGPDVG7wGeSfNVkFPzf37R/O06qQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "4514f764-7599-4221-9e69-0fe591a3e02f", false, "sdfasdfsadf", "user10" },
                    { "d635f4ce-b353-4920-82d5-1c3c22a5c5f0", 0, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Local), "7ca3feac-f6fa-4cfa-97cd-57a17d520ee9", "user8@gmail.com", false, "user", "8", false, null, "USER8@GMAIL.COM", "USER8", "AQAAAAEAACcQAAAAECdC9000ctImDEawmkg8aIBC6Sz3N0Fzj35Kz1AH71+5XhU/DXZWCZeOL1ZEvZR2+Q==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "f1629ac2-dd55-4593-bdc5-6a90d9abeca3", false, "sdfasdfsadf", "user8" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "ProductPicture", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 4, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 1", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-1_iyqgel.jpg", "11/03/2022 8:54 PM" },
                    { 2, 4, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 2", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-2_wds2xq.jpg", "11/03/2022 8:54 PM" },
                    { 3, 1, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 3", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-3_ysbo6f.jpg", "11/03/2022 8:54 PM" },
                    { 4, 1, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 4", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-4_w2yb1f.jpg", "11/03/2022 8:54 PM" },
                    { 5, 1, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 5", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-5_nhbfgf.jpg", "11/03/2022 8:54 PM" },
                    { 6, 1, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 6", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-6_rsti5j.jpg", "11/03/2022 8:54 PM" },
                    { 7, 1, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 7", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-7_ykpjce.jpg", "11/03/2022 8:54 PM" },
                    { 8, 3, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 8", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-8_wu5jzf.jpg", "11/03/2022 8:54 PM" },
                    { 9, 3, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 9", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-9_pik3wm.jpg", "11/03/2022 8:54 PM" },
                    { 10, 3, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 10", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-10_buoi29.jpg", "11/03/2022 8:54 PM" },
                    { 11, 3, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 11", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-11_zpxzs7.jpg", "11/03/2022 8:54 PM" },
                    { 12, 2, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 12", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-12_s0abhz.jpg", "11/03/2022 8:54 PM" },
                    { 13, 2, "11/03/2022 8:54 PM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 13", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-13_p3fpxz.jpg", "11/03/2022 8:54 PM" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "BuyerId", "IsCheckedOut", "NumOfGood", "ProductId" },
                values: new object[,]
                {
                    { 1, "b74ddd14-6340-4840-95c2-db12554843e5", false, 2, 1 },
                    { 2, "b74ddd14-6340-4840-95c2-db12554843e5", true, 2, 2 },
                    { 3, "b74ddd14-6340-4840-95c2-db12554843e5", false, 2, 3 },
                    { 4, "b74ddd14-6340-4840-95c2-db12554843e5", true, 2, 4 },
                    { 5, "b74ddd14-6340-4840-95c2-db12554843e5", false, 2, 5 },
                    { 6, "b74ddd14-6340-4840-95c2-db12554843e5", true, 2, 6 },
                    { 7, "b74ddd14-6340-4840-95c2-db12554843e5", false, 2, 7 },
                    { 8, "b74ddd14-6340-4840-95c2-db12554843e5", true, 2, 8 },
                    { 9, "b74ddd14-6340-4840-95c2-db12554843e5", false, 2, 9 }
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
