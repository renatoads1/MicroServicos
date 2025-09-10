using AulaMSFront.Models;
using AulaMSFront.Services.IServices;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AulaMSFront.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IConfiguration _config;

        public ProductService(HttpClient client, IHttpContextAccessor httpContext, IConfiguration config)
        {
            _client = client;
            _httpContext = httpContext;
            _config = config;
        }

        private void AddJwtHeader()
        {
            var token = _httpContext.HttpContext?.Session.GetString("JWTToken");
            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            AddJwtHeader();
            var response = await _client.GetAsync($"{_config["ServicesUrls:ProductApi"]}/api/v1/controller");

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ProductModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // Outras implementações semelhantes...
        public Task<ProductModel> GetByIdProductsAsync(long id) => throw new NotImplementedException();
        public Task<ProductModel> GetByNameProductsAsync(ProductModel product) => throw new NotImplementedException();
        public Task<ProductModel> CreateProductsAsync(ProductModel product) => throw new NotImplementedException();
        public Task<ProductModel> UpdateProductsAsync(ProductModel product) => throw new NotImplementedException();
        public Task<bool> DeleteProductsAsync(long id) => throw new NotImplementedException();

    }
}
