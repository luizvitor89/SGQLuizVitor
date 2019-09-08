using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using DT.API.Entities;
using DT.API.Helper;
using DT.API.Infrastructure.Services;
using DT.API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace DT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivulgacaoController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly IDTService _dtService;

        public DivulgacaoController(IEventBus eventBus,
                                IDTService dtService)
        {
            _eventBus = eventBus;
            _dtService = dtService;
        }

        [Authorize(Policy = "DTVisualizar")]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Divulgacao>>> GetDivulgacao()
        {
            return await _dtService.GetAllDivulgacaoAsync();
        }

        [Authorize(Policy = "DTVisualizar")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Divulgacao>> GetDivulgacao(Guid id)
        {
            var divulgacao = await _dtService.GetDivulgacaoAsync(id);

            if (divulgacao == null)
            {
                return NotFound();
            }

            return divulgacao;
        }

        [Authorize(Policy = "DTCadastrar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivulgacao(string id, Divulgacao divulgacao)
        {
            if (Guid.Parse(id) != divulgacao.Id)
            {
                return BadRequest();
            }

            try
            {
                await _dtService.UpdateDivulgacaoAsync(divulgacao);
            }
            catch
            {
                if (! (await DivulgacaoExistsAsync(Guid.Parse(id))))
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

        [Authorize(Policy = "DTCadastrar")]
        [HttpPost]
        public async Task<ActionResult<Divulgacao>> PostDivulgacao(Divulgacao divulgacao)
        {
            await _dtService.AddDivulgacaoAsync(divulgacao);

            return CreatedAtAction("GetDivulgacao", new { id = divulgacao.Id }, divulgacao);
        }

        private async Task<bool> DivulgacaoExistsAsync(Guid id)
        {
            var divulgacao = await _dtService.GetDivulgacaoAsync(id);
            return (divulgacao.Id == id);
        }

        [Authorize(Policy = "DTVisualizar")]
        [HttpGet("ComunicadoExterno")]
        public async Task<ActionResult<List<ComunicadoExternoVM>>> ComunicadoExterno()
        {
            var resultado = await _dtService.GetAllDivulgacaoAsync();
            var divulgacoes = resultado.Where(x => x.DivulgadoExternamente);
            var retorno = new List<ComunicadoExternoVM>();
            foreach (var item in divulgacoes)
            {
                var registro = new ComunicadoExternoVM()
                {
                    Id = item.Id,
                    OcorrenciaId = item.OcorrenciaId,
                    Consequencias = item.Consequencias,
                    CorpoDivulgacao = item.CorpoDivulgacao,
                    DataHora = item.DataHora,
                    Descricao = item.Descricao,
                    Resumo = item.Resumo,
                    Titulo = item.Titulo
                };
                retorno.Add(registro);
            }
           
            return retorno;
        }
    }
}