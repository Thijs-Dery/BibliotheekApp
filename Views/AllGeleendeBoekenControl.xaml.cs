using BibliotheekApp.Models;
using BibliotheekApp.Controllers;
using System.Windows.Controls;

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
    }
}


