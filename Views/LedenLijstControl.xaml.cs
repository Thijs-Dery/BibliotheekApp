﻿using BibliotheekApp.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;
using BibliotheekApp.Views;
using System.Windows.Input;

namespace BibliotheekApp.Views
{
    public partial class LedenLijstControl : UserControl
    {
        private readonly LidController _lidController;
        private Window _ledenToevoegenWindow;
        private Window _geleendeBoekenWindow;

        public LedenLijstControl()
        {
            InitializeComponent();
            _lidController = new LidController();
            try
            {
                LedenDataGrid.ItemsSource = _lidController.GetAlleLeden();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het laden van de leden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LidToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (_ledenToevoegenWindow == null || !_ledenToevoegenWindow.IsVisible)
            {
                _ledenToevoegenWindow = new Window
                {
                    Title = "Lid Toevoegen",
                    Content = new LedenToevoegenControl(),
                    Width = 400,
                    Height = 400
                };
                _ledenToevoegenWindow.Closed += (s, args) => _ledenToevoegenWindow = null;
                _ledenToevoegenWindow.Show();
            }
            else
            {
                _ledenToevoegenWindow.Focus();
            }
        }

        private void BewerkLid_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            var lid = _lidController.GetAlleLeden().Find(l => l.LidID == lidId);
            if (lid != null)
            {
                string nieuweNaam = Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe naam:", "Update Lid", lid.Naam);
                string inputDatum = Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe geboortedatum:", "Update Lid", lid.GeboorteDatum.ToString("dd-MM-yyyy"));
                DateTime nieuweGeboorteDatum;
                if (!DateTime.TryParse(inputDatum, out nieuweGeboorteDatum))
                {
                    MessageBox.Show("Ongeldige datum ingevoerd of actie geannuleerd.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                _lidController.UpdateLid(lidId, nieuweNaam, nieuweGeboorteDatum);
                LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
            }
        }

        private void VerwijderLid_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            var result = MessageBox.Show("Weet je zeker dat je dit lid wilt verwijderen?", "Bevestig Verwijdering", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                bool success = _lidController.DeleteLid(lidId);
                if (success)
                {
                    LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
                }
            }
        }


        private void Sluit_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void BekijkGeleendeBoeken_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            var lid = _lidController.GetAlleLeden().FirstOrDefault(l => l.LidID == lidId);
            if (lid != null)
            {
                if (_geleendeBoekenWindow == null || !_geleendeBoekenWindow.IsVisible)
                {
                    _geleendeBoekenWindow = new GeleendeBoekenWindow(lid);
                    _geleendeBoekenWindow.Closed += (s, args) => _geleendeBoekenWindow = null;
                    _geleendeBoekenWindow.Show();
                }
                else
                {
                    _geleendeBoekenWindow.Focus();
                }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
        }

        private void ZoekTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            var zoekTerm = ZoekTextBox.Text.ToLower();
            var alleLeden = _lidController.GetAlleLeden();

            var gefilterdeLeden = alleLeden
                .Where(l => l.Naam.ToLower().Contains(zoekTerm) ||
                            l.LidID.ToString().Contains(zoekTerm))
                .ToList();

            LedenDataGrid.ItemsSource = gefilterdeLeden;
        }
    }
}






