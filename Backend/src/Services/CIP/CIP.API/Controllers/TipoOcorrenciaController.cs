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
    public class TipoOcorrenciaController : ControllerBase
    {
        private readonly CIPContext _context;

        public TipoOcorrenciaController(CIPContext context)
        {
            _context = context;
        }

        // GET: api/TipoOcorrencia
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOcorrencia>>> GetTipoOcorrencia()
        {
            return await _context.TipoOcorrencia.ToListAsync();
        }

        // GET: api/TipoOcorrencia/5
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOcorrencia>> GetTipoOcorrencia(Guid id)
        {
            var tipoOcorrencia = await _context.TipoOcorrencia.FindAsync(id);

            if (tipoOcorrencia == null)
            {
                return NotFound();
            }

            return tipoOcorrencia;
        }

        // PUT: api/TipoOcorrencia/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOcorrencia(Guid id, TipoOcorrencia tipoOcorrencia)
        {
            if (id != tipoOcorrencia.TipoOcorrenciaId)
            {
                return BadRequest();
            }

            _context.Entry(tipoOcorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoOcorrenciaExists(id))
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

        // POST: api/TipoOcorrencia
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPost]
        public async Task<ActionResult<TipoOcorrencia>> PostTipoOcorrencia(TipoOcorrencia tipoOcorrencia)
        {
            _context.TipoOcorrencia.Add(tipoOcorrencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoOcorrencia", new { id = tipoOcorrencia.TipoOcorrenciaId }, tipoOcorrencia);
        }

        // DELETE: api/TipoOcorrencia/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoOcorrencia>> DeleteTipoOcorrencia(Guid id)
        {
            var tipoOcorrencia = await _context.TipoOcorrencia.FindAsync(id);
            if (tipoOcorrencia == null)
            {
                return NotFound();
            }

            _context.TipoOcorrencia.Remove(tipoOcorrencia);
            await _context.SaveChangesAsync();

            return tipoOcorrencia;
        }

        private bool TipoOcorrenciaExists(Guid id)
        {
            return _context.TipoOcorrencia.Any(e => e.TipoOcorrenciaId == id);
        }
    }
}
