using StormGames.Application.Queries.Models;

namespace StormGames.Application.Queries;

public interface IRoleQueries
{
    public Task<IList<RoleModel>> GetAllRoles();
    public Task<RoleModel> GetRoleById(Guid id);
}