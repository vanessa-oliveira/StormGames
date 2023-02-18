using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Roles;

public class CreateRoleCommand : IRequest<Role>
{
    public string Name { get; set; }
}