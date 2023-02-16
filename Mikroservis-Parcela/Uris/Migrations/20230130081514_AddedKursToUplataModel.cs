using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uris.Migrations
{
    /// <inheritdoc />
    public partial class AddedKursToUplataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "Uplate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_KursId",
                table: "Uplate",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uplate_Kursevi_KursId",
                table: "Uplate",
                column: "KursId",
                principalTable: "Kursevi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uplate_Kursevi_KursId",
                table: "Uplate");

            migrationBuilder.DropIndex(
                name: "IX_Uplate_KursId",
                table: "Uplate");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "Uplate");
        }
    }
}
