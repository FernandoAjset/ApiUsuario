using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiUsuario.Migrations
{
    public partial class CambioPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    PrimerNombre = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    SegundoNombre = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    FechaNacimiento = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    TelefonoMovil = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Pais",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_PaisId",
                table: "Empleado",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
