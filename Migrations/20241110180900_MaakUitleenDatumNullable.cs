using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotheekApp.Migrations
{
    /// <inheritdoc />
    public partial class MaakUitleenDatumNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LidBoeken_Boeken_BoekISBN",
                table: "LidBoeken");

            migrationBuilder.DropForeignKey(
                name: "FK_LidBoeken_Boeken_ISBN",
                table: "LidBoeken");

            migrationBuilder.DropIndex(
                name: "IX_LidBoeken_BoekISBN",
                table: "LidBoeken");

            migrationBuilder.DropColumn(
                name: "BoekISBN",
                table: "LidBoeken");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UitleenDatum",
                table: "LidBoeken",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_LidBoeken_Boeken_ISBN",
                table: "LidBoeken",
                column: "ISBN",
                principalTable: "Boeken",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LidBoeken_Boeken_ISBN",
                table: "LidBoeken");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UitleenDatum",
                table: "LidBoeken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoekISBN",
                table: "LidBoeken",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LidBoeken_BoekISBN",
                table: "LidBoeken",
                column: "BoekISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_LidBoeken_Boeken_BoekISBN",
                table: "LidBoeken",
                column: "BoekISBN",
                principalTable: "Boeken",
                principalColumn: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_LidBoeken_Boeken_ISBN",
                table: "LidBoeken",
                column: "ISBN",
                principalTable: "Boeken",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
