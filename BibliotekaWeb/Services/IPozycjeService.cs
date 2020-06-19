using BibliotekaWeb.HttpClients;
using BibliotekaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekaWeb.Services
{
    public interface IPozycjeService
    {
        Task<PozycjaViewModel[]> GetPozycjaAsync(string uzytkownik);
        Task<PozycjaViewModel> GetPozycjaAsync(int id);
        Task PutPozycjaAsync(int id, PozycjaViewModel body);
        Task<PozycjaViewModel> DeletePozycjaAsync(int id);
        Task<PozycjaViewModel> PostPozycjaAsync(Pozycja body);
    }
}
