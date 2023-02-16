using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZalbaService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RadnjaNaOsnovuZalbe",
                columns: table => new
                {
                    RadnjaNaOsnovuZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivRadnjeNaOsnovuZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnjaNaOsnovuZalbe", x => x.RadnjaNaOsnovuZalbeID);
                });

            migrationBuilder.CreateTable(
                name: "StatusZalbe",
                columns: table => new
                {
                    StatusZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivStatusaZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusZalbe", x => x.StatusZalbeID);
                });

            migrationBuilder.CreateTable(
                name: "TipZalbe",
                columns: table => new
                {
                    TipZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivTipaZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZalbe", x => x.TipZalbeID);
                });

            migrationBuilder.CreateTable(
                name: "Zalba",
                columns: table => new
                {
                    ZalbaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumPodnosenjaZalbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RazlogZalbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obrazlozenje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojNadmetanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumResenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojResenja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RadnjaNaOsnovuZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PodnosilacZalbeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalba", x => x.ZalbaID);
                    table.ForeignKey(
                        name: "FK_Zalba_RadnjaNaOsnovuZalbe_RadnjaNaOsnovuZalbeID",
                        column: x => x.RadnjaNaOsnovuZalbeID,
                        principalTable: "RadnjaNaOsnovuZalbe",
                        principalColumn: "RadnjaNaOsnovuZalbeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zalba_StatusZalbe_StatusZalbeID",
                        column: x => x.StatusZalbeID,
                        principalTable: "StatusZalbe",
                        principalColumn: "StatusZalbeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zalba_TipZalbe_TipZalbeID",
                        column: x => x.TipZalbeID,
                        principalTable: "TipZalbe",
                        principalColumn: "TipZalbeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RadnjaNaOsnovuZalbe",
                columns: new[] { "RadnjaNaOsnovuZalbeID", "NazivRadnjeNaOsnovuZalbe" },
                values: new object[,]
                {
                    { new Guid("55c00a00-ba2b-4141-966c-5cfb5ea50079"), "JN ide u drugi krug sa novim uslovima" },
                    { new Guid("af98278e-4a44-462f-9978-460b1ab8e2d1"), "JN ne ide u drugi krug" }
                });

            migrationBuilder.InsertData(
                table: "StatusZalbe",
                columns: new[] { "StatusZalbeID", "NazivStatusaZalbe" },
                values: new object[,]
                {
                    { new Guid("5b3470da-a635-4a04-8ef4-988608c46546"), "Odbijena" },
                    { new Guid("8d2ce4f7-c2a2-40f1-a92e-f30ac529153e"), "Usvojena" }
                });

            migrationBuilder.InsertData(
                table: "TipZalbe",
                columns: new[] { "TipZalbeID", "NazivTipaZalbe" },
                values: new object[,]
                {
                    { new Guid("9d51bfec-5281-4972-970d-b3bb2119e9ed"), "Žalba na tok javnog nadmetanja" },
                    { new Guid("d5d6624e-48f6-4167-bb07-9e8589fd9281"), "Žalba na Odluku o davanju u zakup" }
                });

            migrationBuilder.InsertData(
                table: "Zalba",
                columns: new[] { "ZalbaID", "BrojNadmetanja", "BrojResenja", "DatumPodnosenjaZalbe", "DatumResenja", "Obrazlozenje", "PodnosilacZalbeID", "RadnjaNaOsnovuZalbeID", "RazlogZalbe", "StatusZalbeID", "TipZalbeID" },
                values: new object[,]
                {
                    { new Guid("585ac17b-2267-46de-83b0-f4e5c45bc178"), "Br.nadmetanja-01", "Br.rešenja-001", new DateTime(2023, 1, 2, 10, 10, 54, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 2, 14, 10, 54, 0, DateTimeKind.Unspecified), "Obrazloženje odluke", new Guid("8b88badb-5ec1-4e38-a90d-c376bc31d011"), new Guid("55c00a00-ba2b-4141-966c-5cfb5ea50079"), "Razlog žalbe", new Guid("8d2ce4f7-c2a2-40f1-a92e-f30ac529153e"), new Guid("9d51bfec-5281-4972-970d-b3bb2119e9ed") },
                    { new Guid("b787e1fe-01aa-4aee-a153-0a0acce216a6"), "Br.nadmetanja-01", "Br.rešenja-001", new DateTime(2023, 2, 1, 0, 10, 54, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 12, 10, 54, 0, DateTimeKind.Unspecified), "Obrazloženje odluke", new Guid("8b88badb-5ec1-4e38-a90d-c376bc31d011"), new Guid("55c00a00-ba2b-4141-966c-5cfb5ea50079"), "Razlog žalbe", new Guid("8d2ce4f7-c2a2-40f1-a92e-f30ac529153e"), new Guid("9d51bfec-5281-4972-970d-b3bb2119e9ed") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zalba_RadnjaNaOsnovuZalbeID",
                table: "Zalba",
                column: "RadnjaNaOsnovuZalbeID");

            migrationBuilder.CreateIndex(
                name: "IX_Zalba_StatusZalbeID",
                table: "Zalba",
                column: "StatusZalbeID");

            migrationBuilder.CreateIndex(
                name: "IX_Zalba_TipZalbeID",
                table: "Zalba",
                column: "TipZalbeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zalba");

            migrationBuilder.DropTable(
                name: "RadnjaNaOsnovuZalbe");

            migrationBuilder.DropTable(
                name: "StatusZalbe");

            migrationBuilder.DropTable(
                name: "TipZalbe");
        }
    }
}
