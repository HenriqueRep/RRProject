using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRProject.API.Entities;
using RRProject.API.Interfaces;
using RRProject.Models.DTOs;

namespace RRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IIdentityService _identityService;
        private readonly IMapper _mapper;

        public UsuarioController(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<string>>> GetUsers()
        {
            var users = await _identityService.GetUsers();
            return Ok(users);
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequestDto usuarioCadastroDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var usuarioCadastro = _mapper.Map<UsuarioCadastroRequest>(usuarioCadastroDto);
            var resultado = await _identityService.CadastroUsuario(usuarioCadastro);
            if (resultado.Sucesso)
            {
                var usuarioCadastroResponseDto = _mapper.Map<UsuarioCadastroResponseDto>(resultado);
                return Ok(usuarioCadastroResponseDto);
            }
           
            else if (resultado.Erros.Count > 0)
                return BadRequest(resultado);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResponseDto>> Login(UsuarioLoginRequestDto usuarioLogin)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuarioLoginDto = _mapper.Map<UsuarioLoginRequest>(usuarioLogin);
            var resultado = await _identityService.Login(usuarioLoginDto);
            var resultadoDto = _mapper.Map<UsuarioLoginResponseDto>(resultado);
            if (resultado.Sucesso)
                return Ok(resultadoDto);

            return Unauthorized(resultadoDto);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Implementação do logout
            var logoutResult = await _identityService.Logout();

            if (logoutResult.Sucesso)
            {
                return Ok(new { message = "Logout realizado com sucesso." });
            }
            else
            {
                return BadRequest(new { error = "O logout falhou." });
            }
        }
    }
}
