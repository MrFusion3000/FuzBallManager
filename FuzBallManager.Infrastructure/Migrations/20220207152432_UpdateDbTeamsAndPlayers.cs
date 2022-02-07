using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateDbTeamsAndPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Draws",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsAgainst",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsForward",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lost",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Stadium",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamID",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlayerPosition",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Draws",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsAgainst",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsForward",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Lost",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Stadium",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamID",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerPosition",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamID",
                table: "Players",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }
    }
}
