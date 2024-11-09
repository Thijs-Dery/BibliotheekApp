using BibliotheekApp.Models;
using BibliotheekApp.Controllers;
using System.Windows.Controls;

namespace BibliotheekApp.Views
{
    public partial class AllGeleendeBoekenControl : UserControl
    {
        private readonly LidController _lidController;

        public AllGeleendeBoekenControl()
        {
            InitializeComponent();
            _lidController = new LidController();
            GeleendeBoekenDataGrid.ItemsSource = _lidController.GetAllGeleendeBoeken();
        }
    }
}

