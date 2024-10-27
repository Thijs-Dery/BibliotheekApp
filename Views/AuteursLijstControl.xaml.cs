using BibliotheekApp.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class AuteursLijstControl : UserControl
    {
        private readonly AuteurController _auteurController;

        public AuteursLijstControl()
        {
            InitializeComponent();
            _auteurController = new AuteurController();
            AuteursDataGrid.ItemsSource = _auteurController.GetAlleAuteurs();
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }
    }
}

