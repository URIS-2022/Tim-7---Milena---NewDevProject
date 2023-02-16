using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdresaService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivDrzave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    AdresaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Broj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrzavaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.AdresaID);
                    table.ForeignKey(
                        name: "FK_Adresa_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drzava",
                columns: new[] { "DrzavaID", "NazivDrzave" },
                values: new object[,]
                {
                    { new Guid("0c520e55-4f91-44e4-a647-7ed01e758663"), "Hrvatska" },
                    { new Guid("24140a35-74e6-4201-8795-219b89b336d5"), "Rumunija" },
                    { new Guid("61fa9534-5c22-41fd-9517-b0de7eaed1e0"), "Crna Gora" },
                    { new Guid("96bac703-7677-4db3-858c-22b38f34dc19"), "Srbija" },
                    { new Guid("f662cca3-ac7d-42b4-a4a2-97be06d0ca2a"), "Madjarska" }
                });

            migrationBuilder.InsertData(
                table: "Adresa",
                columns: new[] { "AdresaID", "Broj", "DrzavaID", "Mesto", "PostanskiBroj", "Ulica" },
                values: new object[,]
                {
                    { new Guid("18867358-9ff9-4694-8da9-7719ecad7a51"), "4", new Guid("0c520e55-4f91-44e4-a647-7ed01e758663"), "Split", "23000", "Mike Antica" },
                    { new Guid("bab22d26-811b-4ec1-a012-025102eae6a5"), "19", new Guid("61fa9534-5c22-41fd-9517-b0de7eaed1e0"), "Podgorica", "22000", "Jove Pantica" },
                    { new Guid("c7df55e2-9ddf-408e-9a15-9bc7e309a81f"), "9", new Guid("96bac703-7677-4db3-858c-22b38f34dc19"), "Novi Sad", "21000", "Save Kovacevica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresa_DrzavaID",
                table: "Adresa",
                column: "DrzavaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
