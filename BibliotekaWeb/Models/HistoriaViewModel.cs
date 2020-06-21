using BibliotekaDb.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Models
{
    public class HistoriaViewModel
    {
        public int HisoriaID { get; set; }
        [Required]
        [Display(Name = "Data wypożyczenia", Description = "Data wypożyczenia")]
        public DateTimeOffset DataOd { get; set; }
        [Display(Name = "Data zwrócenia", Description = "Data zwrócenia")]
        public DateTime? DataDo { get; set; }
        [Required]
        [Display(Name = "Osoba wypożyczająca", Description = "Osoba wypożyczająca")]
        public string Osoba { get; set; }
        public Pozycja Pozycja { get; set; }


    }
}
