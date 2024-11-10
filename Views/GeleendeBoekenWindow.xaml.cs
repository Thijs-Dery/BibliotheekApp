using BibliotheekApp.Controllers;
using BibliotheekApp.Models;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace BibliotheekApp.Views
{
    public partial class GeleendeBoekenWindow : Window
    {
        private readonly LidController _lidController;
        private readonly BoekController _boekController; // Toegevoegd voor het ophalen van boeken

        public GeleendeBoekenWindow(Lid lid)
        {
            InitializeComponent();
            _lidController = new LidController();
            _boekController = new BoekController(); // Initialiseer de BoekController
            GeleendeBoekenDataGrid.ItemsSource = lid.GeleendeBoeken;
            this.DataContext = lid;
        }

        private void BoekToevoegen_Click(object sender, RoutedEventArgs e)
        {
            var lid = (Lid)this.DataContext;
            if (lid != null)
            {
                // Haal beschikbare boeken op die niet uitgeleend zijn
                var beschikbareBoeken = _boekController.GetAlleBoeken()
                                                        .Where(b => b.LidID == null)
                                                        .ToList();

                if (!beschikbareBoeken.Any())
                {
                    MessageBox.Show("Er zijn geen beschikbare boeken om toe te voegen.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Toon een selectiepop-up voor de beschikbare boeken
                var selecteerBoekWindow = new Window
                {
                    Title = "Selecteer een Boek om Toe te Voegen",
                    Width = 400,
                    Height = 200,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };

                var comboBox = new ComboBox
                {
                    ItemsSource = beschikbareBoeken,
                    DisplayMemberPath = "Titel",
                    SelectedValuePath = "ISBN",
                    Width = 350,
                    Margin = new Thickness(10)
                };

                var bevestigButton = new Button
                {
                    Content = "Bevestigen",
                    Width = 100,
                    Margin = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                bevestigButton.Click += (s, ev) =>
                {
                    if (comboBox.SelectedValue != null)
                    {
                        string isbn = comboBox.SelectedValue.ToString();
                        bool result = _lidController.VoegBoekToeAanLid(lid.LidID, isbn);
                        if (result)
                        {
                            MessageBox.Show("Boek succesvol toegevoegd aan het lid!");
                            VerversGegevens(lid); // Ververs de gegevens na het toevoegen van een boek
                        }
                        else
                        {
                            MessageBox.Show("Er is een fout opgetreden. Controleer of het boek bestaat en nog niet is uitgeleend.");
                        }
                        selecteerBoekWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Selecteer een boek uit de lijst.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                };

                var stackPanel = new StackPanel();
                stackPanel.Children.Add(comboBox);
                stackPanel.Children.Add(bevestigButton);

                selecteerBoekWindow.Content = stackPanel;
                selecteerBoekWindow.ShowDialog();
            }
        }

        private void BoekVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            var lid = (Lid)this.DataContext;
            if (lid != null)
            {
                // Haal de boeken op die specifiek aan dit lid zijn uitgeleend
                var geleendeBoeken = lid.GeleendeBoeken.Select(lb => lb.Boek).ToList();

                if (!geleendeBoeken.Any())
                {
                    MessageBox.Show("Dit lid heeft geen geleende boeken om te verwijderen.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Toon een selectiepop-up voor de geleende boeken van dit lid
                var selecteerBoekWindow = new Window
                {
                    Title = "Selecteer een Boek om te Verwijderen",
                    Width = 400,
                    Height = 200,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };

                var comboBox = new ComboBox
                {
                    ItemsSource = geleendeBoeken,
                    DisplayMemberPath = "Titel",
                    SelectedValuePath = "ISBN",
                    Width = 350,
                    Margin = new Thickness(10)
                };

                var bevestigButton = new Button
                {
                    Content = "Bevestigen",
                    Width = 100,
                    Margin = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                bevestigButton.Click += (s, ev) =>
                {
                    if (comboBox.SelectedValue != null)
                    {
                        string isbn = comboBox.SelectedValue.ToString();
                        bool result = _lidController.VerwijderBoekVanLid(lid.LidID, isbn);
                        if (result)
                        {
                            MessageBox.Show("Boek succesvol verwijderd van het lid!");
                            VerversGegevens(lid); // Ververs de gegevens na het verwijderen van een boek
                        }
                        else
                        {
                            MessageBox.Show("Er is een fout opgetreden. Controleer of het boek aan dit lid is uitgeleend.");
                        }
                        selecteerBoekWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Selecteer een boek uit de lijst.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                };

                var stackPanel = new StackPanel();
                stackPanel.Children.Add(comboBox);
                stackPanel.Children.Add(bevestigButton);

                selecteerBoekWindow.Content = stackPanel;
                selecteerBoekWindow.ShowDialog();
            }
        }

        private void VerversGegevens(Lid lid)
        {
            // Haal het bijgewerkte lid op uit de database
            var bijgewerktLid = _lidController.GetAlleLeden()
                                              .FirstOrDefault(l => l.LidID == lid.LidID);

            if (bijgewerktLid != null)
            {
                // Update de DataContext en de ItemsSource van het DataGrid
                this.DataContext = bijgewerktLid;
                GeleendeBoekenDataGrid.ItemsSource = bijgewerktLid.GeleendeBoeken;
            }
        }

    }
}

