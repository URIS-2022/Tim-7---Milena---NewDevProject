using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UgovorService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZavodniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDonosenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sablon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "TipGarancije",
                columns: table => new
                {
                    TipGarancijeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivTipaG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipGarancije", x => x.TipGarancijeID);
                });

            migrationBuilder.CreateTable(
                name: "Ugovor",
                columns: table => new
                {
                    UgovorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZavodniBrojUgovora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumZavodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RokZaVracanjeZemljista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MestoPotpisa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPotpisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipGarancijeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DokumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JavnoNadmetanjeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KupacID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovor", x => x.UgovorID);
                    table.ForeignKey(
                        name: "FK_Ugovor_Dokument_DokumentID",
                        column: x => x.DokumentID,
                        principalTable: "Dokument",
                        principalColumn: "DokumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ugovor_TipGarancije_TipGarancijeID",
                        column: x => x.TipGarancijeID,
                        principalTable: "TipGarancije",
                        principalColumn: "TipGarancijeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dokument",
                columns: new[] { "DokumentID", "Datum", "DatumDonosenja", "Sablon", "ZavodniBroj" },
                values: new object[,]
                {
                    { new Guid("1a397c0a-d320-4998-ae39-d137b037cbc0"), new DateTime(2020, 2, 12, 13, 11, 31, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 12, 14, 20, 0, 0, DateTimeKind.Unspecified), "Odluka o raspisivanju javnog oglasa za davanje u zakup poljoprivrednog zemljišta u državnoj svojini", "ABC-12" },
                    { new Guid("20980ee8-a44e-4837-bae4-e54a9b6da870"), new DateTime(2022, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), "Odluka o davanju u zakup poljoprivrednog zemljišta", "ABC-10" },
                    { new Guid("364696aa-0369-4af0-954d-21b855b514e4"), new DateTime(2023, 1, 16, 15, 12, 11, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 17, 12, 0, 25, 0, DateTimeKind.Unspecified), "Obrazovanje stručne komisije za pregled kvaliteta zemljišta", "DEF-20" },
                    { new Guid("8a91ab92-358b-44ae-ba1d-102639f4e738"), new DateTime(2023, 1, 12, 10, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 12, 12, 45, 0, 0, DateTimeKind.Unspecified), "Program zaštite, uređenja i korišćenja poljopriverednog zemljišta", "ABC-13" },
                    { new Guid("b11ecad0-2655-40d4-93ed-3745e2494bf8"), new DateTime(2018, 6, 11, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 11, 12, 30, 0, 0, DateTimeKind.Unspecified), "Odluka o poništenju odluke o davanju u zakup poljoprivrednog zemljišta", "ABC-11" }
                });

            migrationBuilder.InsertData(
                table: "TipGarancije",
                columns: new[] { "TipGarancijeID", "NazivTipaG" },
                values: new object[,]
                {
                    { new Guid("8110783f-afbe-4c01-9be7-71de8eb9deff"), "Bankarska Garancija" },
                    { new Guid("85c389db-cec5-4283-bc47-a042de8785a2"), "Uplata gotovinom" },
                    { new Guid("8973b944-d7eb-4366-8aa6-e7f9306a0304"), "Garancija nekretninom" },
                    { new Guid("a1885b0e-58f9-4623-92a2-f95bfe0f2fcc"), "Žirantska" },
                    { new Guid("ea44e6b8-269c-4298-a12c-885638095e4f"), "Jemstvo" }
                });

            migrationBuilder.InsertData(
                table: "Ugovor",
                columns: new[] { "UgovorID", "DatumPotpisa", "DatumZavodjenja", "DokumentID", "JavnoNadmetanjeID", "KupacID", "MestoPotpisa", "RokZaVracanjeZemljista", "TipGarancijeID", "ZavodniBrojUgovora" },
                values: new object[] { new Guid("50916085-56d4-499c-9321-ae3839c1a4f5"), new DateTime(2022, 4, 23, 14, 20, 57, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 18, 16, 14, 33, 0, DateTimeKind.Unspecified), new Guid("20980ee8-a44e-4837-bae4-e54a9b6da870"), new Guid("525af424-9440-4ee2-8502-01748e13f837"), new Guid("ef30d834-a569-4910-aa58-0ddedc4b669d"), "Novi Sad", new DateTime(2025, 7, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ea44e6b8-269c-4298-a12c-885638095e4f"), "ugovor1" });

            migrationBuilder.CreateIndex(
                name: "IX_Ugovor_DokumentID",
                table: "Ugovor",
                column: "DokumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Ugovor_TipGarancijeID",
                table: "Ugovor",
                column: "TipGarancijeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ugovor");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "TipGarancije");
        }
    }
}
