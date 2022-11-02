using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmaranthOnlineShop.Infrastructure.Persistence.Migrations
{
    public partial class UserIdInOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderDetails");
        }
    }
}
