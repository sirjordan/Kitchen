using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchen.Web.Data.Migrations
{
    public partial class dishcolumnsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Dishes");
        }
    }
}
