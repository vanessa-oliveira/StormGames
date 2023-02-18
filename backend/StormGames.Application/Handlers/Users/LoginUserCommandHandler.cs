using MediatR;
using Microsoft.AspNetCore.Identity;
using StormGames.Application.Commands.Users;
using StormGames.Application.Models;
using StormGames.Application.Queries.Models;
using StormGames.Application.Services;
using StormGames.Domain.Entities;

namespace StormGames.Application.Handlers.Users;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;

    public LoginUserCommandHandler(IIdentityService identityService, ITokenService tokenService, UserManager<User> userManager)
    {
        _identityService = identityService;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<LoginUserResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _identityService.SigninUserAsync(command.Email, command.Password);
        var loginUser = new LoginUserResponse();
        if (result)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            string token = await _tokenService.CreateToken(command.Email);
            loginUser.Name = String.Concat(user.FirstName, user.LastName);
            loginUser.Role = user.Role.Name;
            loginUser.Token = token;
        }
        
        return loginUser;
    }
}