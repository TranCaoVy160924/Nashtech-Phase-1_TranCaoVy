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
                    { "06277a56-f91a-4bf0-a690-73dd77bc9abc", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "165e95d3-d0e7-405c-b3d8-52603cbd84b7", "user5@gmail.com", false, "user", "5", false, null, "USER5@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAED0GD+K701umjwR3omRIOUO9vXciVrCgJaUcEW4pSdEkYFcu+sLoHZCCqQWcdfy16A==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "6cabb96c-acc1-492d-bfab-02b94099d691", false, "sdfasdfsadf", "user5" },
                    { "2374a79e-73d2-4977-a94e-5c6cd87a7891", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "01433992-51d5-48b2-82ef-705a84d1a0c5", "user3@gmail.com", false, "user", "3", false, null, "USER3@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEHBlMcXnPF0pZX1w7EG0khtOYEVeXMmb3dKfL8SSt7RkYpJqhS97ZCgY+0IuJbvHLg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "4108e5d8-ff5e-4a50-b6c3-4aa477e2d8f1", false, "sdfasdfsadf", "user3" },
                    { "2892fb6e-c23c-4694-8344-55779c5ad511", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "203d3f69-bbe4-4e13-9ae6-c88fc449a780", "user2@gmail.com", false, "user", "2", false, null, "USER2@GMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEPraO0m+QYsZlIBFAKPmdsnwP5dpGJ4kf9ZNBXI1uA+mL8e9n2ZqGYHvugOQwkI3ZQ==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "8e0bd027-5c23-42cb-8c11-aeba3951cf69", false, "sdfasdfsadf", "user2" },
                    { "3940fab0-aaa9-4913-ae21-9c2915ab77d5", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "4b5e0f81-be35-4cb6-bedf-8bde34a3fb07", "user6@gmail.com", false, "user", "6", false, null, "USER6@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAEGNAJFxIHmIwlB1RfOgmhvM4WqWhlQEW422blWloKYNR6nKVtLEoPFnchoJtdfYDpg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "a928c4e9-be10-4af1-b0b2-2b86cf19e58c", false, "sdfasdfsadf", "user6" },
                    { "4d41151b-3c7c-4101-81fb-99d00ab884c0", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "cf757900-6362-4cdf-af0e-b0c1812fb2bb", "user8@gmail.com", false, "user", "8", false, null, "USER8@GMAIL.COM", "USER8", "AQAAAAEAACcQAAAAEGDzd6ANiEMHVx9oohKfQ9xmuqM2YV32dKPEi2TmoJHELCOs8/FHWE5qvn4bu4SZtA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "80e46ed2-ed9d-4112-8909-842d438e8515", false, "sdfasdfsadf", "user8" },
                    { "7a33a9f6-98ca-4dc2-bbce-da4474c5ec32", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "4d29aeea-5070-411e-8f18-4cf877cbea7f", "user7@gmail.com", false, "user", "7", false, null, "USER7@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAEPDjwVJB31ItPR6g2tevFgXsy7KSNxdlDxyx/HJvapLS9KQRIRyFVqYAkJVvggTHjw==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "b1633951-0188-4058-ba15-47eeae753cc3", false, "sdfasdfsadf", "user7" },
                    { "83ca93da-b52c-4c8c-84d8-a03ef72eb0c0", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "ac63bac0-cbec-4d81-95eb-82ac4fb2de5e", "user10@gmail.com", false, "user", "10", false, null, "USER10@GMAIL.COM", "USER10", "AQAAAAEAACcQAAAAEJ9NmFY2JOcAwC3B+7VZ9Sf6AuJm9e/x6x+c//43EWPCU7LzdO6qbUhwCNR7VI0nkA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "72b334a2-cb9a-4e14-b964-970fe249aa29", false, "sdfasdfsadf", "user10" },
                    { "a5d5f27e-61fa-40b0-97d2-a41763bcc919", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "78b17d06-4fce-4c89-87cc-f707d079fc18", "user0@gmail.com", false, "user", "0", false, null, "USER0@GMAIL.COM", "USER0", "AQAAAAEAACcQAAAAEFNtfz/ljmoQ+dw8xFSpo7fkt71fuyJh3rxvsIWnO6DLe/eE1nYb3lHzHesEmAzZ9A==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "73dbff83-8355-4669-9d62-cc97287adf3b", false, "sdfasdfsadf", "user0" },
                    { "b74ddd14-6340-4840-95c2-db12554843e5", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "54ec052c-696b-483a-840d-b9a6213ee3ef", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEL4SXfZ//5fE1R3iuCwQ/U5Ou5SPKm5u35QAsbm1YrWdAitsv9lN+1kbdLhhRks9fA==", "1234567890", false, "fab4fac1-c546-41de-aebc-a14da6895711", "963be52d-f948-493e-a917-836867a18a2c", false, "sdfasdfsadf", "admin" },
                    { "bccb83e5-bfda-43eb-bd4a-28b9ae25c209", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "248d6f6c-8b1b-4760-8ea2-5b1e6d86c7de", "user9@gmail.com", false, "user", "9", false, null, "USER9@GMAIL.COM", "USER9", "AQAAAAEAACcQAAAAEDnYKy4XBjh1KHiB8RhyDvO8Zje3vO2sIefl6JpLTKIeET3TXoHGz8q04Z/IOMExUg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "c8118e89-a687-4ae7-bbbb-808463e35d3f", false, "sdfasdfsadf", "user9" },
                    { "e75f0b6e-e98e-4ddf-8f68-963a2ecd4228", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "2ef61ed1-abd7-44ce-bcc3-37b23dc6e192", "user1@gmail.com", false, "user", "1", false, null, "USER1@GMAIL.COM", "USER1", "AQAAAAEAACcQAAAAEC2uKrP5WtSc/qZvImWDYy4e0o5sqz1PTwGnYlc/otIisgiUKSDGv3Fd43wrHGgZmA==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "ae80bee4-2794-45dd-959f-a3e60f11afb8", false, "sdfasdfsadf", "user1" },
                    { "fecc1961-76ca-405b-957f-1a84de8351c0", 0, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Local), "93a7409c-658b-460b-8086-81c044154d5a", "user4@gmail.com", false, "user", "4", false, null, "USER4@GMAIL.COM", "USER4", "AQAAAAEAACcQAAAAEH5nUCFbDnxV6ggxAuljRozSUyal90HyJ0BPXnYeK6bDz8s2tPjbnvVVRK4goffwxg==", "1234567890", false, "c7b013f0-5201-4317-abd8-c211f91b7330", "3ddefacf-6622-4307-8938-e9096437ac20", false, "sdfasdfsadf", "user4" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "ProductPicture", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 4, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 1", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-1_iyqgel.jpg", "11/08/2022 9:14 AM" },
                    { 2, 4, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2000.0, "Product 2", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-2_wds2xq.jpg", "11/08/2022 9:14 AM" },
                    { 3, 1, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 3", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-3_ysbo6f.jpg", "11/08/2022 9:14 AM" },
                    { 4, 1, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 4", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-4_w2yb1f.jpg", "11/08/2022 9:14 AM" },
                    { 5, 1, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 5", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-5_nhbfgf.jpg", "11/08/2022 9:14 AM" },
                    { 6, 1, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 6", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-6_rsti5j.jpg", "11/08/2022 9:14 AM" },
                    { 7, 1, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 10000.0, "Product 7", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-7_ykpjce.jpg", "11/08/2022 9:14 AM" },
                    { 8, 3, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 8", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-8_wu5jzf.jpg", "11/08/2022 9:14 AM" },
                    { 9, 3, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 9", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854129/product-9_pik3wm.jpg", "11/08/2022 9:14 AM" },
                    { 10, 3, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 10", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-10_buoi29.jpg", "11/08/2022 9:14 AM" },
                    { 11, 3, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 2300.0, "Product 11", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-11_zpxzs7.jpg", "11/08/2022 9:14 AM" },
                    { 12, 2, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 12", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-12_s0abhz.jpg", "11/08/2022 9:14 AM" },
                    { 13, 2, "11/08/2022 9:14 AM", "Open your door to the world of grilling with the sleek Spirit II E-210 gas grill. This two burner grill is built to fit small spaces, and packed with features such as the powerful GS4 grilling system, iGrill capability, and convenient side tables for placing serving trays. Welcome to the Weber family.", true, 30000.0, "Product 13", "https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854130/product-13_p3fpxz.jpg", "11/08/2022 9:14 AM" }
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
                    { 4, "b74ddd14-6340-4840-95c2-db12554843e5", true, true, 2, 4 },
                    { 5, "b74ddd14-6340-4840-95c2-db12554843e5", true, false, 2, 5 },
                    { 6, "b74ddd14-6340-4840-95c2-db12554843e5", true, true, 2, 6 },
                    { 7, "b74ddd14-6340-4840-95c2-db12554843e5", true, false, 2, 7 },
                    { 8, "b74ddd14-6340-4840-95c2-db12554843e5", true, true, 2, 8 },
                    { 9, "b74ddd14-6340-4840-95c2-db12554843e5", true, false, 2, 9 }
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
