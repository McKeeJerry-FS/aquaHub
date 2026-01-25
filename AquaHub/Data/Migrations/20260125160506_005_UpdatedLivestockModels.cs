using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquaHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class _005_UpdatedLivestockModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Livestock",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<string>(
                name: "ActivityLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AdultSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AggressionMethod",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AggressiveToOtherFish",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AggressiveToSameSpecies",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AggressiveTowardsOwnSpecies",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlkalinityRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AverageLifespanYears",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Behavior",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyShape",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreedingDifficulty",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreedingNotes",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreedingType",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalciumRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanBeFragged",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CareLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ColonySize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coloration",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommonDiseases",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoralFamily",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_CareLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_Coloration",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_CommonDiseases",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_FeedingFrequency",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_FoodTypes",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Coral_OptimalTemperatureMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Coral_OptimalTemperatureMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_Placement",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Coral_RequiresAcclimation",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_SpecialRequirements",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coral_pHRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diet",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DosingRequirements",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EatsShrimp",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EatsSmallFish",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EatsSnails",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedingBehavior",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedingFrequency",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FishType",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlowType",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodTypes",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FraggingDifficulty",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FraggingMethod",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FraggingNotes",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreshwaterFish_AdultSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FreshwaterFish_AverageLifespanYears",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_BreedingDifficulty",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_BreedingNotes",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_CareLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_Coloration",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_CommonDiseases",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_Diet",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_FeedingFrequency",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_HardnessRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreshwaterFish_MinTankSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreshwaterFish_OptimalTemperatureMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FreshwaterFish_OptimalTemperatureMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_SpecialRequirements",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_TankMateCompatibility",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreshwaterFish_pHRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Habitat",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HardnessRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasLongFins",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasZooxanthellae",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvertebrateType",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAggressive",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlgaeEater",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBottomFeeder",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCleaner",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsJumper",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLabyrinthFish",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNocturnal",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlantSafe",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReefSafe",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsScavenger",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSchooling",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsToxic",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVenomous",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LightIntensityPAR",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LightSpectrum",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MagnesiumRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinTankSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NipsAtCorals",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NipsAtFins",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NipsAtInvertebrates",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OptimalSalinityMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OptimalSalinityMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OptimalTemperatureMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OptimalTemperatureMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant_GrowthRate",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PolyExtension",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredWaterFlow",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProneToDropsy",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProneToIch",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecommendedSchoolSize",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresAcclimation",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresAirstone",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresCycledTank",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresDosing",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresDriftwood",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresFeeding",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresHidingSpots",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresLiveRock",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresPlants",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresQuarantine",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresStableParameters",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_ActivityLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterFish_AdultSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterFish_AggressiveToOtherFish",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterFish_AggressiveToSameSpecies",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaltwaterFish_AverageLifespanYears",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_BodyShape",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_BreedingDifficulty",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_BreedingNotes",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_CareLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_Coloration",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_CommonDiseases",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_Diet",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_FeedingFrequency",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaltwaterFish_FishType",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_FoodTypes",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterFish_IsJumper",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterFish_IsSchooling",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterFish_MinTankSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterFish_OptimalSalinityMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterFish_OptimalSalinityMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterFish_OptimalTemperatureMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterFish_OptimalTemperatureMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterFish_ProneToIch",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaltwaterFish_RecommendedSchoolSize",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterFish_RequiresHidingSpots",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterFish_RequiresQuarantine",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_SpecialRequirements",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_SwimmingRegion",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_TankMateCompatibility",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_Temperament",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterFish_pHRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterInvertebrate_AdultSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterInvertebrate_AggressiveTowardsOwnSpecies",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaltwaterInvertebrate_AverageLifespanYears",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_Behavior",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_CareLevel",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_Coloration",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_CommonDiseases",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_Diet",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_FeedingFrequency",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_Habitat",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaltwaterInvertebrate_InvertebrateType",
                table: "Livestock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterInvertebrate_IsReefSafe",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterInvertebrate_MinTankSize",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterInvertebrate_OptimalSalinityMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterInvertebrate_OptimalSalinityMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterInvertebrate_OptimalTemperatureMax",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaltwaterInvertebrate_OptimalTemperatureMin",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_Placement",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SaltwaterInvertebrate_RequiresAcclimation",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_SpecialRequirements",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_TankMateCompatibility",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_WaterParameters",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaltwaterInvertebrate_pHRange",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SensitiveToCopper",
                table: "Livestock",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SpacingRequirement",
                table: "Livestock",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequirements",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StressSigns",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SwimmingRegion",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TankMateCompatibility",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperament",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaterParameters",
                table: "Livestock",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pHRange",
                table: "Livestock",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "AdultSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "AggressionMethod",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "AggressiveToOtherFish",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "AggressiveToSameSpecies",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "AggressiveTowardsOwnSpecies",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "AlkalinityRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "AverageLifespanYears",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Behavior",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "BodyShape",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "BreedingDifficulty",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "BreedingNotes",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "BreedingType",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "CalciumRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "CanBeFragged",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "CareLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "ColonySize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coloration",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "CommonDiseases",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "CoralFamily",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_CareLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_Coloration",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_CommonDiseases",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_FeedingFrequency",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_FoodTypes",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_OptimalTemperatureMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_OptimalTemperatureMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_Placement",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_RequiresAcclimation",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_SpecialRequirements",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Coral_pHRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Diet",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "DosingRequirements",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "EatsShrimp",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "EatsSmallFish",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "EatsSnails",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FeedingBehavior",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FeedingFrequency",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FishType",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FlowType",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FoodTypes",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FraggingDifficulty",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FraggingMethod",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FraggingNotes",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_AdultSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_AverageLifespanYears",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_BreedingDifficulty",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_BreedingNotes",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_CareLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_Coloration",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_CommonDiseases",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_Diet",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_FeedingFrequency",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_HardnessRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_MinTankSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_OptimalTemperatureMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_OptimalTemperatureMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_SpecialRequirements",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_TankMateCompatibility",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "FreshwaterFish_pHRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Habitat",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "HardnessRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "HasLongFins",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "HasZooxanthellae",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "InvertebrateType",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsAggressive",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsAlgaeEater",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsBottomFeeder",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsCleaner",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsJumper",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsLabyrinthFish",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsNocturnal",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsPlantSafe",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsReefSafe",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsScavenger",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsSchooling",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsToxic",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "IsVenomous",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "LightIntensityPAR",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "LightSpectrum",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "MagnesiumRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "MinTankSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "NipsAtCorals",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "NipsAtFins",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "NipsAtInvertebrates",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "OptimalSalinityMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "OptimalSalinityMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "OptimalTemperatureMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "OptimalTemperatureMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Plant_GrowthRate",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "PolyExtension",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "PreferredWaterFlow",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "ProneToDropsy",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "ProneToIch",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RecommendedSchoolSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresAcclimation",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresAirstone",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresCycledTank",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresDosing",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresDriftwood",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresFeeding",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresHidingSpots",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresLiveRock",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresPlants",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresQuarantine",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "RequiresStableParameters",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_ActivityLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_AdultSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_AggressiveToOtherFish",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_AggressiveToSameSpecies",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_AverageLifespanYears",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_BodyShape",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_BreedingDifficulty",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_BreedingNotes",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_CareLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_Coloration",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_CommonDiseases",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_Diet",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_FeedingFrequency",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_FishType",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_FoodTypes",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_IsJumper",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_IsSchooling",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_MinTankSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_OptimalSalinityMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_OptimalSalinityMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_OptimalTemperatureMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_OptimalTemperatureMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_ProneToIch",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_RecommendedSchoolSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_RequiresHidingSpots",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_RequiresQuarantine",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_SpecialRequirements",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_SwimmingRegion",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_TankMateCompatibility",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_Temperament",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterFish_pHRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_AdultSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_AggressiveTowardsOwnSpecies",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_AverageLifespanYears",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_Behavior",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_CareLevel",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_Coloration",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_CommonDiseases",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_Diet",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_FeedingFrequency",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_Habitat",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_InvertebrateType",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_IsReefSafe",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_MinTankSize",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_OptimalSalinityMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_OptimalSalinityMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_OptimalTemperatureMax",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_OptimalTemperatureMin",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_Placement",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_RequiresAcclimation",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_SpecialRequirements",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_TankMateCompatibility",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_WaterParameters",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SaltwaterInvertebrate_pHRange",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "ScientificName",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SensitiveToCopper",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SpacingRequirement",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SpecialRequirements",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "StressSigns",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "SwimmingRegion",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "TankMateCompatibility",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "Temperament",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "WaterParameters",
                table: "Livestock");

            migrationBuilder.DropColumn(
                name: "pHRange",
                table: "Livestock");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Livestock",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(34)",
                oldMaxLength: 34);
        }
    }
}
