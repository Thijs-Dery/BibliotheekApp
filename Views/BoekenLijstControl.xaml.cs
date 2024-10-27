using BibliotheekApp.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class BoekenLijstControl : UserControl
    {
        private BoekController _boekController;

        public BoekenLijstControl()
        {
            InitializeComponent();
            _boekController = new BoekController();
            BoekenDataGrid.ItemsSource = _boekController.GetAlleBoeken();
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }
    }
}

