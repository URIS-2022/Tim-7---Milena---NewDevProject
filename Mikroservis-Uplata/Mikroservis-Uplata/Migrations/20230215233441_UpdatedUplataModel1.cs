using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikroservisUplata.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUplataModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JavnoNadmetanjeId",
                table: "Uplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.AddColumn<Guid>(
                name: "KupacId",
                table: "Uplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.NewGuid());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JavnoNadmetanjeId",
                table: "Uplate");

            migrationBuilder.DropColumn(
                name: "KupacId",
                table: "Uplate");
        }
    }
}
