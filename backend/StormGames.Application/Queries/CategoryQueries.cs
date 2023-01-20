using StormGames.Application.Queries.Models;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Queries;

public class CategoryQueries : ICategoryQueries
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryQueries(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryModel> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetCategoryById(id);
        var categoryOutput = new CategoryModel
        {
            Id = category.Id,
            Name = category.Name
        };
        return categoryOutput;
    }

    public async Task<IList<CategoryModel>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllCategories();
        var categoriesOutput = categories.Select(category => new CategoryModel {Id = category.Id, Name = category.Name}).ToList();
        return categoriesOutput;
    }
}