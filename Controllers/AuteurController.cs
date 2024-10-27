using BibliotheekApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

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
                var auteur = new Auteur
                {
                    Naam = naam,
                    GeboorteDatum = geboorteDatum
                };

                _context.Auteurs.Add(auteur);
                _context.SaveChanges();
                MessageBox.Show("Auteur succesvol toegevoegd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van de auteur: {ex.Message}");
            }
        }
    }
}

