using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;


namespace BibliotekaDb.Entities
{

    public class Pozycja
    {
        public int PozycjaId { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Tytul { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Autor { get; set; }
        public int Rok { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public RodzajEnum Rodzaj { get; set; }
        public string Foto { get; set; }
        public bool Status { get; set; }
        //public string Uzytkownik { get; set; }
    }

}

