using AulaMSFront.Models;

namespace AulaMSFront.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetByIdProductsAsync(long id);
        Task<ProductModel> GetByNameProductsAsync(ProductModel product);
        Task<ProductModel> CreateProductsAsync(ProductModel product);
        Task<ProductModel> UpdateProductsAsync(ProductModel product);
        Task<bool> DeleteProductsAsync(long id);

    }
}
