using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_OnlineShops_CategoryId",
                table: "Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnlineShops",
                table: "OnlineShops");

            migrationBuilder.RenameTable(
                name: "OnlineShops",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_Categories_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_Categories_CategoryId",
                table: "Goods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "OnlineShops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnlineShops",
                table: "OnlineShops",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_OnlineShops_CategoryId",
                table: "Goods",
                column: "CategoryId",
                principalTable: "OnlineShops",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
