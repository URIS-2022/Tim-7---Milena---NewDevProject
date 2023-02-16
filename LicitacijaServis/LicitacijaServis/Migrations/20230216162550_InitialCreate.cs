using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LicitacijaServis.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licitacijas",
                columns: table => new
                {
                    LicitacijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Broj = table.Column<int>(type: "int", nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    Ogranicenje = table.Column<int>(type: "int", nullable: false),
                    KorakCene = table.Column<int>(type: "int", nullable: false),
                    ListaDokumentacijeFizickaLica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListaDokumentacijePravnaLica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rok = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licitacijas", x => x.LicitacijaId);
                });

            migrationBuilder.CreateTable(
                name: "LicitacijaJavnoNadmetanjes",
                columns: table => new
                {
                    LicitacijaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JavnoNadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitacijaJavnoNadmetanjes", x => new { x.LicitacijaId, x.JavnoNadmetanjeId });
                    table.ForeignKey(
                        name: "FK_LicitacijaJavnoNadmetanjes_Licitacijas_LicitacijaId",
                        column: x => x.LicitacijaId,
                        principalTable: "Licitacijas",
                        principalColumn: "LicitacijaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Licitacijas",
                columns: new[] { "LicitacijaId", "Broj", "Datum", "Godina", "KorakCene", "ListaDokumentacijeFizickaLica", "ListaDokumentacijePravnaLica", "Ogranicenje", "Rok" },
                values: new object[,]
                {
                    { new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"), 2, new DateTime(2022, 10, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 2022, 10000, "Dokument F2", "Dokument P2", 1000000, new DateTime(2022, 8, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698"), 1, new DateTime(2022, 10, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), 2022, 10000, "Dokument F1", "Dokument P1", 1000000, new DateTime(2022, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LicitacijaJavnoNadmetanjes",
                columns: new[] { "JavnoNadmetanjeId", "LicitacijaId" },
                values: new object[,]
                {
                    { new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"), new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb") },
                    { new Guid("e128d9ea-25d6-47b7-8d94-4b73c6cb536c"), new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicitacijaJavnoNadmetanjes");

            migrationBuilder.DropTable(
                name: "Licitacijas");
        }
    }
}
