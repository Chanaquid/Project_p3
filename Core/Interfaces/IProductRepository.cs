using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task AddProductAsync(Product product);
        void UpdateProduct(Product product);
        void DeleteProductAsync(Product product);
        Task<int> SaveChangesAsync();
    }
}