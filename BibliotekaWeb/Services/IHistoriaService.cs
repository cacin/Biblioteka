using BibliotekaWeb.HttpClients;
using BibliotekaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Services
{
    public class IHistoriaService
    {
        Task GetHistoriaAsync(int id);
        Task PostHistoriaAsync(int id, System.DateTimeOffset dataOd, string osoba);
        Task PutHistoriaAsync(int id, System.DateTimeOffset dataDo);
    }
}
