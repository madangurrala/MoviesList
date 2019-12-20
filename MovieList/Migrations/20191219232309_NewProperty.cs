using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieList.Migrations
{
    public partial class NewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Production",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Production",
                table: "Movie");
        }
    }
}
