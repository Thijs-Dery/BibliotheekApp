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
    public int AuteurID { get; set; } // AuteurID is verplicht omdat het in de database "not null" is
    public Auteur Auteur { get; set; }

    public List<LidBoek> LidBoeken { get; set; } = new List<LidBoek>();

    // Andere velden zoals IsDeleted, als je die wilt opnemen in je klasse:
    public bool IsDeleted { get; set; }
}

