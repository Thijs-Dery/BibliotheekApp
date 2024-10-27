using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotheekApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLidNullableRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LidID",
                table: "Boeken",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LidBoeken",
                columns: table => new
                {
                    LidBoekID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LidID = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UitleenDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InleverDatum = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LidBoeken", x => x.LidBoekID);
                    table.ForeignKey(
                        name: "FK_LidBoeken_Boeken_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Boeken",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LidBoeken_Leden_LidID",
                        column: x => x.LidID,
                        principalTable: "Leden",
                        principalColumn: "LidID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_LidID",
                table: "Boeken",
                column: "LidID");

            migrationBuilder.CreateIndex(
                name: "IX_LidBoeken_ISBN",
                table: "LidBoeken",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_LidBoeken_LidID",
                table: "LidBoeken",
                column: "LidID");

            migrationBuilder.AddForeignKey(
                name: "FK_Boeken_Leden_LidID",
                table: "Boeken",
                column: "LidID",
                principalTable: "Leden",
                principalColumn: "LidID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boeken_Leden_LidID",
                table: "Boeken");

            migrationBuilder.DropTable(
                name: "LidBoeken");

            migrationBuilder.DropIndex(
                name: "IX_Boeken_LidID",
                table: "Boeken");

            migrationBuilder.DropColumn(
                name: "LidID",
                table: "Boeken");
        }
    }
}
