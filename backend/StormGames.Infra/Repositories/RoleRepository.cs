using Microsoft.EntityFrameworkCore;
using StormGames.Domain.Entities;
using StormGames.Infra.Context;
using StormGames.Infra.Contracts;

namespace StormGames.Infra.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly DataContext _dataContext;

    public RoleRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<Role> Insert(Role entity)
    {
        var role = await _dataContext.AddAsync(entity);
        await SaveChangesAsync();
        return role.Entity;
    }

    public async Task<bool> Update(Role entity)
    {
        _dataContext.Update(entity);
        return await SaveChangesAsync();
    }

    public async Task<bool> Delete(Role entity)
    {
        _dataContext.Remove(entity);
        return await SaveChangesAsync();
    }

    public async Task<Role> GetRoleById(Guid id)
    {
        var role = await _dataContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
        return role;
    }

    public async Task<IList<Role>> GetAllRoles()
    {
        var roles = await _dataContext.Roles.ToListAsync();
        return roles;
    }

    public async Task<Role> GetRoleByName(string name)
    {
        var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Name == name);
        return role;
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}