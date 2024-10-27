using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliotheekApp.Views
{
    /// <summary>
    /// Interaction logic for LedenToevoegenControl.xaml
    /// </summary>
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

            // Voeg lid toe aan database

            MessageBox.Show("Lid succesvol toegevoegd!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
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
