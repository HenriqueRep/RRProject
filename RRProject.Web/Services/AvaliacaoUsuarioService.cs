using Newtonsoft.Json;
using RRProject.Models.DTOs;
using RRProject.Web.Interfaces;
using System.Net.Http.Json;
using System.Text;

namespace RRProject.Web.Services
{
    public class AvaliacaoUsuarioService : IAvaliacaoUsuarioService
    {
        public HttpClient _httpClient;
        public ILogger<AvaliacaoUsuarioDto> _logger;

        public AvaliacaoUsuarioService(HttpClient httpClient, ILogger<AvaliacaoUsuarioDto> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<bool> SalvarAvaliacao(AvaliacaoUsuarioDto avaliacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/AvaliacaoUsuario/avaliar", avaliacao);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Trate o caso de falha ao salvar a avaliação, se necessário
                    // Por exemplo, registre um log de erro
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Trate exceções, se necessário
                // Por exemplo, registre um log de exceção
                return false;
            }
        }
        public async Task<List<int>> VerificarVoto(string usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/AvaliacaoUsuario/verificar-voto?usuarioId={usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<int>>();
                }
                else
                {
                    // Se a solicitação falhar, lance uma exceção ou retorne uma lista vazia, dependendo da lógica da sua aplicação
                    throw new Exception($"Erro ao verificar votos: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção que possa ocorrer durante a solicitação HTTP
                throw new Exception($"Erro ao verificar votos: {ex.Message}");
            }
        }
        public async Task<List<AvaliacaoUsuarioDto>> GetAvaliacoesByUsuarioId(string usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/AvaliacaoUsuario/avaliacoes-usuario?usuarioId={usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<AvaliacaoUsuarioDto>>();
                }
                else
                {
                    // Se a solicitação falhar, lance uma exceção ou retorne uma lista vazia, dependendo da lógica da sua aplicação
                    throw new Exception($"Erro ao obter avaliações do usuário: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção que possa ocorrer durante a solicitação HTTP
                throw new Exception($"Erro ao obter avaliações do usuário: {ex.Message}");
            }
        }

        public async Task<List<AvaliacaoUsuarioDto>> GetAvaliacoesByUsuarioGuid(string usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/AvaliacaoUsuario/avaliacoes-usuario?usuarioId={usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<AvaliacaoUsuarioDto>>();
                }
                else
                {
                    // Se a solicitação falhar, lance uma exceção ou retorne uma lista vazia, dependendo da lógica da sua aplicação
                    throw new Exception($"Erro ao obter avaliações do usuário: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção que possa ocorrer durante a solicitação HTTP
                throw new Exception($"Erro ao obter avaliações do usuário: {ex.Message}");
            }
        }
        public async Task<List<AvaliacaoUsuarioDto>> GetAllAvaliacoes()
        {
            try
            {
                var avaliacoes = await _httpClient.GetFromJsonAsync<List<AvaliacaoUsuarioDto>>("api/AvaliacaoUsuario/todas-avaliacoes");
                // Calcular o total dos votos para cada categoria de avaliação
                foreach (var avaliacao in avaliacoes)
                {
                    avaliacao.TotalVotos = avaliacao.NotaBeleza + avaliacao.NotaFantasia + avaliacao.NotaApresentacao;
                }
                return avaliacoes;
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção que possa ocorrer durante a solicitação HTTP
                throw new Exception($"Erro ao obter todas as avaliações: {ex.Message}");
            }
        }
        public async Task<bool> AlterarAvaliacao(int candidataId, string usuarioId, AvaliacaoUsuarioDto novaAvaliacao)
        {
            try
            {
                // Serializa o objeto novaAvaliacao para JSON
                var jsonContent = JsonConvert.SerializeObject(novaAvaliacao);

                // Define a URL do endpoint
                var url = $"api/AvaliacaoUsuario/alteraravaliacao/{candidataId}/{usuarioId}";

                // Cria um conteúdo JSON a ser enviado na requisição
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Faz uma requisição HTTP PUT para o endpoint correspondente na API
                var response = await _httpClient.PutAsync(url, httpContent);

                // Verifica se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Se não foi bem-sucedida, lança uma exceção com a mensagem de erro retornada pela API
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro ao alterar avaliação: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer algum erro durante a requisição, lança uma exceção com a mensagem de erro
                throw new Exception($"Erro ao alterar avaliação: {ex.Message}");
            }
        }
    }
}

