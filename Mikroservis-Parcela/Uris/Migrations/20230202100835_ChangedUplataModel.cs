using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uris.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUplataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uplate_Kursevi_KursId",
                table: "Uplate");

            migrationBuilder.RenameColumn(
                name: "KursId",
                table: "Uplate",
                newName: "KursID");

            migrationBuilder.RenameIndex(
                name: "IX_Uplate_KursId",
                table: "Uplate",
                newName: "IX_Uplate_KursID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uplate_Kursevi_KursID",
                table: "Uplate",
                column: "KursID",
                principalTable: "Kursevi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uplate_Kursevi_KursID",
                table: "Uplate");

            migrationBuilder.RenameColumn(
                name: "KursID",
                table: "Uplate",
                newName: "KursId");

            migrationBuilder.RenameIndex(
                name: "IX_Uplate_KursID",
                table: "Uplate",
                newName: "IX_Uplate_KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uplate_Kursevi_KursId",
                table: "Uplate",
                column: "KursId",
                principalTable: "Kursevi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
