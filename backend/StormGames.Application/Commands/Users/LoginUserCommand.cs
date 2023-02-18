using MediatR;
using StormGames.Application.Models;
using StormGames.Application.Queries.Models;

namespace StormGames.Application.Commands.Users;

public class LoginUserCommand : IRequest<LoginUserResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}