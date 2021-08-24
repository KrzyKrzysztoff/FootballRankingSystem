using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class AddrelationbetweenTeamandMatchResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchResultId",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Team_MatchResultId",
                table: "Team",
                column: "MatchResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_MatchResult_MatchResultId",
                table: "Team",
                column: "MatchResultId",
                principalTable: "MatchResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_MatchResult_MatchResultId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_MatchResultId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "MatchResultId",
                table: "Team");
        }
    }
}
