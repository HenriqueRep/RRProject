using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RRProject.API.Interfaces;
using RRProject.Models.DTOs;

namespace RRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsers()
        {
            try
            {
                var users = await _usuarioRepository.GetUsers();
                if (users is null)
                {
                    return NotFound();
                }
                else
                {
                    var usuariosDtos = _mapper.Map<UsuarioDto>(users);
                    return Ok(usuariosDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessa a base de dados");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Getuser(int id)
        {
            try
            {
                var users = await _usuarioRepository.GetUser(id);
                if (users is null)
                {
                    return NotFound("Erro ao localizar o usuário!");
                }
                else
                {
                    var usuariosDtos = _mapper.Map<UsuarioDto>(users);
                    return Ok(usuariosDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessa a base de dados");
            }
        }
    }
}
