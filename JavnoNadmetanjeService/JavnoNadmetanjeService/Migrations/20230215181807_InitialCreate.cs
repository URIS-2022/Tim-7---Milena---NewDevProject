using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JavnoNadmetanjeService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusJavnogNadmetanja",
                columns: table => new
                {
                    StatusJavnogNadmetanjaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivStatusaJavnogNadmetanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusJavnogNadmetanja", x => x.StatusJavnogNadmetanjaID);
                });

            migrationBuilder.CreateTable(
                name: "TipJavnogNadmetanja",
                columns: table => new
                {
                    TipJavnogNadmetanjaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivTipaJavnogNadmetanja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipJavnogNadmetanja", x => x.TipJavnogNadmetanjaID);
                });

            migrationBuilder.CreateTable(
                name: "JavnoNadmetanje",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremePocetka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremeKraja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PocetnaCenaPoHektaru = table.Column<int>(type: "int", nullable: false),
                    Izuzeto = table.Column<bool>(type: "bit", nullable: false),
                    TipJavnogNadmetanjaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusJavnogNadmetanjaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IzlicitiranaCena = table.Column<int>(type: "int", nullable: false),
                    PeriodZakupa = table.Column<int>(type: "int", nullable: false),
                    BrojUcesnika = table.Column<int>(type: "int", nullable: false),
                    VisinaDopuneDepozita = table.Column<int>(type: "int", nullable: false),
                    Krug = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanje", x => x.JavnoNadmetanjeID);
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_StatusJavnogNadmetanja_StatusJavnogNadmetanjaID",
                        column: x => x.StatusJavnogNadmetanjaID,
                        principalTable: "StatusJavnogNadmetanja",
                        principalColumn: "StatusJavnogNadmetanjaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanje_TipJavnogNadmetanja_TipJavnogNadmetanjaID",
                        column: x => x.TipJavnogNadmetanjaID,
                        principalTable: "TipJavnogNadmetanja",
                        principalColumn: "TipJavnogNadmetanjaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JavnoNadmetanjeOvlascenaLica",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OvlascenoLiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanjeOvlascenaLica", x => new { x.JavnoNadmetanjeID, x.OvlascenoLiceID });
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanjeOvlascenaLica_JavnoNadmetanje_JavnoNadmetanjeID",
                        column: x => x.JavnoNadmetanjeID,
                        principalTable: "JavnoNadmetanje",
                        principalColumn: "JavnoNadmetanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JavnoNadmetanjeParcele",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParcelaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanjeParcele", x => new { x.JavnoNadmetanjeID, x.ParcelaID });
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanjeParcele_JavnoNadmetanje_JavnoNadmetanjeID",
                        column: x => x.JavnoNadmetanjeID,
                        principalTable: "JavnoNadmetanje",
                        principalColumn: "JavnoNadmetanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JavnoNadmetanjePrijavljeniKupci",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnoNadmetanjePrijavljeniKupci", x => new { x.JavnoNadmetanjeID, x.KupacID });
                    table.ForeignKey(
                        name: "FK_JavnoNadmetanjePrijavljeniKupci_JavnoNadmetanje_JavnoNadmetanjeID",
                        column: x => x.JavnoNadmetanjeID,
                        principalTable: "JavnoNadmetanje",
                        principalColumn: "JavnoNadmetanjeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StatusJavnogNadmetanja",
                columns: new[] { "StatusJavnogNadmetanjaID", "NazivStatusaJavnogNadmetanja" },
                values: new object[,]
                {
                    { new Guid("9e2d4dac-d491-46c3-a0c5-3437cb4e6cb4"), "Prvi krug" },
                    { new Guid("bd094186-09d6-4c8e-af79-abeeee94ba8a"), "Drugi krug sa starim uslovima" }
                });

            migrationBuilder.InsertData(
                table: "TipJavnogNadmetanja",
                columns: new[] { "TipJavnogNadmetanjaID", "NazivTipaJavnogNadmetanja" },
                values: new object[,]
                {
                    { new Guid("97dca59e-49df-468c-83f6-2171a966d3bb"), "Javna licitacija" },
                    { new Guid("b54d76e0-a230-4821-a072-e40524766d77"), "Otvaranje zatvorenih ponuda" }
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanje",
                columns: new[] { "JavnoNadmetanjeID", "AdresaID", "BrojUcesnika", "Datum", "IzlicitiranaCena", "Izuzeto", "Krug", "KupacID", "PeriodZakupa", "PocetnaCenaPoHektaru", "StatusJavnogNadmetanjaID", "TipJavnogNadmetanjaID", "VisinaDopuneDepozita", "VremeKraja", "VremePocetka" },
                values: new object[,]
                {
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), new Guid("bab22d26-811b-4ec1-a012-025102eae6a5"), 5, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600, false, 2, new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698"), 4, 800, new Guid("9e2d4dac-d491-46c3-a0c5-3437cb4e6cb4"), new Guid("b54d76e0-a230-4821-a072-e40524766d77"), 300, "15:00:00", "11:00:00" },
                    { new Guid("e128d9ea-25d6-47b7-8d94-4b73c6cb536c"), new Guid("c7df55e2-9ddf-408e-9a15-9bc7e309a81f"), 10, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500, false, 1, new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"), 5, 1000, new Guid("9e2d4dac-d491-46c3-a0c5-3437cb4e6cb4"), new Guid("b54d76e0-a230-4821-a072-e40524766d77"), 200, "14:00:00", "10:00:00" }
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanjeOvlascenaLica",
                columns: new[] { "JavnoNadmetanjeID", "OvlascenoLiceID" },
                values: new object[,]
                {
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), new Guid("87ae40cf-a971-434e-acd7-8e7f522433f9") },
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), new Guid("a1030c3b-9552-4946-a54e-559bed8cf733") }
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanjeParcele",
                columns: new[] { "JavnoNadmetanjeID", "ParcelaID" },
                values: new object[,]
                {
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), 1 },
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), 2 }
                });

            migrationBuilder.InsertData(
                table: "JavnoNadmetanjePrijavljeniKupci",
                columns: new[] { "JavnoNadmetanjeID", "KupacID" },
                values: new object[,]
                {
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb") },
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_StatusJavnogNadmetanjaID",
                table: "JavnoNadmetanje",
                column: "StatusJavnogNadmetanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_JavnoNadmetanje_TipJavnogNadmetanjaID",
                table: "JavnoNadmetanje",
                column: "TipJavnogNadmetanjaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavnoNadmetanjeOvlascenaLica");

            migrationBuilder.DropTable(
                name: "JavnoNadmetanjeParcele");

            migrationBuilder.DropTable(
                name: "JavnoNadmetanjePrijavljeniKupci");

            migrationBuilder.DropTable(
                name: "JavnoNadmetanje");

            migrationBuilder.DropTable(
                name: "StatusJavnogNadmetanja");

            migrationBuilder.DropTable(
                name: "TipJavnogNadmetanja");
        }
    }
}
