using Microsoft.EntityFrameworkCore;
using StormGames.Domain.Entities;
using StormGames.Infra.Context;
using StormGames.Infra.Contracts;

namespace StormGames.Infra.Repositories;

public class GameRepository : IGameRepository
{
    private readonly DataContext _datacontext;

    public GameRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }
    public async Task<Game> Insert(Game entity)
    {
        var game = await _datacontext.AddAsync(entity);
        Save();
        return game.Entity;
    }

    public void Update(Game entity)
    {
        _datacontext.Update(entity);
        Save();
    }

    public void Delete(Game entity)
    {
        _datacontext.Remove(entity);
        Save();
    }

    public async Task<Game> GetGameById(int id)
    {
        var game = await _datacontext.Games.FirstOrDefaultAsync(x => x.Id == id);
        if (game != null)
        {
            return game;
        }

        throw new Exception();
    }

    public async Task<IList<Game>> GetAllGames()
    {
        var games = await _datacontext.Games.ToListAsync();
        return games;
    }

    private void Save()
    {
        _datacontext.SaveChangesAsync();
    }
}