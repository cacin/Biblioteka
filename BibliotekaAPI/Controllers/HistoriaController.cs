using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotekaDb;
using BibliotekaDb.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAPI.Controllers
{
    public class HistoriaController : Controller
    {

        private readonly BazaContext _context;

        public HistoriaController(BazaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Pobranie informacji o historii pozycji w bibliotece
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Historia>>> GetHistoriaPozycja(int id)
        {
            var pozycja = await _context.Pozycje.FindAsync(id);

            if (pozycja == null)
            {
                return NotFound();
            }

            return await _context.Historia.Where(x => x.Pozycja == pozycja).ToListAsync();
        }



        /// <summary>
        /// Wypozyczenie pozycji z biblioteki
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataOd"></param>
        /// /// <param name="osoba"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("{id}, {dataOd}, {osoba}")]
        public async Task<IActionResult> PostPozycjaWypozycz(int id, DateTimeOffset dataOd, string osoba)
        {
            var pozycja = await _context.Pozycje.FindAsync(id);
            if (pozycja == null || pozycja.Status == true) //nie można wypozyczyc pozycji już wypozyczonej
            {
                return NotFound();
            }

            pozycja.Status = true;
            Historia historia = new Historia { Pozycja = pozycja, DataOd = dataOd, Osoba = osoba };
            _context.Historia.Add(historia);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozycjaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// Zwrocenie pozycji do biblioteki
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataDo"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}, {dataDo}")]
        public async Task<IActionResult> PutPozycjaZwroc(int id, DateTime dataDo)
        {
            var pozycja = await _context.Pozycje.FindAsync(id);
            if (pozycja == null || pozycja.Status == false) //nie można zwrocic pozycji nie wypozyczonej
            {
                return NotFound();
            }

            var historia = await _context.Historia.Where(x => x.Pozycja == pozycja && x.DataDo == null).FirstOrDefaultAsync();

            if (historia != null)
            {
                historia.DataDo = dataDo; //jak z jakiegos powodu nie będzie rekordu w historii do zwrocenia, to po prostu go nie updatujemy, ale pozycję można zwrócić
            }

            pozycja.Status = false;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozycjaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool PozycjaExists(int id)
        {
            return _context.Pozycje.Any(e => e.PozycjaId == id);
        }
    }
}
