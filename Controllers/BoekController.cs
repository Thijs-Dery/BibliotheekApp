﻿using BibliotheekApp.Models;
using BibliotheekApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

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

        // Methode om te controleren of een ISBN geldig is (ISBN-10 of ISBN-13)
        public static bool IsValidISBN(string isbn)
        {
            isbn = isbn.Replace("-", "").Replace(" ", "");

            if (isbn.Length == 10 && Regex.IsMatch(isbn, @"^\d{9}[\dXx]$"))
            {
                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum += (isbn[i] - '0') * (10 - i);
                }

                char last = isbn[9];
                sum += (last == 'X' || last == 'x') ? 10 : (last - '0');

                return sum % 11 == 0;
            }
            else if (isbn.Length == 13 && Regex.IsMatch(isbn, @"^\d{13}$"))
            {
                int sum = 0;
                for (int i = 0; i < 13; i++)
                {
                    int digit = isbn[i] - '0';
                    sum += (i % 2 == 0) ? digit : digit * 3;
                }

                return sum % 10 == 0;
            }

            return false;
        }

        // CREATE
        public void VoegBoekToe(string titel, string genre, DateTime publicatieDatum, int auteurId, string isbn = null)
        {
            var auteur = _context.Auteurs.Find(auteurId);
            if (auteur == null)
            {
                MessageBox.Show("Ongeldig AuteurID. De opgegeven auteur bestaat niet.");
                return;
            }

            if (isbn == null)
            {
                isbn = GenerateTemporaryISBN();
            }
            else if (!IsValidISBN(isbn))
            {
                MessageBox.Show("Ongeldig ISBN. Voer een geldig ISBN-nummer in.");
                return;
            }

            var bestaandBoek = _context.Boeken.IgnoreQueryFilters().FirstOrDefault(b => b.ISBN == isbn);
            if (bestaandBoek != null)
            {
                if (bestaandBoek.IsDeleted)
                {
                    bestaandBoek.IsDeleted = false;
                    bestaandBoek.Titel = titel;
                    bestaandBoek.Genre = genre;
                    bestaandBoek.PublicatieDatum = publicatieDatum;
                    bestaandBoek.AuteurID = auteurId;
                    _context.SaveChanges();
                    MessageBox.Show("Boek opnieuw geactiveerd!");
                    return;
                }

                MessageBox.Show("Boek met dit ISBN bestaat al.");
                return;
            }

            try
            {
                var boek = new Boek
                {
                    ISBN = isbn,
                    Titel = titel,
                    Genre = genre,
                    PublicatieDatum = publicatieDatum,
                    AuteurID = auteurId,
                    IsDeleted = false
                };

                _context.Boeken.Add(boek);
                _context.SaveChanges();
                MessageBox.Show("Boek succesvol toegevoegd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het toevoegen van het boek: {ex.InnerException?.Message ?? ex.Message}");
            }
        }


        private string GenerateTemporaryISBN()
        {
            return "TEST-" + Guid.NewGuid().ToString().Substring(0, 8);
        }

        // READ
        public List<dynamic> GetAlleBoeken()
        {
            return _context.Boeken
                           .Include(b => b.Auteur)
                           .Include(b => b.LidBoeken)
                           .ThenInclude(lb => lb.Lid)
                           .Select(b => new
                           {
                               b.ISBN,
                               b.Titel,
                               b.Genre,
                               b.PublicatieDatum,
                               AuteurNaam = b.Auteur != null ? b.Auteur.Naam : "Onbekend",
                               LidID = b.LidBoeken.Any(lb => lb.Lid != null) ? b.LidBoeken.FirstOrDefault(lb => lb.Lid != null).Lid.LidID : (int?)null,
                               LenerNaam = b.LidBoeken.Any(lb => lb.Lid != null) ? b.LidBoeken.FirstOrDefault(lb => lb.Lid != null).Lid.Naam : "Niet uitgeleend",
                               UitleenDatum = b.LidBoeken.Any(lb => lb.Lid != null) ? b.LidBoeken.FirstOrDefault(lb => lb.Lid != null).UitleenDatum : (DateTime?)null
                           })
                           .ToList<dynamic>();
        }

        // UPDATE
        public void BewerkBoek(string isbn, string titel, string genre, DateTime publicatieDatum)
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
        public bool VerwijderBoek(string isbn)
        {
            try
            {
                var boek = _context.Boeken.Find(isbn);
                if (boek != null)
                {
                    boek.IsDeleted = true;
                    _context.SaveChanges();
                    MessageBox.Show("Boek succesvol verwijderd (soft-delete)!");
                    return true;
                }

                MessageBox.Show("Boek niet gevonden.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het verwijderen van het boek: {ex.Message}");
                return false;
            }
        }
    }
}



