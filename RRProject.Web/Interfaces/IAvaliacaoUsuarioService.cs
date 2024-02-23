using RRProject.Models.DTOs;

namespace RRProject.Web.Interfaces
{
    public interface IAvaliacaoUsuarioService
    {
        Task<bool> SalvarAvaliacao(AvaliacaoUsuarioDto avaliacao);
        Task<List<int>> VerificarVoto(string usuarioId);
        Task<List<AvaliacaoUsuarioDto>> GetAvaliacoesByUsuarioId(string usuarioId);
        Task<List<AvaliacaoUsuarioDto>> GetAvaliacoesByUsuarioGuid(string usuarioId);
        Task<List<AvaliacaoUsuarioDto>> GetAllAvaliacoes();
        Task<bool> AlterarAvaliacao(int candidataId, string usuarioId, AvaliacaoUsuarioDto novaAvaliacao);
    }
}
