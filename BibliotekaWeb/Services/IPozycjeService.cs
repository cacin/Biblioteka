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
        Task<PozycjaViewModel[]> GetPozycjaDetailsAsync(string uzytkownik);
        Task<PozycjaViewModel> GetPozycjaDetailsAsync(int id);
        Task<PozycjaViewModel> PutPozycjaDetailsAsync(int id);

        Task<PozycjaViewModel> PostPozycjaAsync(Pozycja body);

        //Task<Guid> AddItemAsync(TodoItemViewModel newItem, AppUser user);

        //Task<bool> MarkDoneAsync(TodoItemViewModel item, AppUser user);
    }
}
