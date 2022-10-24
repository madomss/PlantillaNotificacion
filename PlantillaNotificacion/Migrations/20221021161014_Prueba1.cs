using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EjemploPlantilla.Migrations
{
    public partial class Prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantillaNotificacion_TipoEstado_TipoEstadoId",
                table: "PlantillaNotificacion");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoEstadoId",
                table: "PlantillaNotificacion",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantillaNotificacion_TipoEstado_TipoEstadoId",
                table: "PlantillaNotificacion",
                column: "TipoEstadoId",
                principalTable: "TipoEstado",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantillaNotificacion_TipoEstado_TipoEstadoId",
                table: "PlantillaNotificacion");

            migrationBuilder.AlterColumn<Guid>(
                name: "TipoEstadoId",
                table: "PlantillaNotificacion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantillaNotificacion_TipoEstado_TipoEstadoId",
                table: "PlantillaNotificacion",
                column: "TipoEstadoId",
                principalTable: "TipoEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
