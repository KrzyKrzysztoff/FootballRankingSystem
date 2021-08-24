using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class AddnewentityMatchStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Points",
                table: "Team",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "TeamLostOrDrawPointsScored",
                table: "MatchResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TeamWinOrDrawPointsScored",
                table: "MatchResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "MatchStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Multiplier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchStatus");

            migrationBuilder.DropColumn(
                name: "TeamLostOrDrawPointsScored",
                table: "MatchResult");

            migrationBuilder.DropColumn(
                name: "TeamWinOrDrawPointsScored",
                table: "MatchResult");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "Team",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
