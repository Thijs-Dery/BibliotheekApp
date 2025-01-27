﻿// <auto-generated />
using System;
using BibliotheekApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotheekApp.Migrations
{
    [DbContext(typeof(BibliotheekContext))]
    [Migration("20241110183151_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotheekApp.Models.Auteur", b =>
                {
                    b.Property<int>("AuteurID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuteurID"));

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuteurID");

                    b.ToTable("Auteurs");

                    b.HasData(
                        new
                        {
                            AuteurID = 1,
                            GeboorteDatum = new DateTime(1975, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 1"
                        },
                        new
                        {
                            AuteurID = 2,
                            GeboorteDatum = new DateTime(1980, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 2"
                        },
                        new
                        {
                            AuteurID = 3,
                            GeboorteDatum = new DateTime(1995, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 3"
                        },
                        new
                        {
                            AuteurID = 4,
                            GeboorteDatum = new DateTime(1978, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 4"
                        },
                        new
                        {
                            AuteurID = 5,
                            GeboorteDatum = new DateTime(1969, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 5"
                        },
                        new
                        {
                            AuteurID = 6,
                            GeboorteDatum = new DateTime(1985, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 6"
                        },
                        new
                        {
                            AuteurID = 7,
                            GeboorteDatum = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 7"
                        },
                        new
                        {
                            AuteurID = 8,
                            GeboorteDatum = new DateTime(1993, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 8"
                        },
                        new
                        {
                            AuteurID = 9,
                            GeboorteDatum = new DateTime(1982, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 9"
                        },
                        new
                        {
                            AuteurID = 10,
                            GeboorteDatum = new DateTime(1971, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Auteur 10"
                        });
                });

            modelBuilder.Entity("BibliotheekApp.Models.Lid", b =>
                {
                    b.Property<int>("LidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LidID"));

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LidID");

                    b.ToTable("Leden");

                    b.HasData(
                        new
                        {
                            LidID = 1,
                            GeboorteDatum = new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Freddy"
                        },
                        new
                        {
                            LidID = 2,
                            GeboorteDatum = new DateTime(1985, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Jochim"
                        },
                        new
                        {
                            LidID = 3,
                            GeboorteDatum = new DateTime(2000, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Jos"
                        },
                        new
                        {
                            LidID = 4,
                            GeboorteDatum = new DateTime(1992, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Sofie"
                        },
                        new
                        {
                            LidID = 5,
                            GeboorteDatum = new DateTime(1988, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Lars"
                        },
                        new
                        {
                            LidID = 6,
                            GeboorteDatum = new DateTime(1995, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Emma"
                        },
                        new
                        {
                            LidID = 7,
                            GeboorteDatum = new DateTime(1993, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Daan"
                        },
                        new
                        {
                            LidID = 8,
                            GeboorteDatum = new DateTime(1997, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Mila"
                        },
                        new
                        {
                            LidID = 9,
                            GeboorteDatum = new DateTime(1991, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Bram"
                        },
                        new
                        {
                            LidID = 10,
                            GeboorteDatum = new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Lise"
                        },
                        new
                        {
                            LidID = 11,
                            GeboorteDatum = new DateTime(1996, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Hugo"
                        },
                        new
                        {
                            LidID = 12,
                            GeboorteDatum = new DateTime(1994, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Nina"
                        },
                        new
                        {
                            LidID = 13,
                            GeboorteDatum = new DateTime(1998, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Tim"
                        },
                        new
                        {
                            LidID = 14,
                            GeboorteDatum = new DateTime(1987, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Laura"
                        },
                        new
                        {
                            LidID = 15,
                            GeboorteDatum = new DateTime(1990, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Naam = "Sven"
                        });
                });

            modelBuilder.Entity("Boek", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AuteurID")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LidID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicatieDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN");

                    b.HasIndex("AuteurID");

                    b.HasIndex("LidID");

                    b.ToTable("Boeken");

                    b.HasData(
                        new
                        {
                            ISBN = "9781402894626",
                            AuteurID = 1,
                            Genre = "Koken",
                            PublicatieDatum = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Frieda Kroket"
                        },
                        new
                        {
                            ISBN = "9783161484100",
                            AuteurID = 2,
                            Genre = "Koken",
                            PublicatieDatum = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Koken met Henk"
                        },
                        new
                        {
                            ISBN = "TEST-010e1999",
                            AuteurID = 3,
                            Genre = "Fictie",
                            PublicatieDatum = new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Wdsawd"
                        },
                        new
                        {
                            ISBN = "TEST-0001",
                            AuteurID = 4,
                            Genre = "Avontuur",
                            PublicatieDatum = new DateTime(2019, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "De Avonturen van Bob"
                        },
                        new
                        {
                            ISBN = "TEST-0002",
                            AuteurID = 5,
                            Genre = "Mysterie",
                            PublicatieDatum = new DateTime(2018, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Het Geheim van de Tuin"
                        },
                        new
                        {
                            ISBN = "TEST-0003",
                            AuteurID = 6,
                            Genre = "Romantiek",
                            PublicatieDatum = new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Zomer in Parijs"
                        },
                        new
                        {
                            ISBN = "TEST-0004",
                            AuteurID = 7,
                            Genre = "Educatief",
                            PublicatieDatum = new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Programmeren in C#"
                        },
                        new
                        {
                            ISBN = "TEST-0005",
                            AuteurID = 8,
                            Genre = "Koken",
                            PublicatieDatum = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "De Keukenprinses"
                        },
                        new
                        {
                            ISBN = "TEST-0006",
                            AuteurID = 9,
                            Genre = "Reizen",
                            PublicatieDatum = new DateTime(2017, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Reizen door Europa"
                        },
                        new
                        {
                            ISBN = "TEST-0007",
                            AuteurID = 10,
                            Genre = "Geschiedenis",
                            PublicatieDatum = new DateTime(2015, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Geschiedenis van de Wereld"
                        },
                        new
                        {
                            ISBN = "TEST-0008",
                            AuteurID = 1,
                            Genre = "Educatief",
                            PublicatieDatum = new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "De Kunst van het Schrijven"
                        },
                        new
                        {
                            ISBN = "TEST-0009",
                            AuteurID = 2,
                            Genre = "Wetenschap",
                            PublicatieDatum = new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Wetenschap en Innovatie"
                        },
                        new
                        {
                            ISBN = "TEST-0010",
                            AuteurID = 3,
                            Genre = "Science Fiction",
                            PublicatieDatum = new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Een Reis door de Tijd"
                        },
                        new
                        {
                            ISBN = "TEST-0011",
                            AuteurID = 4,
                            Genre = "Mysterie",
                            PublicatieDatum = new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Het Mysterie van de Sphinx"
                        },
                        new
                        {
                            ISBN = "TEST-0012",
                            AuteurID = 5,
                            Genre = "Motivatie",
                            PublicatieDatum = new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "De Weg naar Succes"
                        },
                        new
                        {
                            ISBN = "TEST-0013",
                            AuteurID = 6,
                            Genre = "Kinderboek",
                            PublicatieDatum = new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Het Leven van een Kikker"
                        },
                        new
                        {
                            ISBN = "TEST-0014",
                            AuteurID = 7,
                            Genre = "Educatief",
                            PublicatieDatum = new DateTime(2022, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Wiskunde voor Beginners"
                        },
                        new
                        {
                            ISBN = "TEST-0015",
                            AuteurID = 8,
                            Genre = "Avontuur",
                            PublicatieDatum = new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Avonturen in de Bergen"
                        },
                        new
                        {
                            ISBN = "TEST-0016",
                            AuteurID = 9,
                            Genre = "Mysterie",
                            PublicatieDatum = new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "Het Mysterie van de Oceaan"
                        },
                        new
                        {
                            ISBN = "TEST-0017",
                            AuteurID = 10,
                            Genre = "Wetenschap",
                            PublicatieDatum = new DateTime(2019, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titel = "De Geschiedenis van Technologie"
                        });
                });

            modelBuilder.Entity("LidBoek", b =>
                {
                    b.Property<int>("LidBoekID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LidBoekID"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ISBN");

                    b.Property<DateTime?>("InleverDatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LidID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UitleenDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("LidBoekID");

                    b.HasIndex("ISBN");

                    b.HasIndex("LidID");

                    b.ToTable("LidBoeken");
                });

            modelBuilder.Entity("Boek", b =>
                {
                    b.HasOne("BibliotheekApp.Models.Auteur", "Auteur")
                        .WithMany("Boeken")
                        .HasForeignKey("AuteurID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotheekApp.Models.Lid", "Lid")
                        .WithMany()
                        .HasForeignKey("LidID");

                    b.Navigation("Auteur");

                    b.Navigation("Lid");
                });

            modelBuilder.Entity("LidBoek", b =>
                {
                    b.HasOne("Boek", "Boek")
                        .WithMany("LidBoeken")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotheekApp.Models.Lid", "Lid")
                        .WithMany("GeleendeBoeken")
                        .HasForeignKey("LidID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Boek");

                    b.Navigation("Lid");
                });

            modelBuilder.Entity("BibliotheekApp.Models.Auteur", b =>
                {
                    b.Navigation("Boeken");
                });

            modelBuilder.Entity("BibliotheekApp.Models.Lid", b =>
                {
                    b.Navigation("GeleendeBoeken");
                });

            modelBuilder.Entity("Boek", b =>
                {
                    b.Navigation("LidBoeken");
                });
#pragma warning restore 612, 618
        }
    }
}
