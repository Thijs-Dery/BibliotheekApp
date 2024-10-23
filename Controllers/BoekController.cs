using BibliotheekApp.Views;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotheekApp.Controllers
{
    public class BoekController
    {
        public UserControl GetBoekenToevoegenView()
        {
            return new BoekenToevoegenControl();
        }

    }
}
