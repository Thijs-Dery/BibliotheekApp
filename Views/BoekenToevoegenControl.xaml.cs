using System;
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
            string isbn = ISBNLeeglatenCheckBox.IsChecked == true ? null : ISBNTextBox.Text;

            string titel = TitelTextBox.Text;
            string genre = GenreTextBox.Text;
            DateTime? publicatieDatum = PublicatieDatumPicker.SelectedDate;
            bool auteurIdParseSuccess = int.TryParse(AuteurIDTextBox.Text, out int auteurId);

            // Controleer of verplichte velden zijn ingevuld
            if (string.IsNullOrWhiteSpace(titel) || string.IsNullOrWhiteSpace(genre) || (!ISBNLeeglatenCheckBox.IsChecked == true && string.IsNullOrWhiteSpace(isbn)) || !publicatieDatum.HasValue || !auteurIdParseSuccess)

            {
                MessageBox.Show("Vul alle velden in en zorg dat Auteur ID een geldig nummer is. ISBN mag alleen leeg zijn als de checkbox is aangevinkt.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var boekController = new BoekController();
            boekController.VoegBoekToe(titel, genre, publicatieDatum.Value, auteurId, isbn);

            // Maak de invoervelden leeg
            TitelTextBox.Text = "";
            GenreTextBox.Text = "";
            PublicatieDatumPicker.SelectedDate = null;
            AuteurIDTextBox.Text = "";
            ISBNTextBox.Text = "";
            ISBNLeeglatenCheckBox.IsChecked = false; // Reset de checkbox
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

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }
    }
}


