using BibliotheekApp.Models;
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
        public void VoegLidToe(string naam, DateTime geboorteDatum)
        {
            try
            {
                var bestaandeLid = _context.Leden.FirstOrDefault(l => l.Naam == naam && l.GeboorteDatum == geboorteDatum);

                if (bestaandeLid != null)
                {
                    MessageBox.Show("Dit lid bestaat al in de database.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var lid = new Lid
                {
                    Naam = naam,
                    GeboorteDatum = geboorteDatum
                };

                _context.Leden.Add(lid);
                _context.SaveChanges();
                MessageBox.Show("Lid succesvol toegevoegd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van het lid: {ex.Message}");
            }
        }

        // READ
        public List<Lid> GetAlleLeden()
        {
            return _context.Leden.ToList();
        }

        // UPDATE
        public void UpdateLid(int lidId, string naam, DateTime geboorteDatum)
        {
            try
            {
                var lid = _context.Leden.Find(lidId);
                if (lid != null)
                {
                    lid.Naam = naam;
                    lid.GeboorteDatum = geboorteDatum;
                    _context.SaveChanges();
                    MessageBox.Show("Lid succesvol bijgewerkt!");
                }
                else
                {
                    MessageBox.Show("Lid niet gevonden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het bijwerken van het lid: {ex.Message}");
            }
        }

        // DELETE
        public void DeleteLid(int lidId)
        {
            try
            {
                var lid = _context.Leden.Find(lidId);
                if (lid != null)
                {
                    _context.Leden.Remove(lid);
                    _context.SaveChanges();
                    MessageBox.Show("Lid succesvol verwijderd!");
                }
                else
                {
                    MessageBox.Show("Lid niet gevonden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van het lid: {ex.Message}");
            }
        }
    }
}


