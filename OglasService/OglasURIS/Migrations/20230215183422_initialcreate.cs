using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OglasURIS.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SluzbeniListovi",
                columns: table => new
                {
                    SluzbeniListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIzdanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojLista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SluzbeniListovi", x => x.SluzbeniListId);
                });

            migrationBuilder.CreateTable(
                name: "Oglasi",
                columns: table => new
                {
                    OglasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RokZaZalbu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpisOglasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjavljenUListuId = table.Column<int>(type: "int", nullable: false),
                    JavnoNadmetanjeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SluzbeniListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglasi", x => x.OglasId);
                    table.ForeignKey(
                        name: "FK_Oglasi_SluzbeniListovi_SluzbeniListId",
                        column: x => x.SluzbeniListId,
                        principalTable: "SluzbeniListovi",
                        principalColumn: "SluzbeniListId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oglasi_SluzbeniListId",
                table: "Oglasi",
                column: "SluzbeniListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oglasi");

            migrationBuilder.DropTable(
                name: "SluzbeniListovi");
        }
    }
}
