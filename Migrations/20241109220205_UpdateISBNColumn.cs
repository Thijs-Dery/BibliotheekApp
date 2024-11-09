using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotheekApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateISBNColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoekISBN",
                table: "LidBoeken",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Leden",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AuteurID",
                table: "Boeken",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LidBoeken_Boeken_BoekISBN",
                table: "LidBoeken");

            migrationBuilder.DropIndex(
                name: "IX_LidBoeken_BoekISBN",
                table: "LidBoeken");

            migrationBuilder.DropColumn(
                name: "BoekISBN",
                table: "LidBoeken");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "Leden",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuteurID",
                table: "Boeken",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
