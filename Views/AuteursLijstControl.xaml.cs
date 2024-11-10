﻿using BibliotheekApp.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;
using BibliotheekApp.Views;

namespace BibliotheekApp.Views
{
    public partial class AuteursLijstControl : UserControl
    {
        private readonly AuteurController _auteurController;

        public AuteursLijstControl()
        {
            InitializeComponent();
            _auteurController = new AuteurController();
            AuteursDataGrid.ItemsSource = _auteurController.GetAlleAuteurs();
        }

        private void AuteurToevoegen_Click(object sender, RoutedEventArgs e)
        {
            var auteursToevoegenWindow = new Window
            {
                Title = "Auteur Toevoegen",
                Content = new AuteursToevoegenControl(),
                Width = 600,
                Height = 400
            };
            auteursToevoegenWindow.Show();
        }

        private void UpdateAuteur_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int auteurId = (int)button.Tag;

            var auteur = _auteurController.GetAlleAuteurs().Find(a => a.AuteurID == auteurId);
            if (auteur != null)
            {
                string nieuweNaam = Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe naam:", "Update Auteur", auteur.Naam);
                DateTime nieuweGeboorteDatum = DateTime.Parse(Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe geboortedatum:", "Update Auteur", auteur.GeboorteDatum.ToString("dd-MM-yyyy")));

                _auteurController.UpdateAuteur(auteurId, nieuweNaam, nieuweGeboorteDatum);
                AuteursDataGrid.ItemsSource = _auteurController.GetAlleAuteurs(); // Refresh lijst
            }
        }

        private void DeleteAuteur_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int auteurId = (int)button.Tag;

            var result = MessageBox.Show("Weet je zeker dat je deze auteur wilt verwijderen?", "Bevestig Verwijdering", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _auteurController.DeleteAuteur(auteurId);
                AuteursDataGrid.ItemsSource = _auteurController.GetAlleAuteurs(); // Refresh lijst
            }
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }
    }
}


