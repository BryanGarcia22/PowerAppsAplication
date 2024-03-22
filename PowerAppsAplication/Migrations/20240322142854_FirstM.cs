using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerAppsAplication.Migrations
{
    public partial class FirstM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LugarAsignado",
                table: "Equipos",
                newName: "Region");

            migrationBuilder.AlterColumn<string>(
                name: "FotoEquipo",
                table: "HistoricoEquipos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CertificadoCalibracion",
                table: "HistoricoEquipos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Equipos");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Equipos",
                newName: "LugarAsignado");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoEquipo",
                table: "HistoricoEquipos",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "CertificadoCalibracion",
                table: "HistoricoEquipos",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
