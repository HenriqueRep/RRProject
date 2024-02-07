using RRProject.API.Entities;

namespace RRProject.API.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsers();
        Task<Usuario> GetUser(int id); 
    }
}
