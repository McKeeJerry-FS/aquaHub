using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AquaHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPredictiveReminders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PredictiveReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TankId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SuggestedType = table.Column<int>(type: "integer", nullable: false),
                    SuggestedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConfidenceScore = table.Column<double>(type: "double precision", nullable: false),
                    Reasoning = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    PatternOccurrences = table.Column<int>(type: "integer", nullable: false),
                    AverageDaysBetween = table.Column<double>(type: "double precision", nullable: false),
                    LastOccurrence = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    IsDismissed = table.Column<bool>(type: "boolean", nullable: false),
                    AcceptedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DismissedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedReminderId = table.Column<int>(type: "integer", nullable: true),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictiveReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredictiveReminders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredictiveReminders_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredictiveReminders_TankId",
                table: "PredictiveReminders",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictiveReminders_UserId",
                table: "PredictiveReminders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredictiveReminders");
        }
    }
}
