using BibliotheekApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using System.Linq;


namespace BibliotheekApp.Controllers
{
    public class AuteurController
    {
        private readonly BibliotheekContext _context;

        public AuteurController()
        {
            _context = new BibliotheekContext();
        }

        public void VoegAuteurToe(string naam, DateTime geboorteDatum)
        {
            try
            {
                var bestaandeAuteur = _context.Auteurs
                    .FirstOrDefault(a => a.Naam == naam && a.GeboorteDatum == geboorteDatum);

                if (bestaandeAuteur != null)
                {
                    MessageBox.Show("Deze auteur bestaat al in de database.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var auteur = new Auteur
                {
                    Naam = naam,
                    GeboorteDatum = geboorteDatum
                };

                _context.Auteurs.Add(auteur);
                _context.SaveChanges();

                MessageBox.Show("Auteur succesvol toegevoegd!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van de auteur: {ex.Message}");
            }
        }

    }
}

