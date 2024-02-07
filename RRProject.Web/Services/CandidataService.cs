using RRProject.Web.Interfaces;
using RRProject.Models.DTOs;
using System.Net.Http.Json;
using System.Net;

namespace RRProject.Web.Services
{
    public class CandidataService : ICandidataService
    {
        public HttpClient _httpClient;
        public ILogger<CandidataService> _logger;

        public CandidataService(HttpClient httpClient, ILogger<CandidataService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CandidataDto> GetCandidatebyID(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/candidatas/{id}");
                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CandidataDto);
                    }
                    return await response.Content.ReadFromJsonAsync<CandidataDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter a candidata pelo id={id} -{message}");
                    throw new Exception($"Status code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro ao oter a candidata pelo id={id}");
                throw;
            }
        }

        public async Task<IEnumerable<CandidataDto>> GetCandidates()
        {
            try
            {
                var candidatasDto = await _httpClient.GetFromJsonAsync<IEnumerable<CandidataDto>>("api/candidatas");
                return candidatasDto;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao acessar produtos: api/candidatas");
                throw;
            }
        }
    }
}
