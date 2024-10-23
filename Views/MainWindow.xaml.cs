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

        private void LijstBoeken_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BoekenLijstControl());
            ButtonPanel.Visibility = Visibility.Collapsed;
        }

        private void LijstLeden_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LedenLijstControl());
            ButtonPanel.Visibility = Visibility.Collapsed;
        }

        private void LijstAuteurs_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuteursLijstControl());
            ButtonPanel.Visibility = Visibility.Collapsed;
        }
    }
}
