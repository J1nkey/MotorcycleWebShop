using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleWebShop.Infrastructure.Migrations
{
    public partial class ChangePropertyNameOfPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KilometersComsumption",
                table: "Posts",
                newName: "KilometersConsumption");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KilometersConsumption",
                table: "Posts",
                newName: "KilometersComsumption");
        }
    }
}
