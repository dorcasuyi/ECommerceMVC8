using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class updateItemCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ItemCarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ItemCarts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductName",
                value: "Product 1");

            migrationBuilder.UpdateData(
                table: "ItemCarts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductName",
                value: "Product 2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ItemCarts");
        }
    }
}
