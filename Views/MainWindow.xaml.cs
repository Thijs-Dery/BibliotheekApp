using System.Windows;
using System.Windows.Controls;
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
            MainFrame.Navigate(new BoekenToevoegenControl());
            ButtonPanel.Visibility = Visibility.Collapsed;
        }

        private void AuteursToevoegen_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuteursToevoegenControl());
            ButtonPanel.Visibility = Visibility.Collapsed;
        }

        private void LedenToevoegen_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LedenToevoegenControl());
            ButtonPanel.Visibility = Visibility.Collapsed;
        }

        private void OpenBoekenLijst_Click(object sender, RoutedEventArgs e)
        {
            Window boekenLijstWindow = new Window
            {
                Title = "Boeken Lijst",
                Content = new BoekenLijstControl(),
            };
            boekenLijstWindow.Show();
        }

        private void OpenAuteursLijst_Click(object sender, RoutedEventArgs e)
        {
            Window auteursLijstWindow = new Window
            {
                Title = "Auteurs Lijst",
                Content = new AuteursLijstControl(),
            };
            auteursLijstWindow.Show();
        }

        private void OpenLedenLijst_Click(object sender, RoutedEventArgs e)
        {
            Window ledenLijstWindow = new Window
            {
                Title = "Leden Lijst",
                Content = new LedenLijstControl(),
            };
            ledenLijstWindow.Show();
        }

    }
}
