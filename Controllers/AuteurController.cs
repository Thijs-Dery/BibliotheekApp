using BibliotheekApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // READ
        public List<Auteur> GetAlleAuteurs()
        {
            return _context.Auteurs.ToList();
        }

        // CREATE
        public void VoegAuteurToe(string naam, DateTime geboorteDatum)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(naam))
                {
                    MessageBox.Show("Naam mag niet leeg zijn.", "Fout", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var bestaandeAuteur = _context.Auteurs.IgnoreQueryFilters()
                                          .FirstOrDefault(a => a.Naam == naam && a.GeboorteDatum == geboorteDatum);

                if (bestaandeAuteur != null)
                {
                    if (bestaandeAuteur.IsDeleted)
                    {
                        bestaandeAuteur.IsDeleted = false;
                        _context.SaveChanges();
                        MessageBox.Show("Auteur opnieuw geactiveerd!");
                        return;
                    }

                    MessageBox.Show("Deze auteur bestaat al in de database.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var auteur = new Auteur
                {
                    Naam = naam,
                    GeboorteDatum = geboorteDatum,
                    IsDeleted = false
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



        // UPDATE
        public void UpdateAuteur(int auteurId, string naam, DateTime geboorteDatum)
        {
            try
            {
                var auteur = _context.Auteurs.Find(auteurId);
                if (auteur != null)
                {
                    auteur.Naam = naam;
                    auteur.GeboorteDatum = geboorteDatum;
                    _context.SaveChanges();
                    MessageBox.Show("Auteur succesvol bijgewerkt!");
                }
                else
                {
                    MessageBox.Show("Auteur niet gevonden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het bijwerken van de auteur: {ex.Message}");
            }
        }

        // DELETE
        public void DeleteAuteur(int auteurId)
        {
            try
            {
                var auteur = _context.Auteurs.Find(auteurId);
                if (auteur != null)
                {
                    auteur.IsDeleted = true;
                    _context.SaveChanges();
                    MessageBox.Show("Auteur succesvol verwijderd (soft-delete)!");
                }
                else
                {
                    MessageBox.Show("Auteur niet gevonden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van de auteur: {ex.Message}");
            }
        }
    }
}



