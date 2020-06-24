using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Models
{
    public class PozycjaHistoriaViewModel
    {
     public   PozycjaViewModel PozycjaViewModel { get; set; }
     public   ICollection<HistoriaViewModel> HistoriaViewModels {get; set;}
    }
}
