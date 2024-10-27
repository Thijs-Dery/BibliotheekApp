using BibliotheekApp.Models;
using BibliotheekApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Controllers
{
    public class BoekController
    {
        private readonly BibliotheekContext _context;

        public BoekController()
        {
            _context = new BibliotheekContext();
        }

        public UserControl GetBoekenToevoegenView()
        {
            return new BoekenToevoegenControl();
        }

        // CREATE
        public void VoegBoekToe(string titel, string genre, DateTime publicatieDatum, int auteurId, string isbn)
        {
            try
            {
                var boek = new Boek
                {
                    ISBN = isbn,
                    Titel = titel,
                    Genre = genre,
                    PublicatieDatum = publicatieDatum,
                    AuteurID = auteurId
                };

                _context.Boeken.Add(boek);
                _context.SaveChanges();
                MessageBox.Show("Boek succesvol toegevoegd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van het boek: {ex.Message}");
            }
        }

        // READ
        public List<Boek> GetBoeken()
        {
            return _context.Boeken.ToList();
        }

        // UPDATE
        public void UpdateBoek(string isbn, string titel, string genre, DateTime publicatieDatum)
        {
            try
            {
                var boek = _context.Boeken.Find(isbn);
                if (boek != null)
                {
                    boek.Titel = titel;
                    boek.Genre = genre;
                    boek.PublicatieDatum = publicatieDatum;

                    _context.SaveChanges();
                    MessageBox.Show("Boek succesvol bijgewerkt!");
                }
                else
                {
                    MessageBox.Show("Boek niet gevonden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het bijwerken van het boek: {ex.Message}");
            }
        }

        // DELETE
        public void DeleteBoek(string isbn)
        {
            try
            {
                var boek = _context.Boeken.Find(isbn);
                if (boek != null)
                {
                    _context.Boeken.Remove(boek);
                    _context.SaveChanges();
                    MessageBox.Show("Boek succesvol verwijderd!");
                }
                else
                {
                    MessageBox.Show("Boek niet gevonden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van het boek: {ex.Message}");
            }
        }
    }
}


