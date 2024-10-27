using BibliotheekApp.Controllers;
using System;
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

        private void UpdateLid_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            var lid = _lidController.GetAlleLeden().Find(l => l.LidID == lidId);
            if (lid != null)
            {
                string nieuweNaam = Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe naam:", "Update Lid", lid.Naam);
                DateTime nieuweGeboorteDatum = DateTime.Parse(Microsoft.VisualBasic.Interaction.InputBox("Geef de nieuwe geboortedatum:", "Update Lid", lid.GeboorteDatum.ToString("dd-MM-yyyy")));

                _lidController.UpdateLid(lidId, nieuweNaam, nieuweGeboorteDatum);
                LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
            }
        }

        private void DeleteLid_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int lidId = (int)button.Tag;

            var result = MessageBox.Show("Weet je zeker dat je dit lid wilt verwijderen?", "Bevestig Verwijdering", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _lidController.DeleteLid(lidId);
                LedenDataGrid.ItemsSource = _lidController.GetAlleLeden(); // Refresh lijst
            }
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }

        private void LedenDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}



