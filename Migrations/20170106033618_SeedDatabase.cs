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
                    ImageURL = table.Column<string>(nullable: true),
                    JourneyID = table.Column<int>(nullable: false),
                    Lesson = table.Column<string>(nullable: true)
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
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    firebaseID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explorer", x => x.ExplorerID);
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
                name: "Questions",
                columns: table => new
                {
                    QuestionsID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    JourneyID = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionsID);
                    table.ForeignKey(
                        name: "FK_Questions_Journey_JourneyID",
                        column: x => x.JourneyID,
                        principalTable: "Journey",
                        principalColumn: "JourneyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswersID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Answer = table.Column<string>(nullable: true),
                    JourneyID = table.Column<int>(nullable: false),
                    QuestionsID = table.Column<int>(nullable: false),
                    Real = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswersID);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionsID",
                        column: x => x.QuestionsID,
                        principalTable: "Questions",
                        principalColumn: "QuestionsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsID",
                table: "Answers",
                column: "QuestionsID");

            migrationBuilder.CreateIndex(
                name: "IX_ExplorerJourney_ExplorerID",
                table: "ExplorerJourney",
                column: "ExplorerID");

            migrationBuilder.CreateIndex(
                name: "IX_ExplorerJourney_JourneyID",
                table: "ExplorerJourney",
                column: "JourneyID");

            migrationBuilder.CreateIndex(
                name: "IX_Journey_ExplorerID",
                table: "Journey",
                column: "ExplorerID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_JourneyID",
                table: "Questions",
                column: "JourneyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "CelesteHost");

            migrationBuilder.DropTable(
                name: "ExplorerJourney");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Journey");

            migrationBuilder.DropTable(
                name: "Explorer");
        }
    }
}
