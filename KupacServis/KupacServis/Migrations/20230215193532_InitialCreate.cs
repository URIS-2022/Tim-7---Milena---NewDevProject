using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KupacServis.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OvlascenoLices",
                columns: table => new
                {
                    OvlascenoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jmbg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DrzavaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrTable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlascenoLices", x => x.OvlascenoLiceId);
                });

            migrationBuilder.CreateTable(
                name: "Prioritets",
                columns: table => new
                {
                    PrioritetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpisPrioriteta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioritets", x => x.PrioritetId);
                });

            migrationBuilder.CreateTable(
                name: "Kupacs",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrioritetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OstvarenaPovrsina = table.Column<int>(type: "int", nullable: false),
                    ImaZabranu = table.Column<bool>(type: "bit", nullable: false),
                    DatumPocetkaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumPrestankaZabrane = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DuzinaTrajanjaZabraneUGod = table.Column<int>(type: "int", nullable: false),
                    BrTelefona1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrTelefona2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FizickoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PravnoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupacs", x => x.KupacId);
                    table.ForeignKey(
                        name: "FK_Kupacs_Prioritets_PrioritetId",
                        column: x => x.PrioritetId,
                        principalTable: "Prioritets",
                        principalColumn: "PrioritetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FizickoLices",
                columns: table => new
                {
                    FizickoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizickoLices", x => new { x.FizickoLiceId, x.KupacId });
                    table.ForeignKey(
                        name: "FK_FizickoLices_Kupacs_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupacs",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KupacJavnoNadmetanjes",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JavnoNadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupacJavnoNadmetanjes", x => new { x.KupacId, x.JavnoNadmetanjeId });
                    table.ForeignKey(
                        name: "FK_KupacJavnoNadmetanjes_Kupacs_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupacs",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KupacOvlascenoLices",
                columns: table => new
                {
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OvlascenoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupacOvlascenoLices", x => new { x.KupacId, x.OvlascenoLiceId });
                    table.ForeignKey(
                        name: "FK_KupacOvlascenoLices_Kupacs_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupacs",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KupacOvlascenoLices_OvlascenoLices_OvlascenoLiceId",
                        column: x => x.OvlascenoLiceId,
                        principalTable: "OvlascenoLices",
                        principalColumn: "OvlascenoLiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PravnoLices",
                columns: table => new
                {
                    PravnoLiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KupacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaticniBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PravnoLices", x => new { x.PravnoLiceId, x.KupacId });
                    table.ForeignKey(
                        name: "FK_PravnoLices_Kupacs_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupacs",
                        principalColumn: "KupacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OvlascenoLices",
                columns: new[] { "OvlascenoLiceId", "AdresaId", "BrTable", "DrzavaId", "Ime", "Jmbg", "Prezime" },
                values: new object[] { new Guid("1a6290ec-eaef-45a2-a01a-447ed04d6565"), new Guid("7349c655-8c0d-4743-8f24-8e8b6eeed64b"), 8889, new Guid("95c78cc7-745e-4946-bf7e-1cee81f24f36"), "Marko", "123456786543224", "Janic" });

            migrationBuilder.InsertData(
                table: "Prioritets",
                columns: new[] { "PrioritetId", "OpisPrioriteta" },
                values: new object[,]
                {
                    { new Guid("2915c26d-2912-438a-bc7a-8ed229009412"), "Prvi" },
                    { new Guid("c555941c-1913-4e0d-946d-a12e2b18c606"), "Drugi" }
                });

            migrationBuilder.InsertData(
                table: "Kupacs",
                columns: new[] { "KupacId", "AdresaId", "BrRacuna", "BrTelefona1", "BrTelefona2", "DatumPocetkaZabrane", "DatumPrestankaZabrane", "DuzinaTrajanjaZabraneUGod", "Email", "FizickoLiceId", "ImaZabranu", "OstvarenaPovrsina", "PravnoLiceId", "PrioritetId" },
                values: new object[,]
                {
                    { new Guid("5e8b59b3-14c6-417a-bfdc-378f617a5ef4"), null, "R6676390", "00381947294789", "00381987622265", new DateTime(2021, 10, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, "kupac3@gmail.com", null, true, 1890000, null, new Guid("c555941c-1913-4e0d-946d-a12e2b18c606") },
                    { new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"), null, "08729999", "00381947294000", "00381987627111", new DateTime(2022, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, "kupac2@gmail.com", null, true, 140000, null, new Guid("c555941c-1913-4e0d-946d-a12e2b18c606") },
                    { new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698"), null, "08728918", "00381947294038", "00381987627389", new DateTime(2022, 10, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, "kupac1@gmail.com", null, true, 100000, null, new Guid("2915c26d-2912-438a-bc7a-8ed229009412") }
                });

            migrationBuilder.InsertData(
                table: "FizickoLices",
                columns: new[] { "FizickoLiceId", "KupacId", "Ime", "JMBG", "Prezime" },
                values: new object[,]
                {
                    { new Guid("5b902b20-5f5c-40db-ae32-dc95dd948419"), new Guid("5e8b59b3-14c6-417a-bfdc-378f617a5ef4"), "Jelena", "0908991456754", "Matic" },
                    { new Guid("c15ee1bc-0d86-48f8-973a-d9284fafe2d8"), new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698"), "Marko", "1402993879899", "Markovic" }
                });

            migrationBuilder.InsertData(
                table: "KupacJavnoNadmetanjes",
                columns: new[] { "JavnoNadmetanjeId", "KupacId" },
                values: new object[,]
                {
                    { new Guid("138ab451-6f31-4069-a2db-592b2724d211"), new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb") },
                    { new Guid("27641d56-0997-48e2-9ec3-0353aa7925b3"), new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb") }
                });

            migrationBuilder.InsertData(
                table: "KupacOvlascenoLices",
                columns: new[] { "KupacId", "OvlascenoLiceId" },
                values: new object[] { new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"), new Guid("1a6290ec-eaef-45a2-a01a-447ed04d6565") });

            migrationBuilder.InsertData(
                table: "PravnoLices",
                columns: new[] { "KupacId", "PravnoLiceId", "Faks", "MaticniBroj", "Naziv" },
                values: new object[] { new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"), new Guid("83e1cd66-5610-4005-b742-6402d684d8a1"), "3456", "12345678", "PravnoLice1" });

            migrationBuilder.CreateIndex(
                name: "IX_FizickoLices_KupacId",
                table: "FizickoLices",
                column: "KupacId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KupacOvlascenoLices_OvlascenoLiceId",
                table: "KupacOvlascenoLices",
                column: "OvlascenoLiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupacs_PrioritetId",
                table: "Kupacs",
                column: "PrioritetId");

            migrationBuilder.CreateIndex(
                name: "IX_PravnoLices_KupacId",
                table: "PravnoLices",
                column: "KupacId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizickoLices");

            migrationBuilder.DropTable(
                name: "KupacJavnoNadmetanjes");

            migrationBuilder.DropTable(
                name: "KupacOvlascenoLices");

            migrationBuilder.DropTable(
                name: "PravnoLices");

            migrationBuilder.DropTable(
                name: "OvlascenoLices");

            migrationBuilder.DropTable(
                name: "Kupacs");

            migrationBuilder.DropTable(
                name: "Prioritets");
        }
    }
}
