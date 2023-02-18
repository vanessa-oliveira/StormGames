using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Roles;

public class DeleteRoleCommand : IRequest<Role>
{
    public Guid Id { get; set; }
}