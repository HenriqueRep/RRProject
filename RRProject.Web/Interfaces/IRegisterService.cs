using RRProject.Models.DTOs;

namespace RRProject.Web.Interfaces
{
    public interface IRegisterService
    {
        Task<bool> Register(UsuarioCadastroRequestDto usuario);
    }
}
