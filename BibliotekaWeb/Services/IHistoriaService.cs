using BibliotekaWeb.HttpClients;
using BibliotekaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Services
{
    public interface IHistoriaService
    {
<<<<<<< HEAD
        //Task<HistoriaViewModel> GetHistoriaAsync(int id);
        //Task<HistoriaViewModel> PostHistoriaAsync(?);
        //Task<HistoriaViewModel> PutHistoriaAsync(?);
=======
        Task GetHistoriaAsync(int id);
        Task PostHistoriaAsync(int id, System.DateTimeOffset dataOd, string osoba);
        Task PutHistoriaAsync(int id, System.DateTimeOffset dataDo);
>>>>>>> 0566e35ac808743540a783e7ed51cce190a0db26
    }
}
