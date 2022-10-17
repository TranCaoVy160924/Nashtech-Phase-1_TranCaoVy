using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeGoodToPruduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Categories_CategoryId",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Goods_ProductId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goods",
                table: "Goods");

            migrationBuilder.RenameTable(
                name: "Goods",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Goods_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Goods");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Goods",
                newName: "IX_Goods_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goods",
                table: "Goods",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Categories_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Goods_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Goods",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
