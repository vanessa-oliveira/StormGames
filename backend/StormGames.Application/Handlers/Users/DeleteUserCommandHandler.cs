using MediatR;
using StormGames.Application.Commands.Users;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Users;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(command.Id);
        user.Active = false;
        await _userRepository.Update(user);
        return user;
    }
}