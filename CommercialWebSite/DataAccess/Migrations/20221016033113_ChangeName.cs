using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_BuyerId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Goods_ProductId",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ProductId",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_BuyerId",
                table: "Orders",
                newName: "IX_Orders_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Goods_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Goods",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_BuyerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Goods_ProductId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Receipts");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Receipts",
                newName: "IX_Receipts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BuyerId",
                table: "Receipts",
                newName: "IX_Receipts_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_BuyerId",
                table: "Receipts",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Goods_ProductId",
                table: "Receipts",
                column: "ProductId",
                principalTable: "Goods",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
