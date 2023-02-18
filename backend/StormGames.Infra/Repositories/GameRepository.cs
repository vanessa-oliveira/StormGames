using Microsoft.EntityFrameworkCore;
using StormGames.Domain.Entities;
using StormGames.Infra.Context;
using StormGames.Infra.Contracts;

namespace StormGames.Infra.Repositories;

public class GameRepository : IGameRepository
{
    private readonly DataContext _dataContext;

    public GameRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<Game> Insert(Game entity)
    {
        var game = await _dataContext.AddAsync(entity);
        await SaveChangesAsync();
        return game.Entity;
    }

    public async Task<bool> Update(Game entity)
    {
        _dataContext.Update(entity);
        return await SaveChangesAsync();
    }

    public async Task<bool> Delete(Game entity)
    {
        _dataContext.Remove(entity);
        return await SaveChangesAsync();
    }

    public async Task<Game> GetGameById(Guid id)
    {
        var game = await _dataContext.Games.Include(g => g.Genres).FirstOrDefaultAsync(x => x.Id == id);
        if (game != null)
        {
            return game;
        }

        throw new Exception();
    }

    public async Task<IList<Game>> GetAllGames()
    {
        var games = await _dataContext.Games.Include(g => g.Genres).ToListAsync();
        return games;
    }

    private async Task<bool> SaveChangesAsync()
    {
        return (await _dataContext.SaveChangesAsync()) > 0;
    }
}