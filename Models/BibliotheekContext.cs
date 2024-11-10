using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using BibliotheekApp.Models;


namespace BibliotheekApp.Models
{
    public class BibliotheekContext : DbContext
    {
        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Lid> Leden { get; set; }
        public DbSet<LidBoek> LidBoeken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=BibliotheekDB;Trusted_Connection=True;",
                options => options.EnableRetryOnFailure()
            ).LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primaire sleutels en relaties
            modelBuilder.Entity<LidBoek>()
                .HasKey(lb => lb.LidBoekID);

            modelBuilder.Entity<LidBoek>()
                .HasOne(lb => lb.Lid)
                .WithMany(l => l.GeleendeBoeken)
                .HasForeignKey(lb => lb.LidID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LidBoek>()
                .HasOne(lb => lb.Boek)
                .WithMany(b => b.LidBoeken)
                .HasForeignKey(lb => lb.ISBN)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Boek>()
                .HasOne(b => b.Auteur)
                .WithMany(a => a.Boeken)
                .HasForeignKey(b => b.AuteurID)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data voor Auteurs
            modelBuilder.Entity<Auteur>().HasData(
                new Auteur { AuteurID = 1, Naam = "Auteur 1", GeboorteDatum = new DateTime(1975, 4, 10) },
                new Auteur { AuteurID = 2, Naam = "Auteur 2", GeboorteDatum = new DateTime(1980, 6, 5) },
                new Auteur { AuteurID = 3, Naam = "Auteur 3", GeboorteDatum = new DateTime(1995, 9, 18) },
                new Auteur { AuteurID = 4, Naam = "Auteur 4", GeboorteDatum = new DateTime(1978, 11, 23) },
                new Auteur { AuteurID = 5, Naam = "Auteur 5", GeboorteDatum = new DateTime(1969, 2, 14) },
                new Auteur { AuteurID = 6, Naam = "Auteur 6", GeboorteDatum = new DateTime(1985, 8, 30) },
                new Auteur { AuteurID = 7, Naam = "Auteur 7", GeboorteDatum = new DateTime(1990, 1, 1) },
                new Auteur { AuteurID = 8, Naam = "Auteur 8", GeboorteDatum = new DateTime(1993, 3, 25) },
                new Auteur { AuteurID = 9, Naam = "Auteur 9", GeboorteDatum = new DateTime(1982, 7, 5) },
                new Auteur { AuteurID = 10, Naam = "Auteur 10", GeboorteDatum = new DateTime(1971, 6, 17) }
            );

            // Seed data voor Leden
            modelBuilder.Entity<Lid>().HasData(
                new Lid { LidID = 1, Naam = "Freddy", GeboorteDatum = new DateTime(1990, 5, 1) },
                new Lid { LidID = 2, Naam = "Jochim", GeboorteDatum = new DateTime(1985, 3, 15) },
                new Lid { LidID = 3, Naam = "Jos", GeboorteDatum = new DateTime(2000, 7, 20) },
                new Lid { LidID = 4, Naam = "Sofie", GeboorteDatum = new DateTime(1992, 12, 1) },
                new Lid { LidID = 5, Naam = "Lars", GeboorteDatum = new DateTime(1988, 10, 10) },
                new Lid { LidID = 6, Naam = "Emma", GeboorteDatum = new DateTime(1995, 4, 19) },
                new Lid { LidID = 7, Naam = "Daan", GeboorteDatum = new DateTime(1993, 2, 8) },
                new Lid { LidID = 8, Naam = "Mila", GeboorteDatum = new DateTime(1997, 8, 15) },
                new Lid { LidID = 9, Naam = "Bram", GeboorteDatum = new DateTime(1991, 11, 30) },
                new Lid { LidID = 10, Naam = "Lise", GeboorteDatum = new DateTime(1999, 9, 23) },
                new Lid { LidID = 11, Naam = "Hugo", GeboorteDatum = new DateTime(1996, 5, 4) },
                new Lid { LidID = 12, Naam = "Nina", GeboorteDatum = new DateTime(1994, 6, 13) },
                new Lid { LidID = 13, Naam = "Tim", GeboorteDatum = new DateTime(1998, 3, 17) },
                new Lid { LidID = 14, Naam = "Laura", GeboorteDatum = new DateTime(1987, 7, 7) },
                new Lid { LidID = 15, Naam = "Sven", GeboorteDatum = new DateTime(1990, 1, 21) }
            );

            // Seed data voor Boeken
            modelBuilder.Entity<Boek>().HasData(
                new Boek { ISBN = "9781402894626", Titel = "Frieda Kroket", Genre = "Koken", PublicatieDatum = new DateTime(2020, 1, 1), AuteurID = 1 },
                new Boek { ISBN = "9783161484100", Titel = "Koken met Henk", Genre = "Koken", PublicatieDatum = new DateTime(2021, 2, 2), AuteurID = 2 },
                new Boek { ISBN = "TEST-010e1999", Titel = "Wdsawd", Genre = "Fictie", PublicatieDatum = new DateTime(2022, 3, 3), AuteurID = 3 },
                new Boek { ISBN = "TEST-0001", Titel = "De Avonturen van Bob", Genre = "Avontuur", PublicatieDatum = new DateTime(2019, 5, 6), AuteurID = 4 },
                new Boek { ISBN = "TEST-0002", Titel = "Het Geheim van de Tuin", Genre = "Mysterie", PublicatieDatum = new DateTime(2018, 8, 11), AuteurID = 5 },
                new Boek { ISBN = "TEST-0003", Titel = "Zomer in Parijs", Genre = "Romantiek", PublicatieDatum = new DateTime(2020, 7, 20), AuteurID = 6 },
                new Boek { ISBN = "TEST-0004", Titel = "Programmeren in C#", Genre = "Educatief", PublicatieDatum = new DateTime(2021, 9, 10), AuteurID = 7 },
                new Boek { ISBN = "TEST-0005", Titel = "De Keukenprinses", Genre = "Koken", PublicatieDatum = new DateTime(2022, 1, 15), AuteurID = 8 },
                new Boek { ISBN = "TEST-0006", Titel = "Reizen door Europa", Genre = "Reizen", PublicatieDatum = new DateTime(2017, 4, 3), AuteurID = 9 },
                new Boek { ISBN = "TEST-0007", Titel = "Geschiedenis van de Wereld", Genre = "Geschiedenis", PublicatieDatum = new DateTime(2015, 11, 5), AuteurID = 10 },
                new Boek { ISBN = "TEST-0008", Titel = "De Kunst van het Schrijven", Genre = "Educatief", PublicatieDatum = new DateTime(2023, 2, 25), AuteurID = 1 },
                new Boek { ISBN = "TEST-0009", Titel = "Wetenschap en Innovatie", Genre = "Wetenschap", PublicatieDatum = new DateTime(2022, 5, 18), AuteurID = 2 },
                new Boek { ISBN = "TEST-0010", Titel = "Een Reis door de Tijd", Genre = "Science Fiction", PublicatieDatum = new DateTime(2021, 6, 12), AuteurID = 3 },
                new Boek { ISBN = "TEST-0011", Titel = "Het Mysterie van de Sphinx", Genre = "Mysterie", PublicatieDatum = new DateTime(2019, 10, 4), AuteurID = 4 },
                new Boek { ISBN = "TEST-0012", Titel = "De Weg naar Succes", Genre = "Motivatie", PublicatieDatum = new DateTime(2020, 3, 28), AuteurID = 5 },
                new Boek { ISBN = "TEST-0013", Titel = "Het Leven van een Kikker", Genre = "Kinderboek", PublicatieDatum = new DateTime(2021, 8, 30), AuteurID = 6 },
                new Boek { ISBN = "TEST-0014", Titel = "Wiskunde voor Beginners", Genre = "Educatief", PublicatieDatum = new DateTime(2022, 9, 21), AuteurID = 7 },
                new Boek { ISBN = "TEST-0015", Titel = "Avonturen in de Bergen", Genre = "Avontuur", PublicatieDatum = new DateTime(2023, 7, 14), AuteurID = 8 },
                new Boek { ISBN = "TEST-0016", Titel = "Het Mysterie van de Oceaan", Genre = "Mysterie", PublicatieDatum = new DateTime(2018, 11, 8), AuteurID = 9 },
                new Boek { ISBN = "TEST-0017", Titel = "De Geschiedenis van Technologie", Genre = "Wetenschap", PublicatieDatum = new DateTime(2019, 12, 22), AuteurID = 10 }
            );
        }

    }
}

