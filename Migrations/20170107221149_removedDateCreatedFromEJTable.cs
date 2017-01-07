using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelesteAPI.Migrations
{
    public partial class removedDateCreatedFromEJTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExplorerJourney_Explorer_ExplorerID",
                table: "ExplorerJourney");

            migrationBuilder.DropIndex(
                name: "IX_ExplorerJourney_ExplorerID",
                table: "ExplorerJourney");

            migrationBuilder.AlterColumn<string>(
                name: "ExplorerID",
                table: "ExplorerJourney",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ExplorerID1",
                table: "ExplorerJourney",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExplorerJourney_ExplorerID1",
                table: "ExplorerJourney",
                column: "ExplorerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExplorerJourney_Explorer_ExplorerID1",
                table: "ExplorerJourney",
                column: "ExplorerID1",
                principalTable: "Explorer",
                principalColumn: "ExplorerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExplorerJourney_Explorer_ExplorerID1",
                table: "ExplorerJourney");

            migrationBuilder.DropIndex(
                name: "IX_ExplorerJourney_ExplorerID1",
                table: "ExplorerJourney");

            migrationBuilder.DropColumn(
                name: "ExplorerID1",
                table: "ExplorerJourney");

            migrationBuilder.AlterColumn<int>(
                name: "ExplorerID",
                table: "ExplorerJourney",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ExplorerJourney_ExplorerID",
                table: "ExplorerJourney",
                column: "ExplorerID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExplorerJourney_Explorer_ExplorerID",
                table: "ExplorerJourney",
                column: "ExplorerID",
                principalTable: "Explorer",
                principalColumn: "ExplorerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
