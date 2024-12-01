using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Origens",
                columns: table => new
                {
                    IdOrigem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pais = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origens", x => x.IdOrigem);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    IdPlanta = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrigemId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.IdPlanta);
                    table.ForeignKey(
                        name: "FK_Plantas_Origens_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "Origens",
                        principalColumn: "IdOrigem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantas_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_OrigemId",
                table: "Plantas",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_TipoId",
                table: "Plantas",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropTable(
                name: "Origens");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
