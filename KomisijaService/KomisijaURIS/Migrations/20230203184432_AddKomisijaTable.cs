using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomisijaURIS.Migrations
{
    /// <inheritdoc />
    public partial class AddKomisijaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClanoviKomisije",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezimeClana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailClana = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanoviKomisije", x => x.ClanId);
                });

            migrationBuilder.CreateTable(
                name: "Predsednici",
                columns: table => new
                {
                    PredsednikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePredsednika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezimePredsednika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailPredsednika = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predsednici", x => x.PredsednikId);
                });

            migrationBuilder.CreateTable(
                name: "Komisije",
                columns: table => new
                {
                    KomisijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredsednikId = table.Column<int>(type: "int", nullable: false),
                    ClanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisije", x => x.KomisijaId);
                    table.ForeignKey(
                        name: "FK_Komisije_ClanoviKomisije_ClanId",
                        column: x => x.ClanId,
                        principalTable: "ClanoviKomisije",
                        principalColumn: "ClanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Komisije_Predsednici_PredsednikId",
                        column: x => x.PredsednikId,
                        principalTable: "Predsednici",
                        principalColumn: "PredsednikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komisije_ClanId",
                table: "Komisije",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Komisije_PredsednikId",
                table: "Komisije",
                column: "PredsednikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komisije");

            migrationBuilder.DropTable(
                name: "ClanoviKomisije");

            migrationBuilder.DropTable(
                name: "Predsednici");
        }
    }
}
