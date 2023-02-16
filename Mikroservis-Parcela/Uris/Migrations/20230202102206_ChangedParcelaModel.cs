using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uris.Migrations
{
    /// <inheritdoc />
    public partial class ChangedParcelaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcele_KatastarskeOpstine_KatastarskaOpstinaId",
                table: "Parcele");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcele_Kulture_KulturaId",
                table: "Parcele");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcele_KvalitetiZemljista_KvalitetZemljistaId",
                table: "Parcele");

            migrationBuilder.DropIndex(
                name: "IX_Parcele_KatastarskaOpstinaId",
                table: "Parcele");

            migrationBuilder.DropIndex(
                name: "IX_Parcele_KulturaId",
                table: "Parcele");

            migrationBuilder.DropIndex(
                name: "IX_Parcele_KvalitetZemljistaId",
                table: "Parcele");

            migrationBuilder.RenameColumn(
                name: "KvalitetZemljistaId",
                table: "Parcele",
                newName: "KvalitetZemljistaID");

            migrationBuilder.RenameColumn(
                name: "KulturaId",
                table: "Parcele",
                newName: "KulturaID");

            migrationBuilder.RenameColumn(
                name: "KatastarskaOpstinaId",
                table: "Parcele",
                newName: "KatastarskaOpstinaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KvalitetZemljistaID",
                table: "Parcele",
                newName: "KvalitetZemljistaId");

            migrationBuilder.RenameColumn(
                name: "KulturaID",
                table: "Parcele",
                newName: "KulturaId");

            migrationBuilder.RenameColumn(
                name: "KatastarskaOpstinaID",
                table: "Parcele",
                newName: "KatastarskaOpstinaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Parcele_KatastarskeOpstine_KatastarskaOpstinaId",
                table: "Parcele",
                column: "KatastarskaOpstinaId",
                principalTable: "KatastarskeOpstine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcele_Kulture_KulturaId",
                table: "Parcele",
                column: "KulturaId",
                principalTable: "Kulture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcele_KvalitetiZemljista_KvalitetZemljistaId",
                table: "Parcele",
                column: "KvalitetZemljistaId",
                principalTable: "KvalitetiZemljista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
