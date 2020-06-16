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

namespace BibliotekaWeb.Controllers
{
    public class PozycjeController : Controller
    {
        //private readonly BazaContextTemporary _context;
        private readonly IPozycjeService _pozycjeService;
        private readonly UserManager<AppUser> _userManager;

        public PozycjeController( 
            IPozycjeService pozycjeService,
            UserManager<AppUser> userManager)
        {
            //_context = context;
            _pozycjeService = pozycjeService;
            _userManager = userManager;
        }

        // GET: Pozycje
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Pozycje.ToListAsync());
            var uzytkownik = await _userManager.GetUserAsync(User);
            if (uzytkownik == null)
            {
                return Challenge();
            }


            PozycjaViewModel[] pozycjaViewModel = await _pozycjeService.GetPozycjaDetailsAsync(uzytkownik.Id);
            /*if (pozycjaViewModel == null || pozycjaViewModel.Count() == 0)
            {
                return NotFound();
            }*/

            return View(pozycjaViewModel);
        }

        // GET: Pozycje/Details/5
        public async Task<IActionResult> Details(int id)
        {
            PozycjaViewModel pozycjaViewModel = await _pozycjeService.GetPozycjaDetailsAsync(id);

            /*var pozycja = await _context.Pozycje
                .FirstOrDefaultAsync(m => m.PozycjaId == id);
            */
            if (pozycjaViewModel == null)
            {
                return NotFound();
            }

            return View(pozycjaViewModel);
        }

        // GET: Pozycje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pozycje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PozycjaId,Tytul,Autor,Rok,Rodzaj,Foto,Status")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(pozycja);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozycja);
        }

        // GET: Pozycje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var pozycja = await _context.Pozycje.FindAsync(id);
            if (pozycja == null)
            {
                return NotFound();
            }
            return View(pozycja);*/
            return View(null);
        }

        // POST: Pozycje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PozycjaId,Tytul,Autor,Rok,Rodzaj,Foto,Status")] Pozycja pozycja)
        {
            if (id != pozycja.PozycjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(pozycja);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozycjaExists(pozycja.PozycjaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pozycja);
        }

        // GET: Pozycje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var pozycja = await _context.Pozycje.FirstOrDefaultAsync(m => m.PozycjaId == id);
            if (pozycja == null)
            {
                return NotFound();
            }
            return View(pozycja);
            */
            return View(null);

        }

        // POST: Pozycje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var pozycja = await _context.Pozycje.FindAsync(id);
            _context.Pozycje.Remove(pozycja);
            await _context.SaveChangesAsync();*/
            return RedirectToAction(nameof(Index));
        }

        private bool PozycjaExists(int id)
        {
            //return _context.Pozycje.Any(e => e.PozycjaId == id);
            return true;
        }
    }
}
