using Microsoft.EntityFrameworkCore.Migrations;

namespace LBCOnlineShoppingCart.Infra.Data.Migrations
{
    public partial class StoreAndAdminKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Admin_StoreId",
                table: "Admin",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Store_StoreId",
                table: "Admin",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Store_StoreId",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_StoreId",
                table: "Admin");
        }
    }
}
