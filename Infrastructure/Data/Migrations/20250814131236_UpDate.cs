using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tVariantMarketplaces_ProductVariants_ProductVariantId",
                table: "tVariantMarketplaces");

            migrationBuilder.RenameColumn(
                name: "ProductVariantId",
                table: "tVariantMarketplaces",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CustomUserIdentity",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tVariantMarketplaces_Products_ProductId",
                table: "tVariantMarketplaces",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "kProductId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tVariantMarketplaces_Products_ProductId",
                table: "tVariantMarketplaces");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CustomUserIdentity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "tVariantMarketplaces",
                newName: "ProductVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_tVariantMarketplaces_ProductVariants_ProductVariantId",
                table: "tVariantMarketplaces",
                column: "ProductVariantId",
                principalTable: "ProductVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
