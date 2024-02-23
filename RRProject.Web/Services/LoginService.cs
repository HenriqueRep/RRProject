using Microsoft.JSInterop;
using Newtonsoft.Json;
using RRProject.Models.DTOs;
using RRProject.Web.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RRProject.Web.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _runtime;

        public LoginService(HttpClient httpClient, IJSRuntime runtime)
        {
            _httpClient = httpClient;
            _runtime = runtime;
        }

        public async Task<UsuarioLoginResponseDto> Login(UsuarioLoginRequestDto loginDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/usuario/login", loginDTO);

                if (response.IsSuccessStatusCode)
                {
                    // A resposta da API foi bem-sucedida
                    var contentString = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<UsuarioLoginResponseDto>(contentString);

                    if (loginResponse != null && loginResponse.Sucesso)
                    {
                        await ArmazenarTokenLocalStorage(loginResponse.Token);
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
                                      
                        await _runtime.InvokeVoidAsync("localStorage.setItem", "id", loginResponse.ID);
                        await _runtime.InvokeVoidAsync("localStorage.setItem", "usuario", loginResponse.Usuario);

                        return loginResponse;
                    }
                    else
                    {
                        // Tratar o erro de login falhado
                        // Aqui você pode retornar uma mensagem de erro específica se desejar
                        return null;
                    }
                }
                else
                {
                    // Tratar o erro de solicitação HTTP mal sucedida
                    // Aqui você pode retornar uma mensagem de erro específica se desejar
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                // Trate exceções de comunicação com o servidor
                return null;
            }
            catch (Exception)
            {
                // Trate outras exceções
                return null;
            }
        }
        public async Task Logout()
        {
            // Remova o token do localStorage
            await _runtime.InvokeVoidAsync("localStorage.removeItem", "authToken");
            await _runtime.InvokeVoidAsync("localStorage.removeItem", "id");
            await _runtime.InvokeVoidAsync("localStorage.removeItem", "usuario");  

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetTokenFromStorage());
            await _httpClient.PostAsync("api/logout", null);
        }
        private async Task<string> GetTokenFromStorage()
        {
            return await _runtime.InvokeAsync<string>("localStorage.getItem", "authToken");
        }

        private async Task ArmazenarTokenLocalStorage(string token)
        {
            // Chamada JavaScript para armazenar o token no localStorage
            await _runtime.InvokeVoidAsync("localStorage.setItem", "authToken", token);
        }

        public async Task<List<string>> GetUsers()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("api/usuario/users");
                response = response.Trim('[', ']');
                response = response.Replace("\"", "");
                var users = response.Split(',').ToList();
                return users;
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção que possa ocorrer durante a solicitação HTTP
                throw new Exception($"Erro ao obter a lista de usuários: {ex.Message}");
            }
        }
    }    
}


