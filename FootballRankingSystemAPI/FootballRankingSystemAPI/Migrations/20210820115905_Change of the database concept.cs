using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class Changeofthedatabaseconcept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Confederation_ConfederationId",
                table: "Team");

            migrationBuilder.DropTable(
                name: "Confederation");

            migrationBuilder.DropIndex(
                name: "IX_Team_ConfederationId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "ConfederationId",
                table: "Team",
                newName: "Confederation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Confederation",
                table: "Team",
                newName: "ConfederationId");

            migrationBuilder.CreateTable(
                name: "Confederation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
