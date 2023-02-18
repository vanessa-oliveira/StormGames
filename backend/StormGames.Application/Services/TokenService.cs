using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StormGames.Domain.Entities;
using StormGames.Infra.Contracts;

namespace StormGames.Application.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IIdentityService _identityService;

    public TokenService(UserManager<User> userManager, IConfiguration configuration, IRoleRepository roleRepository, IUserRepository userRepository, IIdentityService identityService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _identityService = identityService;
    }

    public async Task<string> CreateToken(string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
        var roles = await _userManager.GetRolesAsync(user);
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);
        
        var token = new SecurityTokenDescriptor
        {
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            Subject = identityClaims,
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = signingCredentials
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();

        var encodedToken = tokenHandler.CreateToken(token);
        var response = tokenHandler.WriteToken(encodedToken);
        return response;
    }
}