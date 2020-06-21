using BibliotekaDb.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Models
{
    public class ReturnViewModel
    {
        public int HisoriaID { get; set; }
        [Required]
        public DateTime DataDo { get; set; }
        [Required]
        public Pozycja Pozycja { get; set; }
    }
}
