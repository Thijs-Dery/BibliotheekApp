using BibliotheekApp.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class AuteursToevoegenControl : UserControl
    {
        public AuteursToevoegenControl()
        {
            InitializeComponent();
        }

        private void VoegAuteurToe_Click(object sender, RoutedEventArgs e)
        {
            string naam = NaamTextBox.Text;
            DateTime? geboorteDatum = GeboorteDatumPicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(naam) || geboorteDatum == null)
            {
                MessageBox.Show("Vul alle velden in!", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Voeg de auteur toe
            var auteurController = new AuteurController();
            auteurController.VoegAuteurToe(naam, geboorteDatum.Value);

            MessageBox.Show("Auteur succesvol toegevoegd!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

            // Velden resetten
            NaamTextBox.Text = "";
            GeboorteDatumPicker.SelectedDate = null;
        }

        private void Sluit_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}

