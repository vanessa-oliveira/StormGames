using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Roles;

public class UpdateRoleCommand : IRequest<Role>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}