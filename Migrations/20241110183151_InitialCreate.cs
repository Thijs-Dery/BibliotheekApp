using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BibliotheekApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    AuteurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.AuteurID);
                });

            migrationBuilder.CreateTable(
                name: "Leden",
                columns: table => new
                {
                    LidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leden", x => x.LidID);
                });

            migrationBuilder.CreateTable(
                name: "Boeken",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicatieDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuteurID = table.Column<int>(type: "int", nullable: true),
                    LidID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeken", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Boeken_Auteurs_AuteurID",
                        column: x => x.AuteurID,
                        principalTable: "Auteurs",
                        principalColumn: "AuteurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boeken_Leden_LidID",
                        column: x => x.LidID,
                        principalTable: "Leden",
                        principalColumn: "LidID");
                });

            migrationBuilder.CreateTable(
                name: "LidBoeken",
                columns: table => new
                {
                    LidBoekID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LidID = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UitleenDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LidBoeken_Leden_LidID",
                        column: x => x.LidID,
                        principalTable: "Leden",
                        principalColumn: "LidID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "AuteurID", "GeboorteDatum", "Naam" },
                values: new object[,]
                {
                    { 1, new DateTime(1975, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 1" },
                    { 2, new DateTime(1980, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 2" },
                    { 3, new DateTime(1995, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 3" },
                    { 4, new DateTime(1978, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 4" },
                    { 5, new DateTime(1969, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 5" },
                    { 6, new DateTime(1985, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 6" },
                    { 7, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 7" },
                    { 8, new DateTime(1993, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 8" },
                    { 9, new DateTime(1982, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 9" },
                    { 10, new DateTime(1971, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auteur 10" }
                });

            migrationBuilder.InsertData(
                table: "Leden",
                columns: new[] { "LidID", "GeboorteDatum", "Naam" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Freddy" },
                    { 2, new DateTime(1985, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jochim" },
                    { 3, new DateTime(2000, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jos" },
                    { 4, new DateTime(1992, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofie" },
                    { 5, new DateTime(1988, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lars" },
                    { 6, new DateTime(1995, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emma" },
                    { 7, new DateTime(1993, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daan" },
                    { 8, new DateTime(1997, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mila" },
                    { 9, new DateTime(1991, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bram" },
                    { 10, new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise" },
                    { 11, new DateTime(1996, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hugo" },
                    { 12, new DateTime(1994, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nina" },
                    { 13, new DateTime(1998, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tim" },
                    { 14, new DateTime(1987, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura" },
                    { 15, new DateTime(1990, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sven" }
                });

            migrationBuilder.InsertData(
                table: "Boeken",
                columns: new[] { "ISBN", "AuteurID", "Genre", "LidID", "PublicatieDatum", "Titel" },
                values: new object[,]
                {
                    { "9781402894626", 1, "Koken", null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frieda Kroket" },
                    { "9783161484100", 2, "Koken", null, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Koken met Henk" },
                    { "TEST-0001", 4, "Avontuur", null, new DateTime(2019, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "De Avonturen van Bob" },
                    { "TEST-0002", 5, "Mysterie", null, new DateTime(2018, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het Geheim van de Tuin" },
                    { "TEST-0003", 6, "Romantiek", null, new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zomer in Parijs" },
                    { "TEST-0004", 7, "Educatief", null, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programmeren in C#" },
                    { "TEST-0005", 8, "Koken", null, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "De Keukenprinses" },
                    { "TEST-0006", 9, "Reizen", null, new DateTime(2017, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reizen door Europa" },
                    { "TEST-0007", 10, "Geschiedenis", null, new DateTime(2015, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Geschiedenis van de Wereld" },
                    { "TEST-0008", 1, "Educatief", null, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "De Kunst van het Schrijven" },
                    { "TEST-0009", 2, "Wetenschap", null, new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wetenschap en Innovatie" },
                    { "TEST-0010", 3, "Science Fiction", null, new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Een Reis door de Tijd" },
                    { "TEST-0011", 4, "Mysterie", null, new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het Mysterie van de Sphinx" },
                    { "TEST-0012", 5, "Motivatie", null, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "De Weg naar Succes" },
                    { "TEST-0013", 6, "Kinderboek", null, new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het Leven van een Kikker" },
                    { "TEST-0014", 7, "Educatief", null, new DateTime(2022, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiskunde voor Beginners" },
                    { "TEST-0015", 8, "Avontuur", null, new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avonturen in de Bergen" },
                    { "TEST-0016", 9, "Mysterie", null, new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Het Mysterie van de Oceaan" },
                    { "TEST-0017", 10, "Wetenschap", null, new DateTime(2019, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "De Geschiedenis van Technologie" },
                    { "TEST-010e1999", 3, "Fictie", null, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wdsawd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_AuteurID",
                table: "Boeken",
                column: "AuteurID");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LidBoeken");

            migrationBuilder.DropTable(
                name: "Boeken");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Leden");
        }
    }
}
