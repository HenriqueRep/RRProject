using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RRProject.API.Entities;
using RRProject.API.Interfaces;
using RRProject.Models.DTOs;

namespace RRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoUsuarioController : Controller
    {
        private readonly IAvaliacaoUsuarioRepository _avaliacaorepository;
        private readonly IMapper _mapper;
        public AvaliacaoUsuarioController(IAvaliacaoUsuarioRepository avaliacaorepository, IMapper mapper)
        {
            _avaliacaorepository = avaliacaorepository;
            _mapper = mapper;
        }
        
        [HttpGet("todas-avaliacoes")]
        public async Task<ActionResult<IEnumerable<AvaliacaoUsuario>>> GetAvaliacoes()
        {
            var avaliacoes = await _avaliacaorepository.GetAllAvaliacoes();
            return Ok(avaliacoes);
        }

        // GET: api/AvaliacaoUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoUsuario>> GetAvaliacao(int id)
        {
            var avaliacao = await _avaliacaorepository.GetAvaliacaoByIdUsuario(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return Ok(avaliacao);
        }
               
        [HttpPost("avaliar")]
        public async Task<ActionResult<AvaliacaoUsuario>> PostAvaliacao(AvaliacaoUsuario avaliacao)
        {
            try
            {
                await _avaliacaorepository.AddAvaliacao(avaliacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("alteraravaliacao/{candidataId}/{usuarioId}")]
        public async Task<IActionResult> AlterarAvaliacao(int candidataId, string usuarioId, [FromBody] AvaliacaoUsuario novaAvaliacao)
        {
            try
            {
                // Aqui você pode mapear a entidade AvaliacaoUsuario para o DTO AvaliacaoUsuarioDto
                var novaAvaliacaoDto = _mapper.Map<AvaliacaoUsuarioDto>(novaAvaliacao);

                // Chama o serviço para alterar a avaliação
                await _avaliacaorepository.AlterarAvaliacao(candidataId, usuarioId, novaAvaliacaoDto);

                // Retorna uma resposta HTTP indicando sucesso
                return Ok("Avaliação alterada com sucesso");
            }
            catch (Exception ex)
            {
                // Retorna uma resposta HTTP indicando erro, juntamente com a mensagem de erro
                return StatusCode(500, $"Erro ao alterar avaliação: {ex.Message}");
            }
        }


        [HttpGet("verificar-voto")]
        public async Task<ActionResult<List<int>>> VerificarVoto(string usuarioId)
        {
            try
            {
                var votos = await _avaliacaorepository.VerificarVoto(usuarioId);
                return Ok(votos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao verificar votos: {ex.Message}");
            }
        }
        [HttpGet("avaliacoes-usuario")]
        public async Task<ActionResult<List<AvaliacaoUsuarioDto>>> GetAvaliacoesByUsuarioId(string usuarioId)
        {
            try
            {
                // Aqui você deve buscar as avaliações do usuário com o ID fornecido
                var avaliacoes = await _avaliacaorepository.GetAvaliacoesByUsuarioId(usuarioId);

                // Verifica se há avaliações encontradas para o usuário
                if (avaliacoes == null || avaliacoes.Count == 0)
                {
                    // Retorna um código de status NotFound se não houver avaliações encontradas
                    return NotFound();
                }

                // Retorna as avaliações encontradas
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                // Se ocorrer algum erro durante a busca das avaliações, retorna um código de status 500 com uma mensagem de erro
                return StatusCode(500, $"Erro ao buscar avaliações do usuário: {ex.Message}");
            }
        }        
    }
}

