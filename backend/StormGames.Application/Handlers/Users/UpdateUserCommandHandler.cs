using MediatR;
using Microsoft.AspNetCore.Identity;
using StormGames.Application.Commands.Users;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Users;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;

    public UpdateUserCommandHandler(IUserRepository userRepository, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        //var user = await _userManager.FindByIdAsync(command.Id);
        var user = await _userRepository.GetUserById(command.Id);
        user.FirstName = command.FirstName;
        user.LastName = command.LastName;
        user.Email = command.Email;
        user.DateOfBirth = command.DateOfBirth;
        await _userRepository.Update(user);
        return user;
    }
}