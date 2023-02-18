using MediatR;
using StormGames.Domain.Entities;

namespace StormGames.Application.Commands.Users;

public class DeleteUserCommand : IRequest<User>
{
    public Guid Id { get; set; }
}