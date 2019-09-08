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
using BuildingBlocks.EventBus.Abstractions;
using CIP.API.IntegrationEvents.Events;

namespace CIP.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly CIPContext _context;
        private readonly IEventBus _eventBus;
        public OcorrenciaController(CIPContext context,
            IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        // GET: api/Ocorrencia
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> GetOcorrencia()
        {
            return await _context.Ocorrencia.ToListAsync();
        }

        // GET: api/Ocorrencia/5
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Ocorrencia>> GetOcorrencia(Guid id)
        {
            var ocorrencia = await _context.Ocorrencia.FindAsync(id);

            if (ocorrencia == null)
            {
                return NotFound();
            }

            return ocorrencia;
        }

        // PUT: api/Ocorrencia/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcorrencia(Guid id, Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.OcorrenciaId)
            {
                return BadRequest();
            }

            _context.Entry(ocorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcorrenciaExists(id))
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

        // POST: api/Ocorrencia
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPost]
        public async Task<ActionResult<Ocorrencia>> PostOcorrencia(Ocorrencia ocorrencia)
        {
            _context.Ocorrencia.Add(ocorrencia);
            await _context.SaveChangesAsync();

            var cadastroDT = new CadastroDTIntegrationEvent(Guid.NewGuid(), ocorrencia.OcorrenciaId, ocorrencia.EmissorId,
            ocorrencia.Titulo, ocorrencia.Descricao, "", ocorrencia.Consequencias, "",
            DateTime.Now, false, false);

            _eventBus.Publish(cadastroDT);
            return CreatedAtAction("GetOcorrencia", new { id = ocorrencia.OcorrenciaId }, ocorrencia);
        }

        // DELETE: api/Ocorrencia/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ocorrencia>> DeleteOcorrencia(Guid id)
        {
            var ocorrencia = await _context.Ocorrencia.FindAsync(id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            _context.Ocorrencia.Remove(ocorrencia);
            await _context.SaveChangesAsync();

            return ocorrencia;
        }

        private bool OcorrenciaExists(Guid id)
        {
            return _context.Ocorrencia.Any(e => e.OcorrenciaId == id);
        }
    }
}
