using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotheekApp
{
    public class Auteur
    {
        public int AuteurID { get; set; }
        public string Naam {  get; set; }
        public DateTime GeboorteDatum { get; set; }
        public List<Boek> Boeken { get; set; }
    }
}
