using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcCar.Migrations
{
    public partial class Addfild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Car",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Car");
        }
    }
}
