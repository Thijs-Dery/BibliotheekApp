using System;
using System.Windows;
using System.Windows.Controls;
using BibliotheekApp.Controllers;
using BibliotheekApp.Models;

namespace BibliotheekApp.Views
{
    public partial class BoekenToevoegenControl : UserControl
    {
        private readonly BoekController _boekController;

        public BoekenToevoegenControl()
        {
            InitializeComponent();
            _boekController = new BoekController();

            // Vul de AuteurComboBox met auteurs
            var auteurController = new AuteurController();
            List<Auteur> auteurs = auteurController.GetAlleAuteurs();
            AuteurComboBox.ItemsSource = auteurs;
        }

        private void VoegBoekToe_Click(object sender, RoutedEventArgs e)
        {
            string isbn = ISBNLeeglatenCheckBox.IsChecked == true ? null : ISBNTextBox.Text;

            string titel = TitelTextBox.Text;
            string genre = GenreTextBox.Text;
            DateTime? publicatieDatum = PublicatieDatumPicker.SelectedDate;
            int? auteurId = (int?)AuteurComboBox.SelectedValue;

            // Controleer of verplichte velden zijn ingevuld
            if (auteurId == null || string.IsNullOrWhiteSpace(titel) || string.IsNullOrWhiteSpace(genre) || (!(ISBNLeeglatenCheckBox.IsChecked ?? false) && string.IsNullOrWhiteSpace(isbn)) || !publicatieDatum.HasValue)
            {
                MessageBox.Show("Vul alle velden in en selecteer een geldige auteur.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var boekController = new BoekController();
            boekController.VoegBoekToe(titel, genre, publicatieDatum.Value, auteurId.Value, isbn);

            // Maak de invoervelden leeg
            TitelTextBox.Text = "";
            GenreTextBox.Text = "";
            PublicatieDatumPicker.SelectedDate = null;
            ISBNTextBox.Text = "";
            ISBNLeeglatenCheckBox.IsChecked = false; // Reset de checkbox
            AuteurComboBox.SelectedIndex = -1; // Reset de selectie
        }


        private void ISBNLeeglatenCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ISBNTextBox.IsEnabled = false; // maak oninvulbaar
            ISBNTextBox.Text = ""; // Maak het veld leeg voor de duidelijkheid
        }

        private void ISBNLeeglatenCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ISBNTextBox.IsEnabled = true; // Maak weer invulbaar
        }

        private void Sluit_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}


