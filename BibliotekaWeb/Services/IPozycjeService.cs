using BibliotekaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public interface IPozycjeService
    {
        Task<PozycjaViewModel> GetPozycjaDetailsAsync(int id);

        //Task<Guid> AddItemAsync(TodoItemViewModel newItem, AppUser user);

        //Task<bool> MarkDoneAsync(TodoItemViewModel item, AppUser user);
    }
}
