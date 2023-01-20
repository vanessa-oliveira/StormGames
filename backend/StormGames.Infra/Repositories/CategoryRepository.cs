using Microsoft.EntityFrameworkCore;
using StormGames.Domain.Entities;
using StormGames.Infra.Context;
using StormGames.Infra.Contracts;

namespace StormGames.Infra.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _dataContext;

    public CategoryRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Category> Insert(Category entity)
    {
        var category = await _dataContext.AddAsync(entity);
        Save();
        return category.Entity;
    }

    public void Update(Category entity)
    {
        _dataContext.Update(entity);
        Save();
    }

    public void Delete(Category entity)
    {
        _dataContext.Remove(entity);
        Save();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await _dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category != null)
        {
            return category; 
        }
        else
        {
            throw new Exception();
        }
    }

    public async Task<IList<Category>> GetAllCategories()
    {
        var categories = await _dataContext.Categories.ToListAsync();
        return categories;
    }
    
    private void Save()
    {
        _dataContext.SaveChangesAsync();
    }
}