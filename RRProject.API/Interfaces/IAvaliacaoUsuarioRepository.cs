using RRProject.API.Entities;
using RRProject.Models.DTOs;
using System.Threading.Tasks;

namespace RRProject.API.Interfaces
{
    public interface IAvaliacaoUsuarioRepository
    {
        Task<IEnumerable<AvaliacaoUsuario>> GetAllAvaliacoes();
        Task<AvaliacaoUsuario> GetAvaliacaoByIdUsuario(int id);
        Task AddAvaliacao(AvaliacaoUsuario avaliacao);
        Task<List<int>> VerificarVoto(string usuarioId);
        Task<List<AvaliacaoUsuario>> GetAvaliacoesByUsuarioId(string usuarioId);
        Task AlterarAvaliacao(int candidataId, string usuarioId, AvaliacaoUsuarioDto novaAvaliacao);
    }
}
