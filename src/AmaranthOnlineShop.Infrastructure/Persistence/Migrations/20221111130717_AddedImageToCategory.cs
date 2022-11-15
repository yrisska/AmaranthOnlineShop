using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmaranthOnlineShop.Infrastructure.Persistence.Migrations
{
    public partial class AddedImageToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUri",
                value: "https://yrisska.blob.core.windows.net/images/category1.jpg");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUri",
                value: "https://yrisska.blob.core.windows.net/images/category2.webp");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUri",
                value: "https://yrisska.blob.core.windows.net/images/category3.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "ProductCategories");
        }
    }
}
