using BibliotheekApp.Controllers;
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
            LedenDataGrid.ItemsSource = _lidController.GetAlleLeden();
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }
    }
}

