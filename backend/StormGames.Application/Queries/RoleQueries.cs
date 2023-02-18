using StormGames.Application.Queries.Models;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Queries;

public class RoleQueries : IRoleQueries
{
    private readonly IRoleRepository _roleRepository;

    public RoleQueries(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    public async Task<IList<RoleModel>> GetAllRoles()
    {
        var rolesOutput = new List<RoleModel>();
        var roles = await _roleRepository.GetAllRoles();
        foreach (var role in roles)
        {
            rolesOutput.Add(new RoleModel
            {
                Id = role.Id,
                Name = role.Name
            });
        }
        
        return rolesOutput;
    }

    public async Task<RoleModel> GetRoleById(Guid id)
    {
        var role = await _roleRepository.GetRoleById(id);
        var roleOutput = new RoleModel
        {
            Id = role.Id,
            Name = role.Name
        };
        return roleOutput;
    }
}