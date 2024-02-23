using RRProject.Models.DTOs;
using RRProject.Web.Interfaces;
using System.Net.Http.Json;

namespace RRProject.Web.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Register(UsuarioCadastroRequestDto usuario)
        {
            try
            {                
                var response = await _httpClient.PostAsJsonAsync("api/usuario/cadastro", usuario);
                response.EnsureSuccessStatusCode(); 

                return true;
            }
            catch (HttpRequestException)
            {
                // Lida com erros de requisição, como falha de conexão
                return false;
            }
        }
    }
}

