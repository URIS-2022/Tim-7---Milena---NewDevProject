using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uris.Migrations
{
    /// <inheritdoc />
    public partial class CreatedMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KatastarskeOpstine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Okrug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatastarskeOpstine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kulture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategorija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kulture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valuta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KvalitetiZemljista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivVrsteZemljista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kvalitet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KvalitetiZemljista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PozivNaBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SvrhaUplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iznos = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojParcele = table.Column<int>(type: "int", nullable: false),
                    BrojListaNepokretnosti = table.Column<int>(type: "int", nullable: false),
                    Povrsina = table.Column<float>(type: "real", nullable: false),
                    ZasticenaZona = table.Column<bool>(type: "bit", nullable: false),
                    OblikSvojine = table.Column<int>(type: "int", nullable: false),
                    Odvodnjavanje = table.Column<int>(type: "int", nullable: false),
                    KulturaId = table.Column<int>(type: "int", nullable: false),
                    KvalitetZemljistaId = table.Column<int>(type: "int", nullable: false),
                    KatastarskaOpstinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcele", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcele_KatastarskeOpstine_KatastarskaOpstinaId",
                        column: x => x.KatastarskaOpstinaId,
                        principalTable: "KatastarskeOpstine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcele_Kulture_KulturaId",
                        column: x => x.KulturaId,
                        principalTable: "Kulture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcele_KvalitetiZemljista_KvalitetZemljistaId",
                        column: x => x.KvalitetZemljistaId,
                        principalTable: "KvalitetiZemljista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_KatastarskaOpstinaId",
                table: "Parcele",
                column: "KatastarskaOpstinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_KulturaId",
                table: "Parcele",
                column: "KulturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcele_KvalitetZemljistaId",
                table: "Parcele",
                column: "KvalitetZemljistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Parcele");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "KatastarskeOpstine");

            migrationBuilder.DropTable(
                name: "Kulture");

            migrationBuilder.DropTable(
                name: "KvalitetiZemljista");
        }
    }
}
