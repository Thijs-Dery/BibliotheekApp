using System.Windows;
using BibliotheekApp.Views;

namespace BibliotheekApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BoekenToevoegen_Click(object sender, RoutedEventArgs e)
        {
            var boekenToevoegenWindow = new Window
            {
                Title = "Boeken Toevoegen",
                Content = new BoekenToevoegenControl(),
                Width = 600,
                Height = 400
            };
            boekenToevoegenWindow.Show();
        }

        private void AuteursToevoegen_Click(object sender, RoutedEventArgs e)
        {
            var auteursToevoegenWindow = new Window
            {
                Title = "Auteurs Toevoegen",
                Content = new AuteursToevoegenControl(),
                Width = 600,
                Height = 400
            };
            auteursToevoegenWindow.Show();
        }

        private void LedenToevoegen_Click(object sender, RoutedEventArgs e)
        {
            var ledenToevoegenWindow = new Window
            {
                Title = "Leden Toevoegen",
                Content = new LedenToevoegenControl(),
                Width = 600,
                Height = 400
            };
            ledenToevoegenWindow.Show();
        }

        private void OpenBoekenLijst_Click(object sender, RoutedEventArgs e)
        {
            var boekenLijstWindow = new Window
            {
                Title = "Boeken Lijst",
                Content = new BoekenLijstControl(),
                Width = 1050,
                Height = 600
            };
            boekenLijstWindow.Show();
        }

        private void OpenAuteursLijst_Click(object sender, RoutedEventArgs e)
        {
            var auteursLijstWindow = new Window
            {
                Title = "Auteurs Lijst",
                Content = new AuteursLijstControl(),
                Width = 650,
                Height = 600
            };
            auteursLijstWindow.Show();
        }

        private void OpenLedenLijst_Click(object sender, RoutedEventArgs e)
        {
            var ledenLijstWindow = new Window
            {
                Title = "Leden Lijst",
                Content = new LedenLijstControl(),
                Width = 860,
                Height = 600
            };
            ledenLijstWindow.Show();
        }

        private void BekijkAlleGeleendeBoeken_Click(object sender, RoutedEventArgs e)
        {
            var alleGeleendeBoekenWindow = new Window
            {
                Title = "Alle Geleende Boeken",
                Content = new AllGeleendeBoekenControl(),
                Width = 800,
                Height = 600
            };
            alleGeleendeBoekenWindow.Show();
        }
    }
}

