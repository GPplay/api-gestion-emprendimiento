using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Emprendimientos2.Models;

namespace Emprendimientos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionFinancieraController : ControllerBase
    {
        private readonly GestionEmprendimientoContext _context;

        public TransaccionFinancieraController(GestionEmprendimientoContext context)
        {
            _context = context;
        }

        // GET: api/TransaccionFinanciera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransaccionFinanciera>>> GetTransaccionFinancieras()
        {
            return await _context.TransaccionFinancieras.ToListAsync();
        }

        // GET: api/TransaccionFinanciera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransaccionFinanciera>> GetTransaccionFinanciera(int id)
        {
            var transaccionFinanciera = await _context.TransaccionFinancieras.FindAsync(id);

            if (transaccionFinanciera == null)
            {
                return NotFound();
            }

            return transaccionFinanciera;
        }

        // PUT: api/TransaccionFinanciera/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccionFinanciera(int id, TransaccionFinanciera transaccionFinanciera)
        {
            if (id != transaccionFinanciera.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaccionFinanciera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionFinancieraExists(id))
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

        // POST: api/TransaccionFinanciera
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransaccionFinanciera>> PostTransaccionFinanciera(TransaccionFinanciera transaccionFinanciera)
        {
            _context.TransaccionFinancieras.Add(transaccionFinanciera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaccionFinanciera", new { id = transaccionFinanciera.Id }, transaccionFinanciera);
        }

        // DELETE: api/TransaccionFinanciera/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaccionFinanciera(int id)
        {
            var transaccionFinanciera = await _context.TransaccionFinancieras.FindAsync(id);
            if (transaccionFinanciera == null)
            {
                return NotFound();
            }

            _context.TransaccionFinancieras.Remove(transaccionFinanciera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransaccionFinancieraExists(int id)
        {
            return _context.TransaccionFinancieras.Any(e => e.Id == id);
        }
    }
}
