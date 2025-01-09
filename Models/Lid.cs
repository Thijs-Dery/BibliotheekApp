using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotheekApp.Models
{
    public class Lid
    {
        [Key]
        public int LidID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Naam { get; set; }

        [Required]
        public DateTime GeboorteDatum { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        public List<LidBoek>? GeleendeBoeken { get; set; } = new List<LidBoek>();
    }
}
