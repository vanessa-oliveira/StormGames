using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StormGames.Application.Commands.Roles;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Roles;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Role>
{
    private readonly RoleManager<Role> _roleManager;

    public CreateRoleCommandHandler(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<Role> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Name = command.Name.ToUpper()
        };
        var existsRole = await _roleManager.RoleExistsAsync(role.Name);
        if (existsRole)
        {
            throw new Exception("Role already exists!");
        }
        var result = await _roleManager.CreateAsync(role);
        return role;
    }
}