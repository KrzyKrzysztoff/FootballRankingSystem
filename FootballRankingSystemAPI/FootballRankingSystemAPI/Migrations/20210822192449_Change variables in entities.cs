using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class Changevariablesinentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Simulation");

            migrationBuilder.RenameColumn(
                name: "Confederation",
                table: "Team",
                newName: "RankingPlace");

            migrationBuilder.AddColumn<double>(
                name: "Chance",
                table: "Team",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ConfederationId",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Confederation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confederation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Team_ConfederationId",
                table: "Team",
                column: "ConfederationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Confederation_ConfederationId",
                table: "Team",
                column: "ConfederationId",
                principalTable: "Confederation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Confederation_ConfederationId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Confederation");

            migrationBuilder.DropIndex(
                name: "IX_Team_ConfederationId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Chance",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ConfederationId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "RankingPlace",
                table: "Team",
                newName: "Confederation");

            migrationBuilder.CreateTable(
                name: "Simulation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulation", x => x.Id);
                });
        }
    }
}
