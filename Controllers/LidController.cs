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
                if (string.IsNullOrWhiteSpace(naam))
                {
                    MessageBox.Show("Naam mag niet leeg zijn.", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                var bestaandLid = _context.Leden.IgnoreQueryFilters()
                                      .FirstOrDefault(l => l.Naam == naam && l.GeboorteDatum == geboorteDatum);

                if (bestaandLid != null)
                {
                    if (bestaandLid.IsDeleted)
                    {
                        bestaandLid.IsDeleted = false;
                        _context.SaveChanges();
                        MessageBox.Show("Lid opnieuw geactiveerd!");
                        return true;
                    }

                    MessageBox.Show("Dit lid bestaat al in de database.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                var lid = new Lid
                {
                    Naam = naam,
                    GeboorteDatum = geboorteDatum,
                    IsDeleted = false
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
                               .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het laden van de leden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<Lid>();
            }
        }

        // CREATE RELATION
        public bool VoegBoekToeAanLid(int lidId, string isbn)
        {
            try
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

                // Voeg een nieuwe entry toe aan LidBoeken met een standaardwaarde voor InleverDatum
                var lidBoek = new LidBoek
                {
                    LidID = lidId,
                    ISBN = isbn,
                    UitleenDatum = DateTime.Now,
                    InleverDatum = DateTime.MaxValue // Standaardwaarde
                };

                _context.LidBoeken.Add(lidBoek);
                _context.SaveChanges();
                MessageBox.Show("Boek succesvol toegevoegd aan lid!");
                return true;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van het boek: {ex.InnerException?.Message ?? ex.Message}");
                return false;
            }
        }

        // DELETE RELATION
        public bool VerwijderBoekVanLid(int lidId, string isbn)
        {
            try
            {
                var lidBoek = _context.LidBoeken.FirstOrDefault(lb => lb.LidID == lidId && lb.ISBN == isbn);

                if (lidBoek == null)
                {
                    MessageBox.Show("Boek niet gevonden of is niet uitgeleend aan dit lid.");
                    return false;
                }

                _context.LidBoeken.Remove(lidBoek);
                _context.SaveChanges();
                MessageBox.Show("Boek succesvol verwijderd van lid!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van het boek: {ex.Message}");
                return false;
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

                // Controleer of het lid nog boeken leent
                if (lid.GeleendeBoeken.Any())
                {
                    MessageBox.Show("Dit lid kan niet worden verwijderd omdat het nog boeken leent.", "Verwijderen niet toegestaan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                lid.IsDeleted = true;
                _context.SaveChanges();
                MessageBox.Show("Lid succesvol verwijderd (soft-delete)!");
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



