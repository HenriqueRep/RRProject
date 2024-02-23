using RRProject.API.Entities;

namespace RRProject.API.Interfaces
{
    public interface IIdentityService
    {
        Task<UsuarioCadastroResponse> CadastroUsuario(UsuarioCadastroRequest usuarioCadastro);
        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);
        Task<UsuarioLogoutResponse> Logout();
        Task<List<string>> GetUsers();
    }
}
