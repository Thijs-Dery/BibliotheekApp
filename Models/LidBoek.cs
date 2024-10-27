using System;

namespace BibliotheekApp.Models
{
    public class LidBoek
    {
        public int LidBoekID { get; set; }  // Primaire sleutel voor LidBoek

        public int? LidID { get; set; }
        public Lid Lid { get; set; }

        public string ISBN { get; set; }
        public Boek Boek { get; set; }

        public DateTime UitleenDatum { get; set; }
        public DateTime? InleverDatum { get; set; }  // Nullable voor boeken die nog niet zijn ingeleverd
    }
}

