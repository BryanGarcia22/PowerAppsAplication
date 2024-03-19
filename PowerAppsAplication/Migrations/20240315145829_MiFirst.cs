using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerAppsAplication.Migrations
{
    public partial class MiFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EPPTorres",
                columns: table => new
                {
                    PkEPPTorres = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JefeDirecto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gerencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arnes5Posiciones = table.Column<bool>(type: "bit", nullable: false),
                    MarcaArnes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFabricacionArnes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComentariosStatusArnes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BotasSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuerdaPosicionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFabricacionCuerda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guantes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LentesSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mosqueton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShockAbsorbente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFabricacionShock = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SujetadorLineaVida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CascoSeguridadBarbiquejo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenFirma = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPPTorres", x => x.PkEPPTorres);
                });

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
                    UltimaCalibracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProximaCalibracion = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    FechaReparacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoGastado = table.Column<int>(type: "int", nullable: false),
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
                name: "EPPTorres");

            migrationBuilder.DropTable(
                name: "HistoricoEquipos");

            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}
