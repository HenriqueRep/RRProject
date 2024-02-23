using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RRProject.API.Interfaces;
using RRProject.Models.DTOs;

namespace RRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatasController : Controller
    {
        private readonly ICandidataRepository _candidataRepository;
        private readonly IMapper _mapper;

        public CandidatasController(ICandidataRepository candidataRepository, IMapper mapper)
        {
            _candidataRepository = candidataRepository;
            _mapper = mapper;
        }

        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CandidataDto>> GetCandidate(int id)
        {
            try
            {
                var candidata = await _candidataRepository.ListbyId(id);
                if (candidata is null)
                {
                    return NotFound("Erro ao localizar a candidata!");
                }
                else
                {
                    var candidataDto = _mapper.Map<CandidataDto>(candidata);
                    return Ok(candidataDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessa a base de dados");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidataDto>>> GetCandidates()
        {
            try
            {
                var candidates = await _candidataRepository.GetList();
                if (candidates is null)
                {
                    return NotFound();
                }
                else
                {
                    var candidatesdtos = _mapper.Map<IEnumerable<CandidataDto>>(candidates);
                    return Ok(candidatesdtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessa a base de dados");
            }
        }
    }
}
