﻿using System;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent([Bind("PozycjaId,Tytul,Autor,Rok,Rodzaj,Foto,Status")] Historia historia)
        {
            var uzytkownik = await _userManager.GetUserAsync(User);
            if (uzytkownik == null)
            {
                return Challenge();
            }

            if (ModelState.IsValid)
            {
                pozycja.Uzytkownik = uzytkownik.Id;
                var blobUrl = await _azureService.AddBlobItem(pozycja.Foto);
                pozycja.Foto = blobUrl;
                PozycjaViewModel pozycjaViewModel = await _pozycjeService.PostPozycjaAsync(pozycja);

                return RedirectToAction(nameof(Index));
            }
            return View(pozycja);
        }

        // GET: Pozycje/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            PozycjaViewModel pozycjaViewModel = await _pozycjeService.GetPozycjaAsync(id);

            if (pozycjaViewModel == null)
            {
                return NotFound();
            }

            return View(pozycjaViewModel);
        }

        // POST: Pozycje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PozycjaId,Tytul,Autor,Rok,Rodzaj,Foto,Status,Uzytkownik")] PozycjaViewModel pozycja)
        {
            var blobUrl = await _azureService.AddBlobItem(pozycja.Foto);
            await _pozycjeService.PutPozycjaAsync(id, pozycja);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pozycje/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            PozycjaViewModel pozycjaViewModel = await _pozycjeService.GetPozycjaAsync(id);

            if (pozycjaViewModel == null)
            {
                return NotFound();
            }

            return View(pozycjaViewModel);
        }

        // POST: Pozycje/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PozycjaViewModel pozycjaViewModel = await _pozycjeService.DeletePozycjaAsync(id);

            //_context.Remove(pozycjaViewModel);
            //await _context.SaveChangesAsync();
            /*     var pozycja = await _context.Pozycje.FindAsync(id);

            _context.Pozycje.Remove(pozycja);
            await _context.SaveChangesAsync();

            return Ok(pozycja);*/
            return RedirectToAction(nameof(Index));

        }

    }
}