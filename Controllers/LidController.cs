using BibliotheekApp.Models;
using System;
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

        public void VoegLidToe(string naam, DateTime geboorteDatum)
        {
            try
            {
                var bestaandeLid = _context.Leden
                    .FirstOrDefault(l => l.Naam == naam && l.GeboorteDatum == geboorteDatum);

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
                MessageBox.Show("Lid succesvol toegevoegd!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van het lid: {ex.Message}");
            }
        }
    }
}

