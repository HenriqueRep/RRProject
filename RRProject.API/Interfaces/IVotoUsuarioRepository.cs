using RRProject.API.Entities;

namespace RRProject.API.Interfaces
{
    public interface IVotoUsuarioRepository
    {
        Task<Candidata> ListarporID(int id);
        Task<Candidata> ProcurarCandidata();
        Task<Candidata> AdicionarCandidata(Candidata candidata);
        Task<Candidata> AtualizarCandidata(Candidata candidata);
        Task<Candidata> RemoverCandidata(Candidata candidata);
    }
}
