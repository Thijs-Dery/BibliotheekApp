using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotheekApp.Models
{
    public class Auteur
    {
        [Key]
        public int AuteurID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Naam { get; set; }

        [Required]
        public DateTime GeboorteDatum { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public List<Boek> Boeken { get; set; } = new List<Boek>();
    }
}
