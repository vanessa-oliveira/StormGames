using MediatR;
using StormGames.Application.Commands.Categories;
using StormGames.Application.Commands.Games;
using StormGames.Application.Queries;
using StormGames.Infra.Contracts;
using StormGames.Infra.Repositories;

namespace StormGames.API.Configuration;

public static class AppConfiguration
{
    public static IServiceCollection AddConfig(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateCategoryCommand));
        services.AddMediatR(typeof(UpdateCategoryCommand));
        services.AddMediatR(typeof(DeleteCategoryCommand));
        services.AddMediatR(typeof(CreateGameCommand));
        services.AddMediatR(typeof(UpdateGameCommand));
        services.AddMediatR(typeof(DeleteGameCommand));
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICategoryQueries, CategoryQueries>();
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddTransient<IGameQueries, GameQueries>();
        return services;
    }
}