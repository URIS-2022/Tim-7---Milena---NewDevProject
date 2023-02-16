using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomisijaURIS.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komisije_ClanoviKomisije_ClanId",
                table: "Komisije");

            migrationBuilder.DropIndex(
                name: "IX_Komisije_ClanId",
                table: "Komisije");

            migrationBuilder.DropColumn(
                name: "ClanId",
                table: "Komisije");

            migrationBuilder.AddColumn<int>(
                name: "KomisijaId",
                table: "ClanoviKomisije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviKomisije_KomisijaId",
                table: "ClanoviKomisije",
                column: "KomisijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClanoviKomisije_Komisije_KomisijaId",
                table: "ClanoviKomisije",
                column: "KomisijaId",
                principalTable: "Komisije",
                principalColumn: "KomisijaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClanoviKomisije_Komisije_KomisijaId",
                table: "ClanoviKomisije");

            migrationBuilder.DropIndex(
                name: "IX_ClanoviKomisije_KomisijaId",
                table: "ClanoviKomisije");

            migrationBuilder.DropColumn(
                name: "KomisijaId",
                table: "ClanoviKomisije");

            migrationBuilder.AddColumn<int>(
                name: "ClanId",
                table: "Komisije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Komisije_ClanId",
                table: "Komisije",
                column: "ClanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komisije_ClanoviKomisije_ClanId",
                table: "Komisije",
                column: "ClanId",
                principalTable: "ClanoviKomisije",
                principalColumn: "ClanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
