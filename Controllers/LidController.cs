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
            // Zorgt ervoor dat GeleendeBoeken ook geladen worden
            return _context.Leden.Include(l => l.GeleendeBoeken).ToList();
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

            if (boek.LidID != null)
            {
                MessageBox.Show("Dit boek is al uitgeleend aan een ander lid.");
                return false;
            }

            boek.LidID = lidId;
            _context.SaveChanges();
            return true;
        }

        public bool VerwijderBoekVanLid(int lidId, string isbn)
        {
            var boek = _context.Boeken.FirstOrDefault(b => b.ISBN == isbn && b.LidID == lidId);

            if (boek == null)
            {
                MessageBox.Show("Boek niet gevonden of is niet uitgeleend aan dit lid.");
                return false;
            }

            boek.LidID = null;
            _context.SaveChanges();
            return true;
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



