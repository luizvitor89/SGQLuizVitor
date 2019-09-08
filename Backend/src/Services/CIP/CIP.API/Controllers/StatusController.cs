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
    public class StatusController : ControllerBase
    {
        private readonly CIPContext _context;

        public StatusController(CIPContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        // GET: api/Status/5
        [Authorize(Policy = "CIPVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(Guid id)
        {
            var status = await _context.Status.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }

        // PUT: api/Status/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(Guid id, Status status)
        {
            if (id != status.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        // POST: api/Status
        [Authorize(Policy = "CIPCadastrar")]
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = status.StatusId }, status);
        }

        // DELETE: api/Status/5
        [Authorize(Policy = "CIPCadastrar")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> DeleteStatus(Guid id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();

            return status;
        }

        private bool StatusExists(Guid id)
        {
            return _context.Status.Any(e => e.StatusId == id);
        }
    }
}
