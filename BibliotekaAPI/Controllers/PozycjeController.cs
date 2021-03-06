﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotekaDb;
using BibliotekaDb.Entities;

namespace BibliotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozycjeController : ControllerBase
    {
        private readonly BazaContext _context;

        public PozycjeController(BazaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista pozycji w bibliotece dla wskazanego uzytkownika
        /// </summary>
        /// /// <param name="uzytkownik"></param>
        /// /// <param name="SearchString"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pozycja>>> GetPozycje(string uzytkownik, string SearchString)
        {
            if (SearchString == null) {
                return await _context.Pozycje.Where(x => x.Uzytkownik == uzytkownik).ToListAsync();
            }
            else
            {
                return await _context.Pozycje.Where(x => x.Uzytkownik == uzytkownik && x.Tytul.Contains(SearchString)).ToListAsync();
            }
        }

        /// <summary>
        /// Pobranie informacji o pozycji w bibliotece
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pozycja>> GetPozycja(int id)
        {
            var pozycja = await _context.Pozycje.FindAsync(id);

            if (pozycja == null)
            {
                return NotFound();
            }

            return Ok(pozycja);
        }

        /// <summary>
        /// Modyfikacja pozycji w bibliotece
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pozycja"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozycja(int id, Pozycja pozycja)
        {
            if (id != pozycja.PozycjaId)
            {
                return BadRequest();
            }

            _context.Entry(pozycja).State = EntityState.Modified;

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
        /// Dodanie pozycji w bibliotece
        /// </summary>
        /// <param name="pozycja"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Pozycja>> PostPozycja(Pozycja pozycja)
        {
            _context.Pozycje.Add(pozycja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPozycja", new { id = pozycja.PozycjaId }, pozycja);
        }

        /// <summary>
        /// Usunięcie pozycji z biblioteki
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pozycja>> DeletePozycja(int id)
        {
            var pozycja = await _context.Pozycje.FindAsync(id);
            if (pozycja == null)
            {
                return NotFound();
            }

            _context.Pozycje.Remove(pozycja);
            await _context.SaveChangesAsync();

            return Ok(pozycja);
        }


        private bool PozycjaExists(int id)
        {
            return _context.Pozycje.Any(e => e.PozycjaId == id);
        }
    }
}
