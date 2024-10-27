using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BibliotheekApp.Models
{
    public class BibliotheekContext : DbContext
    {
        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Lid> Leden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=BibliotheekDB;Trusted_Connection=True;",
            options => options.EnableRetryOnFailure()
            ).LogTo(Console.WriteLine);



        }
    }
}
