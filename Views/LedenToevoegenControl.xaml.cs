using BibliotheekApp.Controllers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class LedenToevoegenControl : UserControl
    {
        public LedenToevoegenControl()
        {
            InitializeComponent();
        }

        private void VoegLidToe_Click(object sender, RoutedEventArgs e)
        {
            string naam = NaamTextBox.Text;
            DateTime? geboorteDatum = GeboorteDatumPicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(naam) || geboorteDatum == null)
            {
                MessageBox.Show("Vul alle velden in!", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var lidController = new LidController();
            lidController.VoegLidToe(naam, geboorteDatum.Value);

            // Velden leegmaken na succesvol toevoegen
            NaamTextBox.Text = "";
            GeboorteDatumPicker.SelectedDate = null;
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = null;
            mainWindow.ButtonPanel.Visibility = Visibility.Visible;
        }
    }
}

