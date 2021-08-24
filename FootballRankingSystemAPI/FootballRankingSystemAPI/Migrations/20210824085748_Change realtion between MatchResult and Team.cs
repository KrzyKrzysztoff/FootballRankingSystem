using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class ChangerealtionbetweenMatchResultandTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MatchResultTeam",
                columns: table => new
                {
                    MatchResultId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResultTeam", x => new { x.MatchResultId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MatchResultTeam_MatchResult_MatchResultId",
                        column: x => x.MatchResultId,
                        principalTable: "MatchResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchResultTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchResultTeam_TeamId",
                table: "MatchResultTeam",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchResultTeam");

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
    }
}
