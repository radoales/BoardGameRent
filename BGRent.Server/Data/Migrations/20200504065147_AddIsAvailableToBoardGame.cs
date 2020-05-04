using Microsoft.EntityFrameworkCore.Migrations;

namespace BGRent.Server.Data.Migrations
{
    public partial class AddIsAvailableToBoardGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "BoardGames",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "BoardGames");
        }
    }
}
