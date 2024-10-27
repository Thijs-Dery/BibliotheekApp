using BibliotheekApp.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class BoekenLijstControl : UserControl
    {
        private readonly BoekController _boekController;

        public BoekenLijstControl()
        {
            InitializeComponent();
            _boekController = new BoekController();
            BoekenDataGrid.ItemsSource = _boekController.GetAlleBoeken();
        }

        private void UpdateBoek_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string isbn = (string)button.Tag;

            var boek = _boekController.GetAlleBoeken().Find(b => b.ISBN == isbn);
            if (boek != null)
            {
                string nieuweTitel = Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe titel:", "Update Boek", boek.Titel);
                string nieuwGenre = Microsoft.VisualBasic.Interaction.InputBox("Geef het nieuwe genre:", "Update Boek", boek.Genre);
                DateTime nieuwePublicatieDatum = DateTime.Parse(Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe publicatiedatum:", "Update Boek", boek.PublicatieDatum.ToString("dd-MM-yyyy")));

                _boekController.UpdateBoek(isbn, nieuweTitel, nieuwGenre, nieuwePublicatieDatum);
                BoekenDataGrid.ItemsSource = _boekController.GetAlleBoeken(); // Refresh lijst
            }
        }

        private void DeleteBoek_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string isbn = (string)button.Tag;

            var result = MessageBox.Show("Weet je zeker dat je dit boek wilt verwijderen?", "Bevestig Verwijdering", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _boekController.DeleteBoek(isbn);
                BoekenDataGrid.ItemsSource = _boekController.GetAlleBoeken(); // Refresh lijst
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


