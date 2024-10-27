using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BibliotheekApp.Models
{
    public class Boek
    {
        [Key]
        public string ISBN { get; set; }
        public string Titel { get; set; }
        public string Genre { get; set; }
        public DateTime PublicatieDatum { get; set; }
        public int AuteurID { get; set; }
        public Auteur Auteur { get; set; }
    }
}
