using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CelesteAPI.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CelesteHost",
                columns: table => new
                {
                    CelesteHostID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Greeting = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    JourneyID = table.Column<int>(nullable: false),
                    Lesson = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelesteHost", x => x.CelesteHostID);
                });

            migrationBuilder.CreateTable(
                name: "Explorer",
                columns: table => new
                {
                    ExplorerID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Age = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explorer", x => x.ExplorerID);
                });

            migrationBuilder.CreateTable(
                name: "ExplorerResponse",
                columns: table => new
                {
                    ExplorerResponseID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Correct = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    ExplorerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExplorerResponse", x => x.ExplorerResponseID);
                    table.ForeignKey(
                        name: "FK_ExplorerResponse_Explorer_ExplorerID",
                        column: x => x.ExplorerID,
                        principalTable: "Explorer",
                        principalColumn: "ExplorerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    JourneyID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Destination = table.Column<string>(nullable: true),
                    ExplorerID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.JourneyID);
                    table.ForeignKey(
                        name: "FK_Journey_Explorer_ExplorerID",
                        column: x => x.ExplorerID,
                        principalTable: "Explorer",
                        principalColumn: "ExplorerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExplorerJourney",
                columns: table => new
                {
                    ExplorerJourneyID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    ExplorerID = table.Column<int>(nullable: false),
                    JourneyID = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    isCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExplorerJourney", x => x.ExplorerJourneyID);
                    table.ForeignKey(
                        name: "FK_ExplorerJourney_Explorer_ExplorerID",
                        column: x => x.ExplorerID,
                        principalTable: "Explorer",
                        principalColumn: "ExplorerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExplorerJourney_Journey_JourneyID",
                        column: x => x.JourneyID,
                        principalTable: "Journey",
                        principalColumn: "JourneyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trivia",
                columns: table => new
                {
                    TriviaID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Answer = table.Column<string>(nullable: true),
                    JourneyID = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trivia", x => x.TriviaID);
                    table.ForeignKey(
                        name: "FK_Trivia_Journey_JourneyID",
                        column: x => x.JourneyID,
                        principalTable: "Journey",
                        principalColumn: "JourneyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExplorerJourney_ExplorerID",
                table: "ExplorerJourney",
                column: "ExplorerID");

            migrationBuilder.CreateIndex(
                name: "IX_ExplorerJourney_JourneyID",
                table: "ExplorerJourney",
                column: "JourneyID");

            migrationBuilder.CreateIndex(
                name: "IX_ExplorerResponse_ExplorerID",
                table: "ExplorerResponse",
                column: "ExplorerID");

            migrationBuilder.CreateIndex(
                name: "IX_Journey_ExplorerID",
                table: "Journey",
                column: "ExplorerID");

            migrationBuilder.CreateIndex(
                name: "IX_Trivia_JourneyID",
                table: "Trivia",
                column: "JourneyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelesteHost");

            migrationBuilder.DropTable(
                name: "ExplorerJourney");

            migrationBuilder.DropTable(
                name: "ExplorerResponse");

            migrationBuilder.DropTable(
                name: "Trivia");

            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "Explorer");
        }
    }
}
