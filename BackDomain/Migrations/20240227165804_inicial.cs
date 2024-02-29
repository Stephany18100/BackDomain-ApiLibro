using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WepApi.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    CodigoLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLibro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisAutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDePaginas = table.Column<int>(type: "int", nullable: true),
                    AnioDeEdicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.CodigoLibro);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    NumeroPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCodigoLibro = table.Column<int>(type: "int", nullable: false),
                    FKCodigoUsuario = table.Column<int>(type: "int", nullable: true),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaMaximaDevolver = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.NumeroPedido);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodigoUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
