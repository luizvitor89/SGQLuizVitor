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
    public class EmissorController : ControllerBase
    {
        private readonly CIPContext _context;

        public EmissorController(CIPContext context)
        {
            _context = context;
        }

        // GET: api/Emissor
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emissor>>> GetEmissor()
        {
            return await _context.Emissor.ToListAsync();
        }

        // GET: api/Emissor/5
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Emissor>> GetEmissor(Guid id)
        {
            var emissor = await _context.Emissor.FindAsync(id);

            if (emissor == null)
            {
                return NotFound();
            }

            return emissor;
        }

        // PUT: api/Emissor/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmissor(Guid id, Emissor emissor)
        {
            if (id != emissor.EmissorId)
            {
                return BadRequest();
            }

            _context.Entry(emissor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmissorExists(id))
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

        // POST: api/Emissor
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPost]
        public async Task<ActionResult<Emissor>> PostEmissor(Emissor emissor)
        {
            _context.Emissor.Add(emissor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmissor", new { id = emissor.EmissorId }, emissor);
        }

        // DELETE: api/Emissor/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Emissor>> DeleteEmissor(Guid id)
        {
            var emissor = await _context.Emissor.FindAsync(id);
            if (emissor == null)
            {
                return NotFound();
            }

            _context.Emissor.Remove(emissor);
            await _context.SaveChangesAsync();

            return emissor;
        }

        [AllowAnonymous]
        [HttpPost("ValidateEmissor")]
        public async Task<ActionResult<Emissor>> ValidateEmissor(Emissor emissor)
        {
            var resultado = await _context.Emissor.Where(x => x.Email == emissor.Email && x.Senha == emissor.Senha).FirstOrDefaultAsync();

            return resultado;
        }

        private bool EmissorExists(Guid id)
        {
            return _context.Emissor.Any(e => e.EmissorId == id);
        }
    }
}
