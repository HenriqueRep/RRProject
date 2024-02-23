using RRProject.Models.DTOs;

namespace RRProject.Web.Interfaces
{
    public interface ILoginService
    {
        Task<UsuarioLoginResponseDto> Login(UsuarioLoginRequestDto loginDTO);
        Task Logout();
        Task<List<string>> GetUsers();
    }
}
