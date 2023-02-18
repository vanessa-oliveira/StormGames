using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StormGames.Application.Commands.Games;
using StormGames.Application.Commands.Genres;
using StormGames.Application.Commands.Roles;
using StormGames.Application.Commands.Users;
using StormGames.Application.Queries;
using StormGames.Application.Services;
using StormGames.Domain.Entities;
using StormGames.Infra.Context;
using StormGames.Infra.Contracts;
using StormGames.Infra.Repositories;

namespace StormGames.API.Configuration;

public static class AppConfiguration
{
    public static IServiceCollection AddConfig(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateGenreCommand));
        services.AddMediatR(typeof(UpdateGenreCommand));
        services.AddMediatR(typeof(DeleteGenreCommand));
        
        services.AddMediatR(typeof(CreateGameCommand));
        services.AddMediatR(typeof(UpdateGameCommand));
        services.AddMediatR(typeof(DeleteGameCommand));
        
        services.AddMediatR(typeof(CreateRoleCommand));
        services.AddMediatR(typeof(UpdateRoleCommand));
        services.AddMediatR(typeof(DeleteRoleCommand));
        
        services.AddMediatR(typeof(CreateUserCommand));
        services.AddMediatR(typeof(UpdateUserCommand));
        services.AddMediatR(typeof(DeleteUserCommand));

        services.AddMediatR(typeof(LoginUserCommand).GetTypeInfo().Assembly);
        
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IGenreRepository, GenreRepository>();
        services.AddTransient<IGenreQueries, GenreQueries>();
        
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IGameQueries, GameQueries>();
        
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IRoleQueries, RoleQueries>();
        
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserQueries, UserQueries>();
        
        services.AddTransient<ITokenService, TokenService>();
        services.AddScoped<IIdentityService, IdentityService>();
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        
        services.Configure<IdentityOptions>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 5;
            options.Password.RequiredUniqueChars = 1;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.User.RequireUniqueEmail = true;
        });

        return services;

    }
}