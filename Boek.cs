using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotheekApp
{
    public class Boek
    {
        public int ISBN { get; set; }
        public string Titel { get; set; }
        public string Genre { get; set; }
        public DateTime PublicatieDatum { get; set; }
        public int AuteurID { get; set; }
        Auteur Auteur { get; set; }


    }
}
