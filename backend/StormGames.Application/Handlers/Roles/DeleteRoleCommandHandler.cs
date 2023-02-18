using MediatR;
using StormGames.Application.Commands.Roles;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Roles;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Role>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    public async Task<Role> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleById(command.Id);
        await _roleRepository.Delete(role);
        return role;
    }
}