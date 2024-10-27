using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotheekApp.Models
{
    public class Lid
    {
        [Key]
        public int? LidID { get; set; }
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public List<LidBoek> GeleendeBoeken { get; set; } = new List<LidBoek>();  // Navigatie-eigenschap voor de relatie
    }
}


