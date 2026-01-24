using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class _004_AddHeatersToEquipmet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaxTemperature",
                table: "Equipment",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinTemperature",
                table: "Equipment",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "Equipment");
        }
    }
}
