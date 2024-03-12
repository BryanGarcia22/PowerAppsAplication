using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerAppsAplication.Migrations
{
    public partial class firstM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    PkEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarAsignado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodoCalibracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaCalibracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProximaCalibracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.PkEquipo);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEquipos",
                columns: table => new
                {
                    PKHistoricoEquipos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkEquipo = table.Column<int>(type: "int", nullable: false),
                    FechaMantenimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calibracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reparacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaReparacion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoGastado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquiposPkEquipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEquipos", x => x.PKHistoricoEquipos);
                    table.ForeignKey(
                        name: "FK_HistoricoEquipos_Equipos_EquiposPkEquipo",
                        column: x => x.EquiposPkEquipo,
                        principalTable: "Equipos",
                        principalColumn: "PkEquipo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEquipos_EquiposPkEquipo",
                table: "HistoricoEquipos",
                column: "EquiposPkEquipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoEquipos");

            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}
