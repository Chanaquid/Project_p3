using Core.Entities;

namespace Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
        Task AddCategoryAsync(Category category);
        void DeleteCategoryAsync(Category category);
        Task<int> SaveChangesAsync();
    }
}