using StormGames.Domain.Entities;

namespace StormGames.Infra.Contracts;

public interface IRoleRepository : IGenericRepository<Role>
{
    public Task<IList<Role>> GetAllRoles();
    public Task<Role> GetRoleById(Guid id);
    public Task<Role> GetRoleByName(string name);
}