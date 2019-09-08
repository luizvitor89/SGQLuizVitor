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
    public class InsumoController : ControllerBase
    {
        private readonly CIPContext _context;

        public InsumoController(CIPContext context)
        {
            _context = context;
        }

        // GET: api/Insumo
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insumo>>> GetInsumo()
        {
            return await _context.Insumo.ToListAsync();
        }

        // GET: api/Insumo/5
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Insumo>> GetInsumo(Guid id)
        {
            var insumo = await _context.Insumo.FindAsync(id);

            if (insumo == null)
            {
                return NotFound();
            }

            return insumo;
        }

        // PUT: api/Insumo/5
        [HttpPut("{id}")]
        [Authorize(Policy = "CIPCadastrar")]
        public async Task<IActionResult> PutInsumo(Guid id, Insumo insumo)
        {
            if (id != insumo.InsumoId)
            {
                return BadRequest();
            }

            _context.Entry(insumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsumoExists(id))
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

        // POST: api/Insumo
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPost]
        public async Task<ActionResult<Insumo>> PostInsumo(Insumo insumo)
        {
            _context.Insumo.Add(insumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsumo", new { id = insumo.InsumoId }, insumo);
        }

        // DELETE: api/Insumo/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Insumo>> DeleteInsumo(Guid id)
        {
            var insumo = await _context.Insumo.FindAsync(id);
            if (insumo == null)
            {
                return NotFound();
            }

            _context.Insumo.Remove(insumo);
            await _context.SaveChangesAsync();

            return insumo;
        }

        private bool InsumoExists(Guid id)
        {
            return _context.Insumo.Any(e => e.InsumoId == id);
        }
    }
}
