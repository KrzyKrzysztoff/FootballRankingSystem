using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class Repairentityteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Confederation_ConfederationId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ConfedertaionId",
                table: "Team");

            migrationBuilder.AlterColumn<int>(
                name: "ConfederationId",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "ConfederationId",
                table: "Team",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConfedertaionId",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Confederation_ConfederationId",
                table: "Team",
                column: "ConfederationId",
                principalTable: "Confederation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
