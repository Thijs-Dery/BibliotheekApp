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

        private void BekijkBoeken_Click(object sender, RoutedEventArgs e)
        {
            var boekenLijstWindow = new Window
            {
                Title = "Boeken Lijst",
                Content = new BoekenLijstControl(),
                Width = 800,
                Height = 600
            };
            boekenLijstWindow.Show();
        }

        private void VoegBoekToe_Click(object sender, RoutedEventArgs e)
        {
            var boekenToevoegenWindow = new Window
            {
                Title = "Boek Toevoegen",
                Content = new BoekenToevoegenControl(),
                Width = 450,
                Height = 400
            };
            boekenToevoegenWindow.Show();
        }

        private void VerwijderBoek_Click(object sender, RoutedEventArgs e)
        {
            var verwijderBoekenWindow = new Window
            {
                Title = "Verwijder Boeken",
                Content = new BoekenLijstControl(), // Pas dit aan als je een specifieke verwijderinterface hebt
                Width = 800,
                Height = 600
            };
            verwijderBoekenWindow.Show();
        }

        private void BekijkLeden_Click(object sender, RoutedEventArgs e)
        {
            var ledenLijstWindow = new Window
            {
                Title = "Leden Lijst",
                Content = new LedenLijstControl(),
                Width = 800,
                Height = 600
            };
            ledenLijstWindow.Show();
        }

        private void VoegLidToe_Click(object sender, RoutedEventArgs e)
        {
            var ledenToevoegenWindow = new Window
            {
                Title = "Lid Toevoegen",
                Content = new LedenToevoegenControl(),
                Width = 450,
                Height = 400
            };
            ledenToevoegenWindow.Show();
        }

        private void VerwijderLid_Click(object sender, RoutedEventArgs e)
        {
            var verwijderLedenWindow = new Window
            {
                Title = "Verwijder Leden",
                Content = new LedenLijstControl(),
                Width = 800,
                Height = 600
            };
            verwijderLedenWindow.Show();
        }

        private void BekijkAuteurs_Click(object sender, RoutedEventArgs e)
        {
            var auteursLijstWindow = new Window
            {
                Title = "Auteurs Lijst",
                Content = new AuteursLijstControl(),
                Width = 800,
                Height = 600
            };
            auteursLijstWindow.Show();
        }

        private void VoegAuteurToe_Click(object sender, RoutedEventArgs e)
        {
            var auteursToevoegenWindow = new Window
            {
                Title = "Auteur Toevoegen",
                Content = new AuteursToevoegenControl(),
                Width = 450,
                Height = 400
            };
            auteursToevoegenWindow.Show();
        }

        private void VerwijderAuteur_Click(object sender, RoutedEventArgs e)
        {
            var verwijderAuteursWindow = new Window
            {
                Title = "Verwijder Auteurs",
                Content = new AuteursLijstControl(), 
                Width = 800,
                Height = 600
            };
            verwijderAuteursWindow.Show();
        }

        private void BekijkGeleendeBoeken_Click(object sender, RoutedEventArgs e)
        {
            var geleendeBoekenWindow = new Window
            {
                Title = "Geleende Boeken",
                Content = new AllGeleendeBoekenControl(),
                Width = 800,
                Height = 600
            };
            geleendeBoekenWindow.Show();
        }

    }
}


