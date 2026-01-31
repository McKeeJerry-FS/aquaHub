using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AquaHub.Mobile.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthResult?> RegisterAsync(string email, string password, string userName)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/register", new { email, password, userName });
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AuthResult>();
            return null;
        }

        public async Task<AuthResult?> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", new { email, password });
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AuthResult>();
            return null;
        }
    }

    public class AuthResult
    {
        public string Token { get; set; } = string.Empty;
        public AppUserDto User { get; set; } = new();
    }

    public class AppUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
