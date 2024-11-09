using BibliotheekApp.Models;
using System.Windows;

namespace BibliotheekApp.Views
{
    public partial class GeleendeBoekenWindow : Window
    {
        public GeleendeBoekenWindow(Lid lid)
        {
            InitializeComponent();
            GeleendeBoekenDataGrid.ItemsSource = lid.GeleendeBoeken;
        }
    }
}

