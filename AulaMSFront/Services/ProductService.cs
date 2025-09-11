using AulaMSFront.Models;
using AulaMSFront.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
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
            AddJwtHeader();//seta no header a autorização
            var response = await _client.GetAsync($"{_config["ServicesUrls:ProductApi"]}/api/v1/controller");

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(json);
        }

        // Outras implementações semelhantes...
        public async Task<ProductModel> GetByIdProductsAsync(long id)
        {
            AddJwtHeader();
            var response = await _client.GetAsync($"{_config["ServicesUrls:ProductApi"]}/api/v1/controller/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductModel>(json);

            return product;
        }
        
        public Task<ProductModel> GetByNameProductsAsync(ProductModel product) { 
        
            throw new NotImplementedException();
        }
        public async Task<ProductModel> CreateProductsAsync(ProductModel product) {

            AddJwtHeader();
            var content = new StringContent(
                  JsonConvert.SerializeObject(product),
                  Encoding.UTF8,
                  "application/json");
            var response = await _client.PostAsync($"{_config["ServicesUrls:ProductApi"]}/api/v1/controller", content);

            // Verifica se a resposta foi bem sucedida
            response.EnsureSuccessStatusCode();

            // Lê o corpo da resposta e desserializa para ProductModel
            var responseContent = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<ProductModel>(responseContent);

            return createdProduct;
        }
        public async Task<ProductModel> UpdateProductsAsync(ProductModel product) {


            AddJwtHeader();
            var content = new StringContent(
                  JsonConvert.SerializeObject(product),
                  Encoding.UTF8,
                  "application/json");
            var response = await _client.PostAsync($"{_config["ServicesUrls:ProductApi"]}/api/v1/controller", content);

            // Verifica se a resposta foi bem sucedida
            response.EnsureSuccessStatusCode();

            // Lê o corpo da resposta e desserializa para ProductModel
            var responseContent = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<ProductModel>(responseContent);

            return createdProduct;
        }
        public Task<bool> DeleteProductsAsync(long id) { 
            
            throw new NotImplementedException();
        }

    }
}
