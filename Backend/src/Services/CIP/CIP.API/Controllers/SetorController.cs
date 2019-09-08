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
    public class SetorController : ControllerBase
    {
        private readonly CIPContext _context;

        public SetorController(CIPContext context)
        {
            _context = context;
        }

        // GET: api/Setor
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> GetSetor()
        {
            return await _context.Setor.ToListAsync();
        }

        // GET: api/Setor/5
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Setor>> GetSetor(Guid id)
        {
            var setor = await _context.Setor.FindAsync(id);

            if (setor == null)
            {
                return NotFound();
            }

            return setor;
        }

        // PUT: api/Setor/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetor(Guid id, Setor setor)
        {
            if (id != setor.SetorId)
            {
                return BadRequest();
            }

            _context.Entry(setor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetorExists(id))
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

        // POST: api/Setor
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPost]
        public async Task<ActionResult<Setor>> PostSetor(Setor setor)
        {
            _context.Setor.Add(setor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSetor", new { id = setor.SetorId }, setor);
        }

        // DELETE: api/Setor/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Setor>> DeleteSetor(Guid id)
        {
            var setor = await _context.Setor.FindAsync(id);
            if (setor == null)
            {
                return NotFound();
            }

            _context.Setor.Remove(setor);
            await _context.SaveChangesAsync();

            return setor;
        }

        private bool SetorExists(Guid id)
        {
            return _context.Setor.Any(e => e.SetorId == id);
        }
    }
}
