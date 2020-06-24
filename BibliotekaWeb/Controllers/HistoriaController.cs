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

        public async Task<IActionResult> Return(int id)
        {
            ReturnViewModel returnViewModel = await _historiaService.GetReturnAsync(id);

            if (returnViewModel == null)
            {
                return NotFound();
            }

            return View(returnViewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent([Bind("Id, DataOd, Osoba, Pozycja")] Historia historia)
        {
        

            if (ModelState.IsValid)
            {
              await _historiaService.PostHistoriaAsync(historia.Pozycja.PozycjaId,  historia.DataOd, historia.Osoba);

                return RedirectToAction(nameof(Index), "Pozycje");
            }
            return View(historia);
        }

  
        // POST: Pozycje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id, [Bind("Id, DataDo, Pozycja")] ReturnViewModel historia)

        { 
            await _historiaService.PutHistoriaAsync(historia.Pozycja.PozycjaId, historia.DataDo);
            return RedirectToAction(nameof(Index), "Pozycje");
        }

    }
}
