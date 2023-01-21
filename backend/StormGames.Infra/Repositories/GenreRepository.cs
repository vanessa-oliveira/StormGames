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
        Save();
        return genre.Entity;
    }

    public void Update(Genre entity)
    {
        _dataContext.Update(entity);
        Save();
    }

    public void Delete(Genre entity)
    {
        _dataContext.Remove(entity);
        Save();
    }

    public async Task<Genre> GetGenreById(int id)
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
    
    private void Save()
    {
        _dataContext.SaveChangesAsync();
    }
}