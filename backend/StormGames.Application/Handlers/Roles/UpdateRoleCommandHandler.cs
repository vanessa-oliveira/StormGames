using MediatR;
using StormGames.Application.Commands.Roles;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Roles;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Role>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleById(command.Id);
        role.Name = command.Name;
        await _roleRepository.Update(role);
        return role;
    }
}