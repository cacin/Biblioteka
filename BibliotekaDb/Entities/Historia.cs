using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;


namespace BibliotekaDb.Entities
{
    public class Historia
    {

        [Key]
        public int HisoriaID { get; set; }
        public DateTimeOffset DataOd { get; set; }
        public DateTime? DataDo { get; set; }
        public string Osoba { get; set; }
        //public string Uzytkownik { get; set; }
        //public int PozycjaId { get; set; }
        public Pozycja Pozycja { get; set; }
    }
}

