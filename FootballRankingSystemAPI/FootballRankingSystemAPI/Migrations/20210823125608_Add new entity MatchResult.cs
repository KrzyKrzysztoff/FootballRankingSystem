using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class AddnewentityMatchResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "MatchResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoalsScoredByWinTeam = table.Column<int>(type: "int", nullable: false),
                    GoalsScoredByLoseTeam = table.Column<int>(type: "int", nullable: false),
                    IsDraw = table.Column<bool>(type: "bit", nullable: false),
                    TeamWinOrDrawName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLostOrDrawName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResult", x => x.Id);
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
