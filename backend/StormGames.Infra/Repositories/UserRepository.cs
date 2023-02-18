using Microsoft.EntityFrameworkCore;
using StormGames.Domain.Entities;
using StormGames.Infra.Context;
using StormGames.Infra.Contracts;

namespace StormGames.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User> Insert(User entity)
    {
        var user = await _dataContext.AddAsync(entity);
        await SaveChangesAsync();
        return user.Entity;
    }

    public async Task<bool> Update(User entity)
    {
        _dataContext.Update(entity);
        return await SaveChangesAsync();
    }

    public async Task<bool> Delete(User entity)
    {
        _dataContext.Remove(entity);
        return await SaveChangesAsync();
    }

    public async Task<User> GetUserById(Guid id)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        return user;
    }

    public async Task<IList<User>> GetAllActiveUsers()
    {
        var users = await _dataContext.Users.Where(x => x.Active == true).ToListAsync();
        return users;
    }
    
    private async Task<bool> SaveChangesAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}