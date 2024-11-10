using BibliotheekApp.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class BoekenLijstControl : UserControl
    {
        private readonly BoekController _boekController;
        private Window _boekenToevoegenWindow;

        public BoekenLijstControl()
        {
            InitializeComponent();
            _boekController = new BoekController();
            try
            {
                BoekenDataGrid.ItemsSource = _boekController.GetAlleBoeken();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het laden van de boeken: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BoekToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (_boekenToevoegenWindow == null || !_boekenToevoegenWindow.IsVisible)
            {
                _boekenToevoegenWindow = new Window
                {
                    Title = "Boek Toevoegen",
                    Content = new BoekenToevoegenControl(),
                    Width = 450,
                    Height = 400
                };
                _boekenToevoegenWindow.Closed += (s, args) => _boekenToevoegenWindow = null;
                _boekenToevoegenWindow.Show();
            }
            else
            {
                _boekenToevoegenWindow.Focus();
            }
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

                _boekController.BewerkBoek(isbn, nieuweTitel, nieuwGenre, nieuwePublicatieDatum);
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
                _boekController.VerwijderBoek(isbn);
                BoekenDataGrid.ItemsSource = _boekController.GetAlleBoeken(); // Refresh lijst
            }
        }

        private void Sluit_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            BoekenDataGrid.ItemsSource = _boekController.GetAlleBoeken(); // Refresh lijst
        }
    }
}





