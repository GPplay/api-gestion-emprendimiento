using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Emprendimientos2.Models;
using Emprendimientos2.Context;

namespace Emprendimientos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprendimientoesController : ControllerBase
    {
        private readonly GestionEmprendimientoContext _context;

        public EmprendimientoesController(GestionEmprendimientoContext context)
        {
            _context = context;
        }

        // GET: api/Emprendimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprendimiento>>> GetEmprendimientos()
        {
            return await _context.Emprendimientos.ToListAsync();
        }

        // GET: api/Emprendimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emprendimiento>> GetEmprendimiento(int id)
        {
            var emprendimiento = await _context.Emprendimientos.FindAsync(id);

            if (emprendimiento == null)
            {
                return NotFound();
            }

            return emprendimiento;
        }

        // PUT: api/Emprendimientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmprendimiento(int id, Emprendimiento emprendimiento)
        {
            if (id != emprendimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(emprendimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprendimientoExists(id))
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

        // POST: api/Emprendimientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emprendimiento>> PostEmprendimiento(Emprendimiento emprendimiento)
        {
            _context.Emprendimientos.Add(emprendimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmprendimiento", new { id = emprendimiento.Id }, emprendimiento);
        }

        // DELETE: api/Emprendimientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmprendimiento(int id)
        {
            var emprendimiento = await _context.Emprendimientos.FindAsync(id);
            if (emprendimiento == null)
            {
                return NotFound();
            }

            _context.Emprendimientos.Remove(emprendimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmprendimientoExists(int id)
        {
            return _context.Emprendimientos.Any(e => e.Id == id);
        }
    }
}
