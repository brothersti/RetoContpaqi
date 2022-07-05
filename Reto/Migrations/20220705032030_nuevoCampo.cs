using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reto.Contpaqi.Web.Migrations
{
    public partial class nuevoCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstatusEmpleado",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstatusEmpleado",
                table: "Employees");
        }
    }
}
