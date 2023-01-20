using StormGames.Domain.Entities;

namespace StormGames.Infra.Contracts;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<Category> GetCategoryById(int id);
    public Task<IList<Category>> GetAllCategories();
}