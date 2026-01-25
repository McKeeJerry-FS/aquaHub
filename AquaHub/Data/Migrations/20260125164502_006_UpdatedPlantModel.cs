using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class _006_UpdatedPlantModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanBePropagated",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommonIssues",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LightingRequirement",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaxHeight",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NitrateAbsorber",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OxygenProducer",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantType",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant_CareLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant_Coloration",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant_HardnessRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Plant_OptimalTemperatureMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Plant_OptimalTemperatureMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant_Placement",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant_SpecialRequirements",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant_pHRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropagationMethod",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresCO2",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresFertilization",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresRootTabs",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafeForShrimp",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SafeForSnails",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubstrateRequirement",
                table: "Livestock",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "CanBePropagated",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "CommonIssues",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "LightingRequirement",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "MaxHeight",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "NitrateAbsorber",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "OxygenProducer",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "PlantType",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_CareLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_Coloration",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_HardnessRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_OptimalTemperatureMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_OptimalTemperatureMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_Placement",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_SpecialRequirements",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_pHRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "PropagationMethod",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresCO2",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresFertilization",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresRootTabs",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SafeForShrimp",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SafeForSnails",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SubstrateRequirement",
                table: "Livestock");
        }
    }
}
