using BibliotheekApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BibliotheekApp.Controllers
{
    public class LidController
    {
        private readonly BibliotheekContext _context;

        public LidController()
        {
            _context = new BibliotheekContext();
        }

        // CREATE
        public bool VoegLidToe(string naam, DateTime geboorteDatum)
        {
            try
            {
                var bestaandeLid = _context.Leden.FirstOrDefault(l => l.Naam == naam && l.GeboorteDatum == geboorteDatum);

                if (bestaandeLid != null)
                {
                    MessageBox.Show("Dit lid bestaat al in de database.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                var lid = new Lid
                {
                    Naam = naam,
                    GeboorteDatum = geboorteDatum
                };

                _context.Leden.Add(lid);
                _context.SaveChanges();
                MessageBox.Show("Lid succesvol toegevoegd!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van het lid: {ex.Message}");
                return false;
            }
        }

        // READ
        public List<Lid> GetAlleLeden()
        {
            try
            {
                return _context.Leden
                               .Include(l => l.GeleendeBoeken)
                               .ThenInclude(gb => gb.Boek)
                               .Select(l => new Lid
                               {
                                   LidID = l.LidID,
                                   Naam = l.Naam,
                                   GeboorteDatum = l.GeboorteDatum,
                                   GeleendeBoeken = l.GeleendeBoeken.Select(gb => new LidBoek
                                   {
                                       LidID = gb.LidID,
                                       ISBN = gb.ISBN,
                                       Boek = new Boek
                                       {
                                           ISBN = gb.Boek.ISBN,
                                           Titel = gb.Boek.Titel
                                       },
                                       UitleenDatum = gb.UitleenDatum
                                   }).ToList()
                               })
                               .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het laden van de leden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<Lid>();
            }
        }



        // UPDATE
        public bool UpdateLid(int lidId, string naam, DateTime geboorteDatum)
        {
            try
            {
                var lid = _context.Leden.Find(lidId);
                if (lid == null)
                {
                    MessageBox.Show("Lid niet gevonden.");
                    return false;
                }

                lid.Naam = naam;
                lid.GeboorteDatum = geboorteDatum;
                _context.SaveChanges();
                MessageBox.Show("Lid succesvol bijgewerkt!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het bijwerken van het lid: {ex.Message}");
                return false;
            }
        }

        public bool VoegBoekToeAanLid(int lidId, string isbn)
        {
            var lid = _context.Leden.Include(l => l.GeleendeBoeken).FirstOrDefault(l => l.LidID == lidId);
            var boek = _context.Boeken.FirstOrDefault(b => b.ISBN == isbn);

            if (lid == null)
            {
                MessageBox.Show("Lid niet gevonden.");
                return false;
            }

            if (boek == null)
            {
                MessageBox.Show("Boek niet gevonden.");
                return false;
            }

            // Controleer of het boek al is uitgeleend
            if (boek.LidID != null)
            {
                MessageBox.Show("Dit boek is al uitgeleend aan een ander lid.");
                return false;
            }

            // Voeg een nieuwe entry toe aan LidBoeken
            var lidBoek = new LidBoek
            {
                LidID = lidId,
                ISBN = isbn,
                UitleenDatum = DateTime.Now
            };

            _context.LidBoeken.Add(lidBoek);
            _context.SaveChanges();
            return true;
        }

        public bool VerwijderBoekVanLid(int lidId, string isbn)
        {
            var lidBoek = _context.LidBoeken.FirstOrDefault(lb => lb.LidID == lidId && lb.ISBN == isbn);

            if (lidBoek == null)
            {
                MessageBox.Show("Boek niet gevonden of is niet uitgeleend aan dit lid.");
                return false;
            }

            _context.LidBoeken.Remove(lidBoek);
            _context.SaveChanges();
            return true;
        }

        public List<LidBoek> GetAllGeleendeBoeken()
        {
            return _context.LidBoeken.Include(lb => lb.Boek).ToList();
        }

        // DELETE
        public bool DeleteLid(int lidId)
        {
            try
            {
                var lid = _context.Leden.Include(l => l.GeleendeBoeken).FirstOrDefault(l => l.LidID == lidId);
                if (lid == null)
                {
                    MessageBox.Show("Lid niet gevonden.");
                    return false;
                }

                // Eventuele geleende boeken loskoppelen
                foreach (var boek in lid.GeleendeBoeken)
                {
                    boek.LidID = null;
                }

                _context.Leden.Remove(lid);
                _context.SaveChanges();
                MessageBox.Show("Lid succesvol verwijderd!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van het lid: {ex.Message}");
                return false;
            }
        }
    }
}



