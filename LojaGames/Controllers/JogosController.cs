using LojaGames.DTOs.Request;
using LojaGames.DTOs.Response;
using LojaGames.Services.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameResponseDTO>>> Obter([FromQuery] int pagina = 1, [FromQuery] int quantidade = 5)
        {
            var result = await _jogoService.Obter(pagina, quantidade);

            if (result.Count() == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GameResponseDTO>> Inserir([FromBody] GameRequestDTO jogo)
        {
            try
            {
                var result = await _jogoService.Inserir(jogo);
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{idJogo}")]
        public async Task<ActionResult> Atualizar([FromRoute] Guid idJogo, [FromBody] GameRequestDTO jogo)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogo);
                return Ok();
            }
            catch(Exception)
            {
                return NotFound();
                throw;
            }
        }
        [HttpDelete]
        [Route("{idJogo}")]
        public async Task<ActionResult> Excluir([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }
    }
}
