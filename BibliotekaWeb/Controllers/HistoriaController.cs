using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotekaWeb;
using BibliotekaWeb.HttpClients;
using BibliotekaWeb.Services;
using BibliotekaWeb.Models;
using Microsoft.AspNetCore.Identity;
using BibliotekaAuthDb.Entities;
using BibliotekaDb;

namespace BibliotekaWeb.Controllers
{
    public class HistoriaController : Controller
    {
      
        private readonly IHistoriaService _historiaService;
   


        public HistoriaController(
            IHistoriaService historiaService)
    
        {
           
            _historiaService = historiaService;
    
        }

        // GET: Pozycje
        /*      public async Task<IActionResult> Index()
              {
                  //return View(await _context.Pozycje.ToListAsync());
                  var uzytkownik = await _userManager.GetUserAsync(User);
                  if (uzytkownik == null)
                  {
                      return Challenge();
                  }


                  PozycjaViewModel[] pozycjaViewModel = await _pozycjeService.GetPozycjaAsync(uzytkownik.Id);
                  /*if (pozycjaViewModel == null || pozycjaViewModel.Count() == 0)
                  {
                      return NotFound();
                  }

                  return View(pozycjaViewModel);
              }

              // GET: Pozycje/Details/5
              public async Task<IActionResult> Details(int id)
              {
                  PozycjaViewModel pozycjaViewModel = await _pozycjeService.GetPozycjaAsync(id);

                  /*var pozycja = await _context.Pozycje
                      .FirstOrDefaultAsync(m => m.PozycjaId == id);

                  if (pozycjaViewModel == null)
                  {
                      return NotFound();
                  }

                  return View(pozycjaViewModel);
              }

              // GET: Pozycje/Create;
              public IActionResult Create()
              {
                  return View();
              }

              // POST: Pozycje/Create
              // To protect from overposting attacks, enable the specific properties you want to bind to, for 
              // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

          */
        // GET: Pozycje/Edit/5
        public async Task<IActionResult> Rent(int id)
        {
            HistoriaViewModel historiaViewModel = await _historiaService.GetHistoriaAsync(id);

            if (historiaViewModel == null)
            {
                return NotFound();
            }

            return View(historiaViewModel);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent([Bind("Id, DataOd, Osoba, Pozycja")] Historia historia)
        {
        

            if (ModelState.IsValid)
            {
              await _historiaService.PostHistoriaAsync(historia.Pozycja.PozycjaId,  historia.DataOd, historia.Osoba);

                return RedirectToAction(nameof(Index));
            }
            return View(historia);
        }

  
        // POST: Pozycje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id, [Bind("Id, DataDo, Pozycja")] ReturnViewModel historia)

        { 
            await _historiaService.PutHistoriaAsync(historia.Pozycja.PozycjaId, historia.DataDo);
            return RedirectToAction(nameof(Index));
        }

    }
}
