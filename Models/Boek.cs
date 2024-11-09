using BibliotheekApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Boek
{
    [Key]
    [Required]
    public string ISBN { get; set; }

    [Required]
    public string Titel { get; set; }

    public string Genre { get; set; }
    public DateTime PublicatieDatum { get; set; }

    [ForeignKey("Auteur")]
    public int? AuteurID { get; set; }
    public Auteur Auteur { get; set; }

    [ForeignKey("Lid")]
    public int? LidID { get; set; }
    public Lid Lid { get; set; }

    public List<LidBoek> LidBoeken { get; set; } = new List<LidBoek>();
}

