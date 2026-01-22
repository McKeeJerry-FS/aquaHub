using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class _003_AddUserIdToTank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tanks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_UserId",
                table: "Tanks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_AspNetUsers_UserId",
                table: "Tanks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_AspNetUsers_UserId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_UserId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tanks");
        }
    }
}
