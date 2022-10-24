using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjemploPlantilla.Migrations
{
    public partial class Prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEstado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantillaNotificacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillaNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantillaNotificacion_TipoEstado_TipoEstadoId",
                        column: x => x.TipoEstadoId,
                        principalTable: "TipoEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantillaNotificacion_TipoEstadoId",
                table: "PlantillaNotificacion",
                column: "TipoEstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "PlantillaNotificacion");

            migrationBuilder.DropTable(
                name: "TipoEstado");
        }
    }
}
