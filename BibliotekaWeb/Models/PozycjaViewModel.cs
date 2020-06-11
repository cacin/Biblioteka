using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;


namespace BibliotekaWeb.Models
{

    public class PozycjaViewModel
    {
        public int PozycjaId { get; set; }
        [Required]
        public string Tytul { get; set; }
        [Required]
        public string Autor { get; set; }
        public int Rok { get; set; }
        [Required]
        public RodzajEnum Rodzaj { get; set; }
        public string Foto { get; set; }
        public bool Status { get; set; }
        //public string Uzytkownik { get; set; }
    }

    public enum RodzajEnum
    {
        Książka,
        DVD,
        CD,
        Vinyl
    }

}

