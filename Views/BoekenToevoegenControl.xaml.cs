﻿using System;
using System.Windows;
using System.Windows.Controls;
using BibliotheekApp.Controllers;

namespace BibliotheekApp.Views
{
    public partial class BoekenToevoegenControl : UserControl
    {
        private readonly BoekController _boekController;

        public BoekenToevoegenControl()
        {
            InitializeComponent();
            _boekController = new BoekController();
        }

        private void VoegBoekToe_Click(object sender, RoutedEventArgs e)
        {
            string titel = TitelTextBox.Text;
            string genre = GenreTextBox.Text;
            DateTime? publicatieDatum = PublicatieDatumPicker.SelectedDate;
            string isbn = ISBNTextBox.Text;
            bool auteurIdParseSuccess = int.TryParse(AuteurIDTextBox.Text, out int auteurId);

            if (string.IsNullOrWhiteSpace(titel) || string.IsNullOrWhiteSpace(genre) || string.IsNullOrWhiteSpace(isbn) || !publicatieDatum.HasValue || !auteurIdParseSuccess)
            {
                MessageBox.Show("Vul alle velden in en zorg dat Auteur ID een geldig nummer is.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Voeg het boek toe via de controller
            _boekController.VoegBoekToe(titel, genre, publicatieDatum.Value, auteurId, isbn);

            // Maak de invoervelden leeg
            TitelTextBox.Text = "";
            GenreTextBox.Text = "";
            PublicatieDatumPicker.SelectedDate = null;
            AuteurIDTextBox.Text = "";
            ISBNTextBox.Text = "";
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }
    }
}


