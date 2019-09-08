using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CIP.API.Entities;
using CIP.API.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace CIP.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CronogramaController : ControllerBase
    {
        private readonly CIPContext _context;

        public CronogramaController(CIPContext context)
        {
            _context = context;
        }

        // GET: api/Cronograma
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cronograma>>> GetCronograma()
        {
            return await _context.Cronograma.ToListAsync();
        }

        // GET: api/Cronograma/5
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Cronograma>> GetCronograma(Guid id)
        {
            var cronograma = await _context.Cronograma.FindAsync(id);

            if (cronograma == null)
            {
                return NotFound();
            }

            return cronograma;
        }

        // PUT: api/Cronograma/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCronograma(Guid id, Cronograma cronograma)
        {
            if (id != cronograma.CronogramaId)
            {
                return BadRequest();
            }

            _context.Entry(cronograma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CronogramaExists(id))
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

        // POST: api/Cronograma
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPost]
        public async Task<ActionResult<Cronograma>> PostCronograma(Cronograma cronograma)
        {
            _context.Cronograma.Add(cronograma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCronograma", new { id = cronograma.CronogramaId }, cronograma);
        }

        // DELETE: api/Cronograma/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cronograma>> DeleteCronograma(Guid id)
        {
            var cronograma = await _context.Cronograma.FindAsync(id);
            if (cronograma == null)
            {
                return NotFound();
            }

            _context.Cronograma.Remove(cronograma);
            await _context.SaveChangesAsync();

            return cronograma;
        }

        private bool CronogramaExists(Guid id)
        {
            return _context.Cronograma.Any(e => e.CronogramaId == id);
        }
    }
}
