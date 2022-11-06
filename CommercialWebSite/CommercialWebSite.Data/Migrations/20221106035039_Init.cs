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
                    { "03b276fd-7eb1-48f0-8aa3-e584609d354a", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "5b5e6966-6fa1-4c19-b87a-7204bc471d44", "user4@gmail.com", false, "user", "4", false, null, "USER4@GMAIL.COM", "USER4", "AQAAAAEAACcQAAAAENRW7IL0IL2aBC/cI5GlOCBD18zC2p8aO1kjSLTES3nUp2jPgEzjO82Un4N1WE81LQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "07b3d00b-50cd-44b5-a7a8-8c6be3c030af", false, "sdfasdfsadf", "user4" },
                    { "135d1eee-3644-42b1-9c63-163d016bc2bd", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "9f311681-9057-4773-bb09-64c589ccb58b", "user7@gmail.com", false, "user", "7", false, null, "USER7@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAEKA5Y8xJwQv3yz/vvknDoB6Af2wEGB/30vrWEAYytoTnj1oW89h7CiZpbnI6nOt7JQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "4cc3348e-b0b2-4631-9185-30231e396146", false, "sdfasdfsadf", "user7" },
                    { "489af7e6-3f5e-44d7-ab93-a24f475e5c89", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "255615e8-4dbf-456b-af25-83e8cea2a8fe", "user1@gmail.com", false, "user", "1", false, null, "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEOJQ4/I0ilqTLJjw3kQKlPKzUWBxf1bDk9W8KJIR+7worEKjzapmHS96E1tix7Z23g==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "c053b099-e112-40e7-bb16-2519c091b15d", false, "sdfasdfsadf", "user1" },
                    { "84c1d15b-7560-4dab-8223-91d3d0edf345", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "a7264426-453d-4529-a754-7ae984767cba", "user6@gmail.com", false, "user", "6", false, null, "USER6@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAEGg9oIZbVEhHMlZlw2O2mv3mSkFgPYhRB/8oQAfNZyVZ3Ur5yAOjE1e1v+VFR9QPXg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "3e92377c-de60-491f-bc6c-4aae406598fe", false, "sdfasdfsadf", "user6" },
                    { "8cacfc1f-bdfc-4850-9105-cf183ac4e012", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "faa62e0c-bd7e-4bd5-99ec-2148a242e854", "user8@gmail.com", false, "user", "8", false, null, "USER8@GMAIL.COM", "USER8", "AQAAAAEAACcQAAAAECUPnB5gIqzmtqnuU7yMwwpVAEsByqRQ13arriPvpc9QQ+ExvKDMIElo9BGq5e/Z1Q==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "ac8bbf4f-0ee8-4dba-bf29-4d2b10dcd7af", false, "sdfasdfsadf", "user8" },
                    { "b1d45aba-d5c9-44cc-956a-6540cf6ef53c", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "eb6b63c4-792b-4230-92ea-6965640b2f8e", "user0@gmail.com", false, "user", "0", false, null, "USER0@GMAIL.COM", "USER0", "AQAAAAEAACcQAAAAEFIdkS+RZMfJyrgjDMn5wQR3HFdK+Y+5sYzwJLGa93cwpOpYtbmQ4h7RZaxJR7ynaQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "cafc3569-a5d8-4b94-b30e-1523d94228cd", false, "sdfasdfsadf", "user0" },
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "708c2c54-14ae-4bb7-b91b-395cf1fb11fa", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEA3JgOkXvgKMqJ0upjmKnBAwmkTvRsXr6IYzxYNo9dYWcp2WmREOgAjp/7UOADN2Aw==", "1234567890", false, "fab4fac1-c546-41de-aebc-a14da6895711", "70000ee8-f31f-4a70-8932-30902f0ee6b4", false, "sdfasdfsadf", "admin" },
                    { "c306005f-e6fc-45a5-b375-8588696426ab", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "5c41ff74-47e7-4a8f-a3ce-8d4ec701d5e5", "user10@gmail.com", false, "user", "10", false, null, "USER10@GMAIL.COM", "USER10", "AQAAAAEAACcQAAAAEEijUBw/Px+ZVy4VEcrR3rd05x01aTzhEAIIugJf2jXWDfVCfWnhSztnNZBflXrR2w==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "bd9e725c-5725-43b8-9384-19cfa14d6103", false, "sdfasdfsadf", "user10" },
                    { "c8bbb3c1-7ad8-4a90-9a26-0008ce6e26a1", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "771a1fa9-bac4-4ff1-a59b-a52291361019", "user5@gmail.com", false, "user", "5", false, null, "USER5@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAECnWDfjVRh7oDWHb+rnagv6+XnHyZE3uk28pS0pB0gmZcHGg18AXg38MewwivSpE5w==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "ebc2cff1-5e54-48a7-a901-b155d882cc68", false, "sdfasdfsadf", "user5" },
                    { "d1be8045-e153-48aa-86a3-c644c380236f", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "7b7c3906-b68a-4b2a-bb75-5c2656f94e0e", "user2@gmail.com", false, "user", "2", false, null, "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEP3Mx/Mp9bhBr4fT5fmwLw7pYg2b9wjGUxN351gjMOLLzZ5gY3jf5JkLIjXt73g7Iw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "b00505e1-aafc-4433-9912-396c7375ce54", false, "sdfasdfsadf", "user2" },
                    { "e2e871f7-c900-4204-834f-eb8ee4cc1493", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "7cb22e7f-41e9-4b52-8ddb-1c0b37c1c32e", "user3@gmail.com", false, "user", "3", false, null, "USER3@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEO44G2bNpcErCteHeT2P8wj1KClo4DF6lt9hxsGWZZGYafqqD4KescBMWYq6s+s/TA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "a5387f07-4120-4d06-9734-e5fff0cbc447", false, "sdfasdfsadf", "user3" },
                    { "f69f1fff-dfc7-4e85-8bfa-358e20ef4dd7", 0, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Local), "6d941996-7402-40e2-84a6-4aa01d6a4f54", "user9@gmail.com", false, "user", "9", false, null, "USER9@GMAIL.COM", "USER9", "AQAAAAEAACcQAAAAEL2nj4+aEqA4+9FEvOWmIXG/I40aRHCqe9cop8npWURrosrp+e+YitKwsIaL1kiCEw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "e4af952b-68d8-4876-92a3-b57d9538de80", false, "sdfasdfsadf", "user9" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "ProductPicture", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 4, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 1", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-1_iyqgel.jpg", "11/06/2022 10:50 AM" },
                    { 2, 4, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 2", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-2_wds2xq.jpg", "11/06/2022 10:50 AM" },
                    { 3, 1, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 3", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-3_ysbo6f.jpg", "11/06/2022 10:50 AM" },
                    { 4, 1, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 4", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-4_w2yb1f.jpg", "11/06/2022 10:50 AM" },
                    { 5, 1, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 5", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-5_nhbfgf.jpg", "11/06/2022 10:50 AM" },
                    { 6, 1, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 6", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-6_rsti5j.jpg", "11/06/2022 10:50 AM" },
                    { 7, 1, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 7", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-7_ykpjce.jpg", "11/06/2022 10:50 AM" },
                    { 8, 3, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 8", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-8_wu5jzf.jpg", "11/06/2022 10:50 AM" },
                    { 9, 3, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 9", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-9_pik3wm.jpg", "11/06/2022 10:50 AM" },
                    { 10, 3, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 10", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-10_buoi29.jpg", "11/06/2022 10:50 AM" },
                    { 11, 3, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 11", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-11_zpxzs7.jpg", "11/06/2022 10:50 AM" },
                    { 12, 2, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 12", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-12_s0abhz.jpg", "11/06/2022 10:50 AM" },
                    { 13, 2, "11/06/2022 10:50 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 13", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-13_p3fpxz.jpg", "11/06/2022 10:50 AM" }
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
