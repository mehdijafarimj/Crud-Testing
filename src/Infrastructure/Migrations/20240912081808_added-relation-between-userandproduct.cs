using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedrelationbetweenuserandproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserProductId",
                table: "Products",
                column: "UserProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserProductId",
                table: "Products",
                column: "UserProductId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserProductId",
                table: "Products");
        }
    }
}
