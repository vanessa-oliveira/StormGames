using Microsoft.EntityFrameworkCore;
using StormGames.Domain.Entities;
using StormGames.Infra.Context;
using StormGames.Infra.Contracts;

namespace StormGames.Infra.Repositories;

public class GenreRepository: IGenreRepository
{
    private readonly DataContext _dataContext;

    public GenreRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Genre> Insert(Genre entity)
    {
        var genre = await _dataContext.AddAsync(entity);
        await SaveChangesAsync();
        return genre.Entity;
    }

    public async Task<bool> Update(Genre entity)
    {
        _dataContext.Update(entity);
        return await SaveChangesAsync();
    }

    public async Task<bool> Delete(Genre entity)
    {
        _dataContext.Remove(entity);
        return await SaveChangesAsync();
    }

    public async Task<Genre> GetGenreById(Guid id)
    {
        var genre = await _dataContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
        if (genre != null)
        {
            return genre; 
        }
        else
        {
            throw new Exception();
        }
    }

    public async Task<IList<Genre>> GetAllGenres()
    {
        var genres = await _dataContext.Genres.ToListAsync();
        return genres;
    }
    
    private async Task<bool> SaveChangesAsync()
    {
        return (await _dataContext.SaveChangesAsync()) > 0;
    }
}