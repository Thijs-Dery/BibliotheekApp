using BibliotheekApp.Models;
using BibliotheekApp.Controllers;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace BibliotheekApp.Views
{
    public partial class AllGeleendeBoekenControl : UserControl
    {
        private readonly BoekController _boekController;

        public AllGeleendeBoekenControl()
        {
            InitializeComponent();
            _boekController = new BoekController();
            LaadGeleendeBoeken();
        }

        private void LaadGeleendeBoeken()
        {
            var geleendeBoeken = _boekController.GetAlleBoeken();
            GeleendeBoekenDataGrid.ItemsSource = geleendeBoeken;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LaadGeleendeBoeken();
        }

        private void ZoekTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            var zoekTerm = ZoekTextBox.Text.ToLower();
            var alleBoeken = _boekController.GetAlleBoeken();

            var gefilterdeBoeken = alleBoeken
                .Where(b => b.Titel.ToLower().Contains(zoekTerm) ||
                            b.ISBN.ToLower().Contains(zoekTerm) ||
                            (b.LenerNaam != null && b.LenerNaam.ToLower().Contains(zoekTerm)))
                .ToList();

            GeleendeBoekenDataGrid.ItemsSource = gefilterdeBoeken;
        }
    }
}


