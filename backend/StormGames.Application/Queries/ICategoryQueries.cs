using StormGames.Application.Queries.Models;

namespace StormGames.Application.Queries;

public interface ICategoryQueries
{
    public Task<CategoryModel> GetCategoryById(int id);
    public Task<IList<CategoryModel>> GetAllCategories();
}