using System;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class BoekenToevoegenControl : UserControl
    {
        public BoekenToevoegenControl()
        {
            InitializeComponent();
        }

        private void VoegBoekToe_Click(object sender, RoutedEventArgs e)
        {
            // Hier zou je de logica toevoegen om het boek toe te voegen aan de database
            string titel = TitelTextBox.Text;
            string genre = GenreTextBox.Text;
            DateTime publicatieDatum = PublicatieDatumPicker.SelectedDate ?? DateTime.Now;
            int auteurID;

            if (int.TryParse(AuteurIDTextBox.Text, out auteurID))
            {
                // Voeg hier de logica toe om het boek op te slaan in de database met Entity Framework
                MessageBox.Show($"Boek toegevoegd: {titel}, Genre: {genre}, Publicatie Datum: {publicatieDatum.ToShortDateString()}, Auteur ID: {auteurID}");
            }
            else
            {
                MessageBox.Show("Voer een geldig Auteur ID in.");
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

