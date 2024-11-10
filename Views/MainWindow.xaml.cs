using System.Windows;
using BibliotheekApp.Views;

namespace BibliotheekApp
{
    public partial class MainWindow : Window
    {
        private Window _boekToevoegenWindow;
        private Window _auteursToevoegenWindow;
        private Window _ledenToevoegenWindow;
        private Window _boekenLijstWindow;
        private Window _auteursLijstWindow;
        private Window _ledenLijstWindow;
        private Window _alleGeleendeBoekenWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBoekenLijst_Click(object sender, RoutedEventArgs e)
        {
            if (_boekenLijstWindow == null || !_boekenLijstWindow.IsVisible)
            {
                _boekenLijstWindow = new Window
                {
                    Title = "Boeken Lijst",
                    Content = new BoekenLijstControl(),
                    Width = 1050,
                    Height = 600
                };
                _boekenLijstWindow.Closed += (s, args) => _boekenLijstWindow = null;
                _boekenLijstWindow.Show();
            }
            else
            {
                _boekenLijstWindow.Focus();
            }
        }

        private void OpenAuteursLijst_Click(object sender, RoutedEventArgs e)
        {
            if (_auteursLijstWindow == null || !_auteursLijstWindow.IsVisible)
            {
                _auteursLijstWindow = new Window
                {
                    Title = "Auteurs Lijst",
                    Content = new AuteursLijstControl(),
                    Width = 650,
                    Height = 600
                };
                _auteursLijstWindow.Closed += (s, args) => _auteursLijstWindow = null;
                _auteursLijstWindow.Show();
            }
            else
            {
                _auteursLijstWindow.Focus();
            }
        }

        private void OpenLedenLijst_Click(object sender, RoutedEventArgs e)
        {
            if (_ledenLijstWindow == null || !_ledenLijstWindow.IsVisible)
            {
                _ledenLijstWindow = new Window
                {
                    Title = "Leden Lijst",
                    Content = new LedenLijstControl(),
                    Width = 860,
                    Height = 600
                };
                _ledenLijstWindow.Closed += (s, args) => _ledenLijstWindow = null;
                _ledenLijstWindow.Show();
            }
            else
            {
                _ledenLijstWindow.Focus();
            }
        }

        private void BekijkAlleGeleendeBoeken_Click(object sender, RoutedEventArgs e)
        {
            if (_alleGeleendeBoekenWindow == null || !_alleGeleendeBoekenWindow.IsVisible)
            {
                _alleGeleendeBoekenWindow = new Window
                {
                    Title = "Alle Geleende Boeken",
                    Content = new AllGeleendeBoekenControl(),
                    Width = 730,
                    Height = 600
                };
                _alleGeleendeBoekenWindow.Closed += (s, args) => _alleGeleendeBoekenWindow = null;
                _alleGeleendeBoekenWindow.Show();
            }
            else
            {
                _alleGeleendeBoekenWindow.Focus();
            }
        }
    }
}


