using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reto.Contpaqi.Database.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Empleado",
                newName: "GeneroId");

            migrationBuilder.RenameColumn(
                name: "EstadoCivil",
                table: "Empleado",
                newName: "EstadoCivilId");

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.EstadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_EstadoCivilId",
                table: "Empleado",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_GeneroId",
                table: "Empleado",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_EstadoCivil_EstadoCivilId",
                table: "Empleado",
                column: "EstadoCivilId",
                principalTable: "EstadoCivil",
                principalColumn: "EstadoCivilId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Genero_GeneroId",
                table: "Empleado",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "GeneroId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_EstadoCivil_EstadoCivilId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Genero_GeneroId",
                table: "Empleado");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_EstadoCivilId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_GeneroId",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "Empleado",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "EstadoCivilId",
                table: "Empleado",
                newName: "EstadoCivil");
        }
    }
}
