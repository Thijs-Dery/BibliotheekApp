using BibliotheekApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LidBoek
{
    [Key]
    public int LidBoekID { get; set; }

    [ForeignKey("Lid")]
    public int? LidID { get; set; }
    public Lid Lid { get; set; }

    [ForeignKey("Boek")]
    [Column("ISBN")]
    public string ISBN { get; set; }
    public Boek Boek { get; set; }

    public DateTime UitleenDatum { get; set; }
    public DateTime? InleverDatum { get; set; }
}




