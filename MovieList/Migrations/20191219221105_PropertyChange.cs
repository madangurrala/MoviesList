using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieList.Migrations
{
    public partial class PropertyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direcotr",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Direcotr",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
