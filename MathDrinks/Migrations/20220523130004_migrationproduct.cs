using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathDrinks.Migrations
{
    public partial class migrationproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Product_ProductId",
                table: "Supplier_Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Product_SupplierId",
                table: "Supplier_Product",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Product_Product_ProductId",
                table: "Supplier_Product",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Product_Supplier_SupplierId",
                table: "Supplier_Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Product_Product_ProductId",
                table: "Supplier_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Product_Supplier_SupplierId",
                table: "Supplier_Product");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_Product_ProductId",
                table: "Supplier_Product");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_Product_SupplierId",
                table: "Supplier_Product");
        }
    }
}
