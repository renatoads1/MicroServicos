using AulaMSFront.Models;
using AulaMSFront.Services.IServices;
using System.Text;
using System.Text.Json;

namespace AulaMSFront.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;


        public AuthService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task<string> LoginAsync(LoginModel login)
        {
            var content = new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_config["ServicesUrls:ProductApi"]}/api/v1/auth/login", content);

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("token").GetString();
        }

    }
}
