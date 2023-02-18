using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StormGames.Application.Commands.Users;
using StormGames.Domain.Entities;
using BCrypt.Net;
using Microsoft.Extensions.DependencyInjection;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Handlers.Users;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IServiceProvider _serviceProvider;

    public CreateUserCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IRoleRepository roleRepository, IUserRepository userRepository, IServiceProvider serviceProvider)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _serviceProvider = serviceProvider;
    }

    public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleByName(command.Role);
        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            //DateOfBirth = command.DateOfBirth,
            UserName = command.Email,
            Email = command.Email,
            PasswordHash = command.Password,
            Role = role,
            Active = true
        };
        var result = await _userManager.CreateAsync(user, user.PasswordHash);
        //var addUserRole = await _userManager.AddToRoleAsync(user, role.Name);
        var RoleManager = _serviceProvider.GetRequiredService<RoleManager<Role>>();
        var roleExist = await RoleManager.RoleExistsAsync(role.Name.ToUpper());
        if (!roleExist)
        {
            var roleResult = await RoleManager.CreateAsync(role);
        }
        await _userManager.AddToRoleAsync(user, role.Name);
        return user;
    }
}