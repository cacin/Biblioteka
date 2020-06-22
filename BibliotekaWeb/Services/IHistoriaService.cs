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
        Task<ICollection<HistoriaViewModel>> GetHistoriaListAsync(int id);
        Task PostHistoriaAsync(int id, System.DateTimeOffset dataOd, string osoba);
        Task PutHistoriaAsync(int id, System.DateTimeOffset dataDo);
        Task<HistoriaViewModel> GetHistoriaAsync(int id);
        Task<ReturnViewModel> GetReturnAsync(int id);

    }
}