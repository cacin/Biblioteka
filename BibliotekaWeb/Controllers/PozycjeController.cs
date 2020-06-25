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
using System.IO;

namespace BibliotekaWeb.Controllers
{
    public class PozycjeController : Controller
    {
        //private readonly BazaContext _context;
        private readonly IPozycjeService _pozycjeService;
        private readonly IAzureService _azureService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHistoriaService _historiaService;



        public PozycjeController( 
            IPozycjeService pozycjeService,
            IAzureService azureService,
            UserManager<AppUser> userManager,
            IHistoriaService historiaService
            )

        {
            //_context = context;
            _pozycjeService = pozycjeService;
            _azureService = azureService;
            _userManager = userManager;
            _historiaService = historiaService;
        }

        // GET: Pozycje
        public async Task<IActionResult> Index(string searchString)
        {
            //return View(await _context.Pozycje.ToListAsync());
            var uzytkownik = await _userManager.GetUserAsync(User);
            
            
            if (uzytkownik == null)
            {
                return Challenge();
            }


            PozycjaViewModel[] pozycjaViewModel = await _pozycjeService.GetPozycjaAsync(uzytkownik.Id, searchString);
            /*if (pozycjaViewModel == null || pozycjaViewModel.Count() == 0)
            {
                return NotFound();
            }*/

            return View(pozycjaViewModel);
        }

        // GET: Pozycje/Details/5
        public async Task<IActionResult> Details(int id)
        {
            PozycjaViewModel pozycjaViewModel = await _pozycjeService.GetPozycjaAsync(id);
            ICollection<HistoriaViewModel> historiaViewModels = await _historiaService.GetHistoriaListAsync(id);


            PozycjaHistoriaViewModel pozycjaHistoriaViewModel = new PozycjaHistoriaViewModel();

            pozycjaHistoriaViewModel.PozycjaViewModel = pozycjaViewModel;
            pozycjaHistoriaViewModel.HistoriaViewModels = historiaViewModels;

            /*var pozycja = await _context.Pozycje
                .FirstOrDefaultAsync(m => m.PozycjaId == id);
            */
            if (pozycjaViewModel == null)
            {
                return NotFound();
            }

            return View(pozycjaHistoriaViewModel);
        }

        // GET: Pozycje/Create;
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
            var uzytkownik = await _userManager.GetUserAsync(User);
            if (uzytkownik == null)
            {
                return Challenge();
            }

            if (ModelState.IsValid)
            {

                if (pozycja.Foto != null) // jak jest blob do przetworzenia
                {
                    var blob = pozycja.Foto;
                    var blobUrl = await _azureService.AddBlobItem(blob);
                    pozycja.Foto = blobUrl;
                }

                pozycja.Uzytkownik = uzytkownik.Id;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PozycjaId,Tytul,Autor,Rok,Rodzaj,Foto,Status,Uzytkownik")] PozycjaViewModel pozycja)
        {


            //var blobUrl = await _azureService.AddBlobItem(StreamExtensions.ConvertToBase64FromPath("c:/temp/"+pozycja.Foto));
            

            if (pozycja.Foto != null) // jak jest blob do przetworzenia
            {
                var blob = pozycja.Foto;
                var blobUrl = await _azureService.AddBlobItem(blob);
                pozycja.Foto = blobUrl;
            }

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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PozycjaViewModel pozycjaViewModel = await _pozycjeService.DeletePozycjaAsync(id);

            return RedirectToAction(nameof(Index));
            
        }

    }
}
