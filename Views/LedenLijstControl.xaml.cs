using BibliotheekApp.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class LedenLijstControl : UserControl
    {
        private readonly LidController _lidController;

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

        private void BewerkLid_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            var lid = _lidController.GetAlleLeden().Find(l => l.LidID == lidId);
            if (lid != null)
            {
                string nieuweNaam = Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe naam:", "Update Lid", lid.Naam);
                DateTime nieuweGeboorteDatum = DateTime.Parse(Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe geboortedatum:", "Update Lid", lid.GeboorteDatum.ToString("dd-MM-yyyy")));

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
                _lidController.DeleteLid(lidId);
                LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
            }
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }

        private void VoegBoekToeAanLid_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            string isbn = Microsoft.VisualBasic.Interaction.InputBox("Voer het ISBN in van het boek dat je wilt toevoegen:", "Boek Toevoegen");
            if (!string.IsNullOrEmpty(isbn))
            {
                bool result = _lidController.VoegBoekToeAanLid(lidId, isbn);
                if (result)
                {
                    MessageBox.Show("Boek succesvol toegevoegd aan het lid!");
                }
                else
                {
                    MessageBox.Show("Er is een fout opgetreden. Controleer of het boek bestaat en nog niet is uitgeleend.");
                }
                LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
            }
        }

        private void VerwijderBoekVanLid_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            string isbn = Microsoft.VisualBasic.Interaction.InputBox("Voer het ISBN in van het boek dat je wilt verwijderen:", "Boek Verwijderen");
            if (!string.IsNullOrEmpty(isbn))
            {
                bool result = _lidController.VerwijderBoekVanLid(lidId, isbn);
                if (result)
                {
                    MessageBox.Show("Boek succesvol verwijderd van het lid!");
                }
                else
                {
                    MessageBox.Show("Er is een fout opgetreden. Controleer of het boek aan dit lid is uitgeleend.");
                }
                LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
            }
        }

        private void BekijkGeleendeBoeken_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            var lid = _lidController.GetAlleLeden().FirstOrDefault(l => l.LidID == lidId);
            if (lid != null)
            {
                GeleendeBoekenWindow boekenWindow = new GeleendeBoekenWindow(lid);
                boekenWindow.Show();
            }
        }
    }
}




