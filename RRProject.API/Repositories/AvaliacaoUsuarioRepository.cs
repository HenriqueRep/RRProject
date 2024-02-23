using Microsoft.EntityFrameworkCore;
using RRProject.API.Context;
using RRProject.API.Entities;
using RRProject.API.Interfaces;
using RRProject.Models.DTOs;

namespace RRProject.API.Repositories
{
    public class AvaliacaoUsuarioRepository : IAvaliacaoUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public AvaliacaoUsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<AvaliacaoUsuario>> GetAllAvaliacoes()
        {
            var resultado = await _appDbContext.Avaliacao.ToListAsync();
            return resultado;
        }

        public async Task<AvaliacaoUsuario> GetAvaliacaoByIdUsuario(int id)
        {
            var resultado = await _appDbContext.Avaliacao.FirstOrDefaultAsync(a => a.Id == id);
            return resultado;
        }
        public async Task AddAvaliacao(AvaliacaoUsuario avaliacao)
        {
            _appDbContext.Avaliacao.Add(avaliacao);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<int>> VerificarVoto(string usuarioId)
        {
            // Busca as candidatas já votadas pelo usuário
            var votos = await _appDbContext.Avaliacao
                .Where(a => a.UsuarioIdenti == usuarioId)
                .Select(a => a.CandidataIdenti)
                .ToListAsync();

            return votos;
        }
        public async Task<List<AvaliacaoUsuario>> GetAvaliacoesByUsuarioId(string usuarioId)
        {
            try
            {
                // Consulta ao banco de dados para buscar as avaliações do usuário pelo ID
                var avaliacoes = await _appDbContext.Avaliacao
                    .Where(a => a.UsuarioIdenti == usuarioId)
                    .ToListAsync();

                return avaliacoes;
            }
            catch (Exception ex)
            {
                // Tratar exceções, como problemas de conexão com o banco de dados
                throw new Exception($"Erro ao buscar avaliações do usuário: {ex.Message}");
            }
        }
        public async Task AlterarAvaliacao(int candidataId, string usuarioId, AvaliacaoUsuarioDto novaAvaliacao)
        {
            try
            {
                // Verifique se a avaliação já existe
                AvaliacaoUsuario avaliacaoExistente = await _appDbContext.Avaliacao
                    .FirstOrDefaultAsync(a => a.CandidataIdenti == candidataId && a.UsuarioIdenti == usuarioId);

                // Se não existir, crie uma nova avaliação
                if (avaliacaoExistente == null)
                {
                    AvaliacaoUsuario novaAvaliacaoUsuario = new AvaliacaoUsuario
                    {
                        CandidataIdenti = candidataId,
                        UsuarioIdenti = usuarioId,
                        NotaBeleza = novaAvaliacao.NotaBeleza,
                        NotaFantasia = novaAvaliacao.NotaFantasia,
                        NotaApresentacao = novaAvaliacao.NotaApresentacao,
                        Comentario = novaAvaliacao.Comentario
                    };

                    _appDbContext.Avaliacao.Add(novaAvaliacaoUsuario);
                }
                else
                {
                    // Atualize a avaliação existente
                    avaliacaoExistente.NotaBeleza = novaAvaliacao.NotaBeleza;
                    avaliacaoExistente.NotaFantasia = novaAvaliacao.NotaFantasia;
                    avaliacaoExistente.NotaApresentacao = novaAvaliacao.NotaApresentacao;
                    avaliacaoExistente.Comentario = novaAvaliacao.Comentario;
                    _appDbContext.Avaliacao.Update(avaliacaoExistente);
                }

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar avaliação da candidata: {ex.Message}");
            }
        }

    }
}
