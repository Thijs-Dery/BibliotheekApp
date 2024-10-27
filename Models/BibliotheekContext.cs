using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

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
            // Configuratie voor LidBoek-relatie
            modelBuilder.Entity<LidBoek>()
                .HasKey(lb => lb.LidBoekID); // Primaire sleutel voor LidBoek

            modelBuilder.Entity<LidBoek>()
                .HasOne(lb => lb.Lid)
                .WithMany(l => l.GeleendeBoeken) // Navigatie-eigenschap in Lid-model
                .HasForeignKey(lb => lb.LidID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LidBoek>()
                .HasOne(lb => lb.Boek)
                .WithMany() // Boek hoeft geen lijst van geleende boeken te hebben
                .HasForeignKey(lb => lb.ISBN)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuratie voor Boek-Auteur relatie
            modelBuilder.Entity<Boek>()
                .HasOne(b => b.Auteur)
                .WithMany(a => a.Boeken)
                .HasForeignKey(b => b.AuteurID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

