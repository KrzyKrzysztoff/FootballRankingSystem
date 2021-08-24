using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballRankingSystemAPI.Migrations
{
    public partial class Reapirdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Chance",
                table: "Team",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Confederation",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Chance",
                table: "Team",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Confederation",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
